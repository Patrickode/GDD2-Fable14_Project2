using System;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class FollowPlayer : EnemyBehaviour
{
    [SerializeField]
    private Player player;

    private Stack<Vertex> pathToPlayer;

    protected override void Awake()
    {
        base.Awake();

        // Automatically set player if not set
        if (!player)
            player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        // Update path to player every time it moves
        if (player) player.OnMove += UpdatePathToPlayer;
    }

    private void OnDisable()
    {
        if (player) player.OnMove -= UpdatePathToPlayer;
    }

    // Move towards the player every action
    public override void Behave()
    {
        if (pathToPlayer != null && pathToPlayer.Count > 0)
        {
            //// Debug: Print out path listed
            //string debugString = "\nClick To Expand\n";
            //foreach (Vertex vertex in pathToPlayer)
            //{
            //    debugString += $"{vertex.x}, {vertex.y}\n";
            //}
            //Debug.Log(debugString);

            Vertex nextVertex = pathToPlayer.Pop();
            Vector2Int moveTo = new Vector2Int(nextVertex.x, nextVertex.y);
            Vector2Int displacement = moveTo - enemyScript.TileMoveController.Position;

            enemyScript.TileMoveController.Move(displacement);
        }
    }

    // Gets all tiles the enemy can walk on that action
    // Only floors (exclude tiles that have colliders or enemies on them)
    private Vector3Int[,] GetWalkableTiles()
    {
        Tilemap floor = LevelManager.CurrentLevel.floor;
        Tilemap colliders = LevelManager.CurrentLevel.colliders;
        List<Enemy> enemies = LevelManager.CurrentLevel.enemies;

        floor.CompressBounds();
        BoundsInt bounds = floor.cellBounds;

        Vector3Int[,] walkableTiles = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int y = bounds.yMax, i = 0; i < bounds.size.y; y--, i++)
        {
            for (int x = bounds.xMin, j = 0; j < bounds.size.x; x++, j++)
            {
                Vector3Int currentPosition = new Vector3Int(x, y, 0);

                // Collider has tiles offset at y by 1, use this to check with HasTile()
                Vector3Int currentPositionShifted = new Vector3Int(currentPosition.x, currentPosition.y - 1, currentPosition.z);
                
                if (colliders.HasTile(currentPositionShifted) || EnemyAtPosition(currentPosition.x, currentPosition.y))
                {
                    // A z other than 0 will make the tile unwalkable on the A* algorithm
                    currentPosition.z = 1;
                }

                walkableTiles[j, i] = currentPosition;
            }
        }

        //// Debug: Map of walkable tiles
        //string debugString = "\nClick To Expand\n";
        //for (int i = 0; i <= walkableTiles.GetUpperBound(1); i++)
        //{
        //    for (int j = 0; j <= walkableTiles.GetUpperBound(0); j++)
        //    {
        //        debugString += $"{walkableTiles[j, i].z} ";
        //    }
        //    debugString += "\n ";
        //}
        //Debug.Log(debugString);

        return walkableTiles;
    }

    private bool EnemyAtPosition(int x, int y)
    {
        foreach (Enemy enemy in LevelManager.CurrentLevel.enemies)
        {
            if (enemy.TileMoveController)
            {
                if (enemy.TileMoveController.Position.x == x && enemy.TileMoveController.Position.y == y)
                    return true;
            }
        }

        return false;
    }

    private void UpdatePathToPlayer()
    {
        if (enemyScript.TileMoveController)
            pathToPlayer = Astar.GetTilePath(GetWalkableTiles(), enemyScript.TileMoveController.Position, player.TileMoveController.Position);
    }

    private void OnDestroy()
    {
        if (player)
            player.OnMove -= UpdatePathToPlayer;
    }
}
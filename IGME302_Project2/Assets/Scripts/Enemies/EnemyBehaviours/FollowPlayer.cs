using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowPlayer : EnemyBehaviour
{
    [SerializeField]
    private Player player;

    private Stack<Vertex> pathToPlayer;

    private int DistanceToPlayer => Mathf.CeilToInt(Vector2Int.Distance(enemy.Position, player.Position));

    protected override void Awake()
    {
        base.Awake();

        // Automatically set player if not set
        if (!player)
            player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        player.OnMove += UpdatePathToPlayer;
    }

    private void OnDisable()
    {
        player.OnMove -= UpdatePathToPlayer;
    }

    // Move towards the player every action
    public override void Behave()
    {
        if (pathToPlayer != null && pathToPlayer.Count > 0 && DistanceToPlayer > 1)
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
            // Don't move to the player's position if next to it
            if (moveTo != player.TileMoveController.Position)
            {
                Vector2Int displacement = moveTo - enemy.TileMoveController.Position;
                enemy.TileMoveController.Move(displacement);
            }
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
                if (colliders.HasTile(currentPositionShifted) || EnemyAt(currentPosition))
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

    private void UpdatePathToPlayer(Vector3 oldPosition, Vector3 newPosition)
    {
        if (enemy.TileMoveController)
            pathToPlayer = Astar.GetTilePath(GetWalkableTiles(), enemy.TileMoveController.Position, newPosition.ToVector2().ToVector2Int());
        else
            pathToPlayer = null;
    }

    private bool EnemyAt(Vector3Int position)
    {
        foreach (Enemy enemy in LevelManager.CurrentLevel.enemies)
        {
            if (enemy.Position == (Vector2Int)position)
                return true;
        }

        return false;
    }
}
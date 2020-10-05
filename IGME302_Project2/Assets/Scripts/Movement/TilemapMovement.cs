using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMovement
{
    // Collection of floor tiles that can be moved to
    private Tilemap floor;
    // Obstacles that can't be moved to
    private Tilemap colliders;

    public TilemapMovement(Tilemap floorMap, Tilemap colliderMap)
    {
        floor = floorMap;
        colliders = colliderMap;
    }

    public bool IsCollision(Vector2 position)
    {
        Vector3Int gridPosition = floor.WorldToCell(position);
        // Ground does not exist or tile is a collider?
        return !floor.HasTile(gridPosition) || colliders.HasTile(gridPosition);
    }

    public void Move(Transform agent, Vector2 direction)
    {
        Vector3 newPosition = agent.position + (Vector3)direction;
        if (!IsCollision(newPosition))
            agent.position = newPosition;
    }
}
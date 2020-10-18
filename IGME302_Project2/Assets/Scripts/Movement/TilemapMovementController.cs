using UnityEngine;
using System;

public class TilemapMovementController : MonoBehaviour, IMovable
{
    public Vector2Int Position => transform.position.ToVector2().ToVector2Int();

    // Triggers every successful move
    public Action<Vector3, Vector3> OnMove;

    // Returns whether the tile at position can be moved to
    public bool IsValidMove(Vector2 position)
    {
        Vector3Int gridPosition = LevelManager.CurrentLevel.floor.WorldToCell(position);

        // Tile exists in ground
        // Does not exist in colliders
        // There is no enemy on top of it
        if (LevelManager.CurrentLevel.floor.HasTile(gridPosition) &&
            !LevelManager.CurrentLevel.colliders.HasTile(gridPosition) &&
            !EnemyAt(position.ToVector2Int()))
            return true;

        return false;
    }

    private bool EnemyAt(Vector2Int position)
    {
        foreach (Enemy enemy in LevelManager.CurrentLevel.enemies)
        {
            if (enemy.Position == position)
                return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to move the agent by an amount of displacement. Invokes OnMove method if successful.
    /// </summary>
    /// <param name="displacement">Which direction and how far to try and move.</param>
    public void Move(Vector2 displacement)
    {
        Vector3 newPosition = transform.position + (Vector3)displacement;
        if (IsValidMove(newPosition))
        {
            Vector3 oldPosition = transform.position;
            transform.position = newPosition;
            OnMove?.Invoke(oldPosition, newPosition);
        }
    }

    /// <summary>
    /// Tries to move to a specific location.
    /// </summary>
    /// <param name="position">The position to try and move to.</param>
    public void MoveTo(Vector2 position)
    {
        if (IsValidMove(position))
            transform.position = position;
    }
}
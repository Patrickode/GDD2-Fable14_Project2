using UnityEngine;
using System;

public class TilemapMovementController : MonoBehaviour, IMovable
{
    public Vector2Int Position => transform.position.ToVector2().ToVector2Int();

    // Triggers every successful move
    public Action OnMove;

    // Returns whether the tile at position can be moved to
    public bool IsCollision(Vector2 position)
    {
        Vector3Int gridPosition = LevelManager.CurrentLevel.floor.WorldToCell(position);
        // Ground does not exist or tile is a collider?
        return !LevelManager.CurrentLevel.floor.HasTile(gridPosition) || LevelManager.CurrentLevel.colliders.HasTile(gridPosition);
    }

    /// <summary>
    /// Tries to move the agent by an amount of displacement. Invokes OnMove method if successful.
    /// </summary>
    /// <param name="displacement">Which direction and how far to try and move.</param>
    public void Move(Vector2 displacement)
    {
        Vector3 newPosition = transform.position + (Vector3)displacement;
        if (!IsCollision(newPosition))
        {
            transform.position = newPosition;
            OnMove?.Invoke();
        }
    }

    /// <summary>
    /// Tries to move to a specific location.
    /// </summary>
    /// <param name="position">The position to try and move to.</param>
    public void MoveTo(Vector2 position)
    {
        if (!IsCollision(position))
            transform.position = position;
    }

    private void OnDestroy()
    {
        OnMove = null;
    }
}
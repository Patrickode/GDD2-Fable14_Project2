using UnityEngine;
using System;
using System.Drawing;

public class TilemapMovementController : IMovable
{
    private Transform agent;
    private Level level;
    private Point position;

    public Point Position => position;
    

    public Action OnMove;

    /// <summary>
    /// Constructor for a new Tilemap Movement Controller.
    /// </summary>
    /// <param name="agent">Object that will be moved along the tilemap.</param>
    /// <param name="leve">Level the controller will use to calculate movement.</param>
    public TilemapMovementController(Transform agent, Level level)
    {
        this.agent = agent;
        this.level = level;

        position = new Point();
        UpdatePosition(agent.position);
    }

    public void ChangeLevel(Level newLevel)
    {
        level = newLevel;
    }

    // Returns whether the tile at position can be moved to
    public bool IsCollision(Vector2 position)
    {
        Vector3Int gridPosition = level.floor.WorldToCell(position);
        // Ground does not exist or ceiling does not exist or tile is a collider?
        return !level.floor.HasTile(gridPosition) || level.colliders.HasTile(gridPosition);
    }

    // Tries to move the agent.
    // Invokes OnMove method if successful.
    public void Move(Vector2 displacement)
    {
        Vector3 newPosition = agent.position + (Vector3)displacement;
        if (!IsCollision(newPosition))
        {
            agent.position = newPosition;
            UpdatePosition(newPosition);
            OnMove?.Invoke();
        }
    }

    public void MoveTo(Vector2 position)
    {
        if (!IsCollision(position))
        {
            agent.position = position;
            UpdatePosition(position);

        }
    }

    private void UpdatePosition(Vector3 newPosition)
    {
        position.X = (int)newPosition.x;
        position.Y = (int)newPosition.y;
    }
}
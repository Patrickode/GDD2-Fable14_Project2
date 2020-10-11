using System;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class MovingEntity : MonoBehaviour, IMovable
{
    private TilemapMovementController tileMoveController;
    public TilemapMovementController TileMoveController => tileMoveController;

    public Action OnMove;

    private TargetFollower targetFollower;

    protected virtual void Awake()
    {
        targetFollower = GetComponent<TargetFollower>();
        // Attach a TilemapMovementController to all moving entities' target
        if (targetFollower.target)
        {
            targetFollower.target.gameObject.AddComponent(typeof(TilemapMovementController));
            tileMoveController = targetFollower.target.GetComponent<TilemapMovementController>();
        }
            
        tileMoveController.OnMove += () => OnMove?.Invoke();
    }

    /// <summary>
    /// Try to move by a given amount.
    /// </summary>
    /// <param name="displacement">The amount and direction to try and move in.</param>
    public virtual void Move(Vector2 displacement)
    {
        if (targetFollower.target)
            tileMoveController.Move(displacement);
    }

    /// <summary>
    /// Try to move to a specific location.
    /// </summary>
    /// <param name="position">The position to try and move to.</param>
    public virtual void MoveTo(Vector2 position)
    {
        if (!tileMoveController.IsCollision(position))
        {
            transform.position = (Vector3)position;
            tileMoveController.MoveTo(position);
        }
    }
}

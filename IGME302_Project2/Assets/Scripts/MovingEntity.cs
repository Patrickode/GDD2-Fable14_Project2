using System;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class MovingEntity : MonoBehaviour, IMovable
{
    // [SerializeField]
    private TilemapMovementController tileMoveController;
    public TilemapMovementController TileMoveController => tileMoveController;

    public Action OnMove;

    private TargetFollower targetFollower;

    protected virtual void Awake()
    {
        targetFollower = GetComponent<TargetFollower>();

    }

    protected virtual void Start()
    {
        // Attach a TilemapMovementController to all moving entities' target
        tileMoveController = targetFollower.Target.gameObject.AddComponent(typeof(TilemapMovementController)) as TilemapMovementController;
        TileMoveController.OnMove += TriggerMoveEvent;
    }

    private void OnDestroy()
    {
        TileMoveController.OnMove -= TriggerMoveEvent;
    }

    private void TriggerMoveEvent()
    {
        OnMove?.Invoke();
    }

    /// <summary>
    /// Try to move by a given amount.
    /// </summary>
    /// <param name="displacement">The amount and direction to try and move in.</param>
    public virtual void Move(Vector2 displacement)
    {
        if (targetFollower.Target)
            TileMoveController.Move(displacement);
    }

    /// <summary>
    /// Try to move to a specific location.
    /// </summary>
    /// <param name="position">The position to try and move to.</param>
    public virtual void MoveTo(Vector2 position)
    {
        if (!TileMoveController.IsCollision(position))
        {
            transform.position = (Vector3)position;
            TileMoveController.MoveTo(position);
        }
    }
}

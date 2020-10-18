using System;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class MovingEntity : MonoBehaviour, IMovable
{
    private TargetFollower targetFollower;

    // [SerializeField]
    private TilemapMovementController tileMoveController;
    public TilemapMovementController TileMoveController
    {
        get => tileMoveController;
        set => tileMoveController = value;
    }
    public Vector2Int Position => TileMoveController.Position;
    public Action<Vector3, Vector3> OnMove
    {
        get => TileMoveController.OnMove;
        set => TileMoveController.OnMove = value;
    }

    public Action OnMoveControllerSetup;

    protected virtual void Awake()
    {
        targetFollower = GetComponent<TargetFollower>();

        // Shortcut for smooth moving entity
        // Set Target to self gameobject
        if (targetFollower.Target == transform)
        {
            GameObject newTarget = new GameObject();
            newTarget.transform.position = transform.position;
            newTarget.name = $"{this.name}Target";

            // Organize it into the Target Container
            Transform targetContainer = GameObject.FindGameObjectWithTag("Target Container").transform;
            if (targetContainer)
                newTarget.transform.parent = targetContainer.transform;

            targetFollower.Target = newTarget.transform;
            // Attach a TilemapMovementController to all moving entities' target
            if (targetFollower.Target)
                TileMoveController = targetFollower.Target.gameObject.AddComponent(typeof(TilemapMovementController)) as TilemapMovementController;
            OnMoveControllerSetup?.Invoke();
        }
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
        if (TileMoveController.IsValidMove(position))
        {
            transform.position = (Vector3)position;
            TileMoveController.MoveTo(position);
        }
    }
}

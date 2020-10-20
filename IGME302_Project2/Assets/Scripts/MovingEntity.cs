using System;
using System.Linq;
using UnityEngine;

public class MovingEntity : MonoBehaviour, IMovable
{
    public TilemapMovementController tileMoveController;

    private Level currentLevel;
    public Level CurrentLevel
    {
        get => currentLevel;
        set
        {
            currentLevel = value;
            tileMoveController.ChangeLevel(currentLevel);
        }
    }
    public Transform target;

    public Action OnMove;

    protected virtual void Awake()
    {
        if (target == null)
        {
            target = transform.Cast<Transform>().ToList().Find(t => t.CompareTag("FollowTarget"));
        }

        tileMoveController = new TilemapMovementController(target.transform, currentLevel);
        tileMoveController.OnMove += () => OnMove?.Invoke();
    }

    /// <summary>
    /// Try to move by a given amount.
    /// </summary>
    /// <param name="displacement">The amount and direction to try and move in.</param>
    public virtual void Move(Vector2 displacement)
    {
        if (target != null)
        {
            tileMoveController.Move(displacement);
        }
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

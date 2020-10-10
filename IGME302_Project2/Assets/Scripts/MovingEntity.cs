using System;
using System.Linq;
using UnityEngine;

public class MovingEntity : MonoBehaviour, IMovable
{
    private TilemapMovementController tileMoveController;

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
            target = transform.Cast<Transform>().ToList().Find(t => t.tag == "FollowTarget");
        }

        tileMoveController = new TilemapMovementController(target.transform, currentLevel);
        tileMoveController.OnMove += () => OnMove?.Invoke();
    }

    public virtual void Move(Vector2 displacement)
    {
        if (target != null)
        {
            tileMoveController.Move(displacement);
        }
    }

    public virtual void MoveTo(Vector2 position)
    {
        if (!tileMoveController.IsCollision(position))
        {
            transform.position = (Vector3)position;
            tileMoveController.MoveTo(position);
        }
    }
}

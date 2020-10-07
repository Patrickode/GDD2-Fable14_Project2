using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(TargetFollower))]
public class Player : MonoBehaviour, IMovable
{
    private PlayerControls controls;
    private TilemapMovementController tileMoveController;

    public Level currentLevel;
    public Transform target;

    public Action OnMove;

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Awake()
    {
        if (target == null)
        {
            target = transform.Cast<Transform>().ToList().Find(t => t.tag == "FollowTarget");
        }

        controls = new PlayerControls();
        tileMoveController = new TilemapMovementController(target.transform, currentLevel);
        OnMove = tileMoveController.OnMove;

        // Events
        controls.Movement.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    public void Move(Vector2 displacement)
    {
        if (target != null)
        {
            tileMoveController.Move(displacement);
        }
    }

    public void MoveTo(Vector2 position)
    {
        if (!tileMoveController.IsCollision(position))
        {
            transform.position = (Vector3)position;
            tileMoveController.MoveTo(position);
        }
    }
}
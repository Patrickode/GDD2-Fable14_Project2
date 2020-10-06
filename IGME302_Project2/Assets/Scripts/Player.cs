using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TargetFollower))]
public class Player : MonoBehaviour, IMovable
{
    [SerializeField]
    private Tilemap floor = null;
    [SerializeField]
    private Tilemap colliders = null;

    private Transform target;

    private PlayerControls controls = null;
    private TilemapMovement tilemapMover = null;

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
        controls = new PlayerControls();
        tilemapMover = new TilemapMovement(floor, colliders);

        // Events
        controls.Movement.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    void Start()
    {
        InitTarget();
    }

    public void Move(Vector2 direction)
    {
        if (tilemapMover.Move(target, direction))
            OnMove?.Invoke();
    }

    // Handles TargetFollower logic
    private void InitTarget()
    {
        TargetFollower follower = GetComponent<TargetFollower>();
        if (follower.target != null)
        {
            target = GetComponent<TargetFollower>().target;
        }
        else
        {
            Transform potentialTarget = transform.Find("PlayerTarget");
            if (potentialTarget != null)
            {
                follower.target = potentialTarget;
                target = potentialTarget;
            }
        }

        // Move the target to the player's starting position
        target.position = transform.position;
    }
}
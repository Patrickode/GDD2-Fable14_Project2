using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TargetFollower))]
public class Player : MonoBehaviour, IMovable
{
    [SerializeField]
    Tilemap floor;
    [SerializeField]
    Tilemap colliders;

    private Transform target;

    private PlayerControls controls;
    private TilemapMovement tilemapMover;
    

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
        tilemapMover.Move(target, direction);
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

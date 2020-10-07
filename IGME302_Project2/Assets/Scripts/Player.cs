using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class Player : MovingEntity
{
    private PlayerControls controls;

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    protected override void Awake()
    {
        base.Awake();

        controls = new PlayerControls();

        // Events
        controls.Movement.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }
}
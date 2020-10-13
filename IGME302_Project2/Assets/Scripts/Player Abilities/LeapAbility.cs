using UnityEngine;

public class LeapAbility : Ability
{
    [SerializeField] [Range(2, 4)] private int leapDistance = 2;

    public LeapAbility()
    {
        isAimable = true;
    }

    public override void Activate(MovingEntity user, Vector2Int direction = default)
    {
        base.Activate(user, direction);

        user.Move(direction * leapDistance);
    }
}

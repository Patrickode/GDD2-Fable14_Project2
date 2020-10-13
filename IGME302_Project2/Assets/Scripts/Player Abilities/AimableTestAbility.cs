using UnityEngine;

public class AimableTestAbility : Ability
{
    public AimableTestAbility()
    {
        isAimable = true;
    }

    public override void Activate(MovingEntity user, Vector2Int direction = default)
    {
        Debug.Log("You aimed and did a theurgy thing!");

        usagesLeft--;
    }
}

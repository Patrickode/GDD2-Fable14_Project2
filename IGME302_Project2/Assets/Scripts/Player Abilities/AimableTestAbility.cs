using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimableTestAbility : Ability
{
    public AimableTestAbility()
    {
        isAimable = true;
    }

    public override void Activate(Vector2Int direction = default)
    {
        base.Activate(direction);

        Debug.Log("You aimed and did a theurgy thing!");
    }
}

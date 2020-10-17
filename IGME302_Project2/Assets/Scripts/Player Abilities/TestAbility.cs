using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility : Ability
{
    public override void Init() { isAimable = false; }

    public override void Activate(MovingEntity user, Vector2Int direction = default)
    {
        Debug.Log("You did a theurgy thing!");

        usagesLeft--;
    }
}
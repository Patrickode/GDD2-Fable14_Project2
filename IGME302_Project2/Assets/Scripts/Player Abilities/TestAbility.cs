using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility : Ability
{
    public TestAbility()
    {
        isAimable = false;
    }

    public override void Activate(Vector2Int direction = default)
    {
        base.Activate(direction);

        Debug.Log("You did a theurgy thing!");
    }
}
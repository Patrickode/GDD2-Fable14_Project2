using System;
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
        //Store a reference to a temporary "subtract usages" function
        Action subtractUsages = () => usagesLeft--;

        //Subscribe subtractUsages to OnMove so if the player succeeds in moving, subtract a use, and if 
        //they don't, don't subtract a use. Unsubscribe afterwards so normal moving doesn't subtract usages
        user.OnMove += subtractUsages;
        user.Move(direction * leapDistance);
        user.OnMove -= subtractUsages;
    }
}

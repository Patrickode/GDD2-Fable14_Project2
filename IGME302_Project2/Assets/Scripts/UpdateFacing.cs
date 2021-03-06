﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFacing : MonoBehaviour
{
    [SerializeField] private MovingEntity thisEntity = null;
    [SerializeField] private SpriteRenderer rendToUpdate = null;
    [Space(10)]
    [Tooltip("When facing left, use Right Sprite and set Flip X to true.")]
    [SerializeField] private bool useFlippedRightForLeft = false;
    [Tooltip("When facing right, use Left Sprite and set Flip X to true.")]
    [SerializeField] private bool useFlippedLeftForRight = false;
    [Space(10)]
    [SerializeField] private Sprite upSprite = null;
    [SerializeField] private Sprite downSprite = null;
    [SerializeField] private Sprite leftSprite = null;
    [SerializeField] private Sprite rightSprite = null;

    private void Start()
    {
        thisEntity.OnTryMove += UpdateFacingSprite;
        if (thisEntity is Player)
        {
            Player.OnAbility += UpdateIfAimed;
        }
    }
    private void OnDestroy()
    {
        thisEntity.OnTryMove -= UpdateFacingSprite;
        if (thisEntity is Player)
        {
            Player.OnAbility -= UpdateIfAimed;
        }
    }
    private void UpdateIfAimed(Ability ability, int _)
    {
        if (ability.isAimable) { UpdateFacingSprite(ability.direction); }
    }

    private void UpdateFacingSprite(Vector3 fromPos, Vector3 toPos)
    {
        UpdateFacingSprite(Vector3.SignedAngle(Vector3.up, toPos - fromPos, Vector3.back));
    }
    private void UpdateFacingSprite(Vector3 direction)
    {
        UpdateFacingSprite(Vector3.SignedAngle(Vector3.up, direction, Vector3.back));
    }
    private void UpdateFacingSprite(float angleFromUp)
    {
        Sprite spriteToSwitchTo;

        if (Mathf.Approximately(angleFromUp, 0))
        {
            spriteToSwitchTo = upSprite;
            rendToUpdate.flipX = false;
        }
        else if (Mathf.Approximately(angleFromUp, 180) || Mathf.Approximately(angleFromUp, -180))
        {
            spriteToSwitchTo = downSprite;
            rendToUpdate.flipX = false;
        }
        else if (Mathf.Approximately(angleFromUp, -90))
        {
            //If using flipped right for left, use the right sprite and flip. Just use left if not.
            spriteToSwitchTo = useFlippedRightForLeft ? rightSprite : leftSprite;
            rendToUpdate.flipX = useFlippedRightForLeft;
        }
        else if (Mathf.Approximately(angleFromUp, 90))
        {
            //If using flipped left for right, use the left sprite and flip. Just use right if not.
            spriteToSwitchTo = useFlippedLeftForRight ? leftSprite : rightSprite;
            rendToUpdate.flipX = useFlippedLeftForRight;
        }
        else
        {
            Debug.LogWarning("UpdateFacingSprite: angleFromUp didn't correspond to up, down, left, or right.");
            return;
        }

        rendToUpdate.sprite = spriteToSwitchTo;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFacing : MonoBehaviour
{
    [SerializeField] private MovingEntity thisEntity = null;
    [SerializeField] private SpriteRenderer rendToUpdate = null;
    [Space(10)]
    [SerializeField] private Sprite upSprite = null;
    [SerializeField] private Sprite downSprite = null;
    [SerializeField] private Sprite leftSprite = null;
    [SerializeField] private Sprite rightSprite = null;

    private void Start()
    {
        thisEntity.OnMove += UpdateFacingSprite;
        if (thisEntity is Player)
        {
            Player.OnAbility += UpdateIfAimed;
        }
    }
    private void OnDestroy()
    {
        thisEntity.OnMove -= UpdateFacingSprite;
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
        }
        else if (Mathf.Approximately(angleFromUp, 180) || Mathf.Approximately(angleFromUp, -180))
        {
            spriteToSwitchTo = downSprite;
        }
        else if (Mathf.Approximately(angleFromUp, -90))
        {
            spriteToSwitchTo = leftSprite;
        }
        else if (Mathf.Approximately(angleFromUp, 90))
        {
            spriteToSwitchTo = rightSprite;
        }
        else
        {
            Debug.LogWarning("UpdateFacingSprite: angleFromUp didn't correspond to up, down, left, or right.");
            return;
        }

        rendToUpdate.sprite = spriteToSwitchTo;
    }
}

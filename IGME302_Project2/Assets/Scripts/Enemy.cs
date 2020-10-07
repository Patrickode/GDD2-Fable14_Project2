using System;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class Enemy : MovingEntity
{
    public Action OnAction;
    public Action OnAttack;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    public EnemyData enemyData;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (enemyData?.sprite != null)
            spriteRenderer.sprite = enemyData.sprite;
    }
}
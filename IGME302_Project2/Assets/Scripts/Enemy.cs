using System;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class Enemy : MovingEntity
{
    public Action OnAction;
    public Action OnAttack;

    public string enemyName;

    [SerializeField]
    private EnemyMoveBehaviour moveBehaviour;

    public int TurnsUntilAction { get; private set; }
}
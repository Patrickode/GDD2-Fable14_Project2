using System;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class Enemy : MovingEntity
{
    public Action OnAction;
    public Action OnAttack;

    public Action OnDeath;

    public string enemyName;
    public int turnsPerAction;

    private int turnsUntilAction;
    public int TurnsUntilAction
    {
        get => turnsUntilAction;
        set
        {
            turnsUntilAction = value;
            if (turnsUntilAction <= 0)
            {
                OnAction?.Invoke();
                turnsUntilAction = turnsPerAction;
            }
        }
    }

    private EnemyBehaviour[] behaviours;

    protected override void Awake()
    {
        base.Awake();

        // Get all behaviours attached to this enemy
        behaviours = GetComponents<EnemyBehaviour>();
    }

    private void Start()
    {
        turnsUntilAction = turnsPerAction;
    }

    private void OnEnable()
    {
        TurnManager.OnTurnEnd += ReduceTurnsUntilAction;
        OnAction += ActivateAllBehaviours;
        OnDeath += Die;
    }

    private void OnDisable()
    {
        TurnManager.OnTurnEnd -= ReduceTurnsUntilAction;
        OnMove = null;
        OnAction -= null;
        OnAttack = null;
        OnDeath -= Die;
    }

    private void ActivateAllBehaviours()
    {
        foreach (EnemyBehaviour behaviour in behaviours)
            behaviour.Behave();
    }

    private void ReduceTurnsUntilAction()
    {
        TurnsUntilAction--;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
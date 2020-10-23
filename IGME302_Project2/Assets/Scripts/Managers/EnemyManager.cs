using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    public List<Enemy> enemies;

    // Flag to check if OnAllEnemiesKilled event was already triggered
    // once for the current level
    private bool allEnemiesKilledTriggered = false;

    public Action OnAllEnemiesKilled;

    private void Awake()
    {
        // Automatically set fields
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable()
    {
        LevelManager.OnLoaded += ResetAllEnemiesKilledFlag;
        OnAllEnemiesKilled += TriggerAllEnemiesKilledFlag;
    }

    private void OnDisable()
    {
        LevelManager.OnLoaded -= ResetAllEnemiesKilledFlag;
        OnAllEnemiesKilled -= TriggerAllEnemiesKilledFlag;
    }

    private void TriggerAllEnemiesKilledFlag()
    {
        allEnemiesKilledTriggered = true;
    }

    private void ResetAllEnemiesKilledFlag(Level level)
    {
        allEnemiesKilledTriggered = false;
    }

    private void Start()
    {
        if (levelManager)
        {
            LevelManager.OnLoaded += loadedLevel =>
            {
                enemies = loadedLevel.enemies;
                enemies.ForEach(enemy => { enemy.OnDeath += () => { enemies.Remove(enemy);  }; } );
            };
        }
    }

    private void Update()
    {
        if (!allEnemiesKilledTriggered && enemies.Count <= 0)
            OnAllEnemiesKilled?.Invoke();
    }
}

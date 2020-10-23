using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesKilledEventsTriggerer : MonoBehaviour
{
    private List<LevelEffect> levelEffects;

    private EnemyManager enemyManager;

    private void Awake()
    {
        levelEffects = GetComponents<LevelEffect>().ToList();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void OnEnable()
    {
        enemyManager.OnAllEnemiesKilled += TriggerLevelEffects;
    }

    private void OnDisable()
    {
        enemyManager.OnAllEnemiesKilled -= TriggerLevelEffects;
    }

    private void TriggerLevelEffects()
    {
        foreach (LevelEffect effect in levelEffects)
            effect.ActivateEffect();
    }
}

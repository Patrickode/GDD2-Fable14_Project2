﻿using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private LevelManager levelManager;

    void Awake()
    {
        // Automatically set fields
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable()
    {
        LevelManager.OnLoaded += InitPlayer;
        player.OnMove += CheckLevelGoalReached;
        player.OnDeath += ReloadCurrentLevel;
    }

    private void OnDisable()
    {
        LevelManager.OnLoaded -= InitPlayer;
        player.OnMove -= CheckLevelGoalReached;
        player.OnDeath -= ReloadCurrentLevel;
    }

    private void InitPlayer(Level loadedLevel)
    {
        // Spawn player at the level's spawn point
        player.MoveTo(loadedLevel.spawnPoint);
        //Set/Reset the player's abilities
        player.SetAbilities(loadedLevel.abilitySet);
    }

    private void CheckLevelGoalReached(Vector3 oldPosition, Vector3 newPosition)
    {
        if (newPosition.ToVector2().ToVector2Int() == LevelManager.CurrentLevel.goal)
            levelManager.Load(LevelManager.CurrentLevel.nextLevel);
    }

    private void ReloadCurrentLevel()
    {
        LevelManager.LoadLevelByPrefab?.Invoke(null);
    }
}

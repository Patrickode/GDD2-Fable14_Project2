﻿using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private LevelManager levelManager;

    void Start()
    {
        // Automatically set fields
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!levelManager)
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        // Attach level to player every time it is changed
        if (levelManager)
        {
            levelManager.OnLoaded += loadedLevel =>
            {
                if (player)
                    player.CurrentLevel = loadedLevel;

                // Spawn player at the level's spawn point
                player.MoveTo(loadedLevel.spawnPoint);
            };
        }

        // Check if the player has reached the goal every move
        // If they have, load the next level
        if (player && levelManager)
        {
            player.OnMove += () =>
            {
                if (player.tileMoveController.position == levelManager.currentLevel.goal)
                {
                    levelManager.Load(levelManager.currentLevel.nextLevel);
                }
            };
        }
    }
}

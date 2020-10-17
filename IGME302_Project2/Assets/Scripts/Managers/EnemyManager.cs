using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    private List<Enemy> enemies;

    private void Awake()
    {
        // Automatically set fields
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        if (levelManager)
        {
            LevelManager.OnLoaded += loadedLevel =>
            {
                enemies = loadedLevel.enemies;
            };
        }
    }
}

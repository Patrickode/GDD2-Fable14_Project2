using UnityEngine;

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

    private void Start()
    {
        // Attach level to player every time it is changed
        if (levelManager)
        {
            LevelManager.OnLoaded += loadedLevel =>
            {
                // Spawn player at the level's spawn point
                player.MoveTo(loadedLevel.spawnPoint);
                //Set/Reset the player's abilities
                player.SetAbilities(loadedLevel.abilitySet);
            };
        }

        // Check if the player has reached the goal every move
        // If they have, load the next level
        if (player && levelManager)
        {
            player.OnMove += () =>
            {
                if (player.TileMoveController.Position == LevelManager.CurrentLevel.goal)
                {
                    levelManager.Load(LevelManager.CurrentLevel.nextLevel);
                }
            };
        }
    }
}

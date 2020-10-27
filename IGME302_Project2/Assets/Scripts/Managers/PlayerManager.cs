using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private AudioClip levelClearedSound;

    private SoundEffectsManager soundEffectsManager;

    void Awake()
    {
        // Automatically set fields
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();

        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
    }

    private void Start()
    {
        LevelManager.OnLoaded += InitPlayer;
        player.OnMove += CheckLevelGoalReached;
        player.OnDeath += ReloadCurrentLevel;

        //Init player on start in case the level loads before InitPlayer can subscribe to OnLoaded.
        if (LevelManager.CurrentLevel) { InitPlayer(LevelManager.CurrentLevel); }
    }

    private void OnDestroy()
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
        if (Vector3.Distance(newPosition, (Vector2)LevelManager.CurrentLevel.goal) < 0.6f)
        {
            Level nextLevel = LevelManager.CurrentLevel.nextLevel;
            if (nextLevel)
            {
                // rustle.m4a by sonic7832 at freesound.org
                // https://freesound.org/people/sonic7832/sounds/488688/
                soundEffectsManager.PlaySound(levelClearedSound);
                levelManager.Load(nextLevel);
            }
            else
            {
                //Load the next level in the build index.
                TransitionLoader.TransitionLoad?.Invoke(-1);
            }
        }
    }

    private void ReloadCurrentLevel()
    {
        LevelManager.LoadLevelByPrefab?.Invoke(null);
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private LevelManager levelManager;

    void Start()
    {
        // Automatically set fields
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (levelManager == null)
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        // Attach level to player every time it is changed
        if (levelManager != null)
        {
            levelManager.OnLoaded += loadedLevel =>
            {
                if (player != null)
                    player.CurrentLevel = loadedLevel;
            };
        }
    }
}

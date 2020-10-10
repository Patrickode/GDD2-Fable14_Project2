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
            };
        }
    }
}

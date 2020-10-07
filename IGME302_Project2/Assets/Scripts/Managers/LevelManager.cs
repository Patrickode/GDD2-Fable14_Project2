using System;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public Transform grid;

    public Level currentLevel { get; private set; }

    public Action<Level> OnLoaded;

    private void Awake()
    {
        // Automatically populate grid if null
        if (grid == null)
            grid = GameObject.FindGameObjectWithTag("Grid")?.transform;
    }

    private void Start()
    {
        Load("TestLevel");
    }

    public void Load(string levelName)
    {
        GameObject loadedLevelObject = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Levels/" + levelName + ".prefab"));
        Level loadedLevel = loadedLevelObject.GetComponent<Level>();
        loadedLevel.Load();
        loadedLevel.transform.parent = grid;
        loadedLevel.transform.position = loadedLevel.transform.parent.position;

        // Unload currentLevel if there is any
        if (currentLevel != null)
            Destroy(currentLevel);

        currentLevel = loadedLevel;
        OnLoaded?.Invoke(loadedLevel);
    }

    [MenuItem("Dev Tools/Create New/Level")]
    private static void CreateNewLevel()
    {
        GameObject newLevelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/NewLevel.prefab");
        GameObject newLevel = Instantiate(newLevelPrefab, Vector2.zero, Quaternion.identity);
        newLevel.name = "New Level";
        Transform grid = GameObject.FindGameObjectWithTag("Grid")?.transform;
        newLevel.transform.parent = grid;
    }
}

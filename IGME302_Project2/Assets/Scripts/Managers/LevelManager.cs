using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public Transform grid;

    public Level currentLevel { get; private set; }

    public static Action<Level> OnLoaded;

    /// <summary>
    /// Invoke to load a level by its prefab; if null, defaults to reloading the current level
    /// </summary>
    public static Action<Level> LoadLevelByPrefab;

    private void Awake()
    {
        // Automatically populate grid if null
        if (grid == null)
            grid = GameObject.FindGameObjectWithTag("Grid")?.transform;

        LoadLevelByPrefab += lvl =>
        {
            if (!lvl) { lvl = currentLevel; }
            Load(lvl);
        };
    }
    private void OnDestroy()
    {
        LoadLevelByPrefab -= lvl =>
        {
            if (!lvl) { lvl = currentLevel; }
            Load(lvl);
        };
    }

    private void Start()
    {
        // For Testing Purposes Load the Test Level on Start
        // To be removed once main menu and first real level is implemented
        Load("TestLevel");
    }

    private void Update()
    {
        // For testing level change
        Keyboard keyboard = InputSystem.GetDevice<Keyboard>();

        if (keyboard.nKey.wasPressedThisFrame)
        {
            if (currentLevel.name == "TestLevel")
                Load("TestLevel2");
            else if (currentLevel.name == "TestLevel2")
                Load("TestLevel");
        }
    }

    public void Load(string levelName)
    {
        GameObject loadedLevelObject = Instantiate(
            AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Levels/" + levelName + ".prefab")
        );
        Level loadedLevel = loadedLevelObject.GetComponent<Level>();
        loadedLevel.Load();
        loadedLevel.transform.parent = grid;
        loadedLevel.transform.position = loadedLevel.transform.parent.position;

        // Unload currentLevel if there is any
        if (currentLevel != null)
            Destroy(currentLevel.gameObject);

        currentLevel = loadedLevel;
        OnLoaded?.Invoke(loadedLevel);
    }

    public void Load(Level level)
    {
        // Instantiate level prefab
        GameObject loadedLevelObject = Instantiate(levelPrefab);
        loadedLevelObject.name = levelPrefab.name;
        // Get the Level component
        Level loadedLevel = loadedLevelObject.GetComponent<Level>();

        Level loadedLevel = loadedLevelObject.GetComponent<Level>();
        loadedLevel.Load();
        loadedLevel.transform.parent = grid;
        loadedLevel.transform.position = loadedLevel.transform.parent.position;

        // Unload currentLevel if there is any
        if (currentLevel != null)
            Destroy(currentLevel.gameObject);

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
        newLevel.transform.position = newLevel.transform.parent.position;
    }
}

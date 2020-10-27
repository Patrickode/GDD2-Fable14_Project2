using System;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level startLevel = null;

    public static Level CurrentLevel { get; private set; }
    public static Vector3 GridOffset { get; private set; }

    public static Action<Level> OnLoaded;

    /// <summary>
    /// Invoke to load a level by its prefab; if null, defaults to reloading the current level
    /// </summary>
    public static Action<Level> LoadLevelByPrefab;

    private bool firstLoad = true;

    private void Awake()
    {
        GridOffset = transform.position;

        LoadLevelByPrefab += OnLoadByPrefab;
    }
    private void OnDestroy()
    {
        LoadLevelByPrefab -= OnLoadByPrefab;
    }
    private void OnLoadByPrefab(Level lvl)
    {
        if (lvl) { Load(lvl); }
        else { Load(CurrentLevel.gameObject); }
    }

    private void Start()
    {
        if (startLevel)
        {
            Load(startLevel);
            firstLoad = false;
        }
        else
        {
            Debug.LogError("LevelManager: No start level was assigned. The game needs a level to start with.");
        }
    }

    public void Load(GameObject levelObj)
    {
        StartCoroutine(HandleLoadLogistics(levelObj));
    }

    // Loads a level by directly sending a reference to its prefab
    public void Load(Level level)
    {
        StartCoroutine(HandleLoadLogistics(level.gameObject));
    }

    // Helper method to not repeat loading logistics in every Load overload
    // InstantiatesLoads the level asked, updates the CurrentLevel variable, and invokes the OnLoaded event
    private IEnumerator HandleLoadLogistics(GameObject levelPrefab)
    {
        if (!firstLoad)
        {
            TransitionLoader.TransitionInOut?.Invoke();
            yield return new WaitForSecondsRealtime(TransitionLoader.OutLength);
        }

        // Instantiate level prefab
        GameObject loadedLevelObject = Instantiate(levelPrefab);
        loadedLevelObject.name = levelPrefab.name;
        // Get the Level component
        Level loadedLevel = loadedLevelObject.GetComponent<Level>();

        // Load the level and parent it to the Level Manager
        loadedLevel.Load();
        loadedLevel.transform.parent = transform;
        loadedLevel.transform.position = transform.position;

        // Current Level logistics
        // Unload currentLevel if there is any
        if (CurrentLevel != null)
            Destroy(CurrentLevel.gameObject);
        // Set the new Current Level
        CurrentLevel = loadedLevel;

        // Call the loaded event
        LevelManager.OnLoaded?.Invoke(loadedLevel);
    }
}

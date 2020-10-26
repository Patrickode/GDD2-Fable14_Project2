#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class DevTools : MonoBehaviour
{
    // Helper UI utility that creates a new blank level
    [MenuItem("Dev Tools/Create New/Level")]
    private static void CreateNewLevel()
    {
        // Finds the prefab for a new blank level (DO NOT DELETE NewLevel.prefab, it is important for this function)
        GameObject newLevelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/NewLevel.prefab");
        // Actually instantiates the level object in the scene
        GameObject newLevel = Instantiate(newLevelPrefab, Vector2.zero, Quaternion.identity);
        newLevel.name = "New Level";
        // Parent level to the grid
        Grid grid = GameObject.FindObjectOfType<Grid>();
        newLevel.transform.parent = grid.transform;
    }
}
#endif
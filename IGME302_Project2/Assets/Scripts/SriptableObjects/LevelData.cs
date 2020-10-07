using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string description;
}
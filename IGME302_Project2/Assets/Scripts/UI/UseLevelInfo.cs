using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseLevelInfo : MonoBehaviour
{
    [Tooltip("Where the level info should go. Will be the TMP component of this object, more often that not.")]
    [SerializeField] private TextMeshProUGUI levelInfoDestination = null;
    [Tooltip("If this is a header, the level name will be gotten. If it's not, the description will be gotten.")]
    [SerializeField] private bool isHeader = false;

    private void Awake()
    {
        LevelManager.OnLoaded += PopulateWithLevelInfo;
    }
    private void OnDestroy()
    {
        LevelManager.OnLoaded -= PopulateWithLevelInfo;
    }

    private void Start()
    {
        PopulateWithLevelInfo(LevelManager.CurrentLevel);
    }

    private void PopulateWithLevelInfo(Level levelInfoSource)
    {
        if (!levelInfoSource) { return; }

        //If the destination is a header, get the level name. Otherwise, get the level description.
        levelInfoDestination.text = isHeader ? levelInfoSource.levelName : levelInfoSource.description;
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour
{
    [SerializeField]
    public LevelData levelData;

    public Tilemap floor;
    public Tilemap colliders;
    public Tilemap ceiling;

    public Action OnLoad;

    public void Awake()
    {
        OnLoad += SetLevelTilemap;
    }

    public void Load()
    {
        OnLoad?.Invoke();
    }

    // Automatically sets level tilemaps according to objects in Hierarchy
    private void SetLevelTilemap()
    {
        List<Transform> children = transform.Cast<Transform>().ToList();
        if (floor == null)
            floor = children.Find(child => child.CompareTag("FloorTilemap"))?.GetComponent<Tilemap>();
        if (colliders == null)
            colliders = children.Find(child => child.CompareTag("ColliderTilemap"))?.GetComponent<Tilemap>();
        if (ceiling == null)
        {
            ceiling = children.Find(child => child.CompareTag("CeilingTilemap"))?.GetComponent<Tilemap>();
            Debug.Log(ceiling);
        }
    }
}


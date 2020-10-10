using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour
{
    // Text that would play out at the beginning of each level
    // As flavor text/introduction
    public string levelName;
    public string description;

    public Tilemap floor;
    public Tilemap colliders;
    public Tilemap ceiling;

    public Vector2Int spawnPoint;
    public Vector2Int goal;

    public Level nextLevel;

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
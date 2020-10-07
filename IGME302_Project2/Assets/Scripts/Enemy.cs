using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TargetFollower))]
public class Enemy : MonoBehaviour, IMovable
{
    [SerializeField]
    private Tilemap floor = null;
    [SerializeField]
    private Tilemap colliders = null;
    [SerializeField]
    public EnemyData enemyData;

    public Action OnAction;

    private TilemapMovementController tilemapMover = null;
    private SpriteRenderer spriteRenderer;

    [ExecuteInEditMode]
    void Start()
    {
        if (enemyData.sprite != null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = enemyData.sprite;
        }
            
    }

    void Awake()
    {
        // tilemapMover = new TilemapMovementController(floor, colliders);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 displacement)
    {
        throw new NotImplementedException();
    }

    public void MoveTo(Vector2 position)
    {
        throw new NotImplementedException();
    }
}

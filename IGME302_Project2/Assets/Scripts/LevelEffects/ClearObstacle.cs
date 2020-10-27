using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClearObstacle : LevelEffect
{
    [SerializeField]
    private List<Vector2Int> colliderPositions = new List<Vector2Int>();
    [SerializeField]
    private SpriteRenderer spriteRend = null;
    [SerializeField]
    private Sprite activateSprite = null;

    private Tilemap Colliders => LevelManager.CurrentLevel.colliders;

    public override void ActivateEffect()
    {
        if (activateSprite) { spriteRend.sprite = activateSprite; }
        RemoveColliders();
    }

    private void RemoveColliders()
    {
        foreach (Vector2Int position in colliderPositions)
        {
            // Set each tile at the position to null to clear them
            Colliders.SetTile((Vector3Int)position, null);
        }
    }
}

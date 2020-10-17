using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2Int ToVector2Int(this Vector2 v)
    {
        return new Vector2Int((int)v.x, (int)v.y);
    }
}
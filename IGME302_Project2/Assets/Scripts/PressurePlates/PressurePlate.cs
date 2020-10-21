using System;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Action OnActivate;

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player)
        {
            if (player.Position == transform.position.ToVector2().ToVector2Int())
                OnActivate?.Invoke();
        }
    }
}

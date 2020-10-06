﻿using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turnCount { get; private set; }
    Action OnTurnEnd;

    [SerializeField]
    private Player player;

    void Start()
    {
        turnCount = 0;
        player.OnMove += () => OnTurnEnd?.Invoke();
        OnTurnEnd += IncreaseTurn;
    }

    private void IncreaseTurn()
    {
        turnCount++;
    }

    private void ResetTurns()
    {
        turnCount = 0;
    }
}

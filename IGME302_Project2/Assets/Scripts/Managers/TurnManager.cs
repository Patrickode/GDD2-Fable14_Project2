using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turnCount { get; private set; }
    public static Action OnTurnEnd;

    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private Player player;

    void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>();
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();

    }

    private void OnEnable()
    {
        player.OnMove += IncreaseTurn;
        LevelManager.OnLoaded += ResetTurns;
    }

    private void OnDisable()
    {
        player.OnMove -= IncreaseTurn;
        LevelManager.OnLoaded -= ResetTurns;
    }

    private void IncreaseTurn()
    {
        turnCount++;
        OnTurnEnd?.Invoke();
    }

    private void ResetTurns(Level levelLoaded)
    {
        turnCount = 0;
    }
}
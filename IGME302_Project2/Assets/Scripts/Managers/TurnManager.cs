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

    private void Start()
    {
        LevelManager.OnLoaded += ResetTurns;
        player.OnMove += IncreaseTurn;
        Player.OnAbility += IncreaseTurn;
    }

    private void OnDestroy()
    {
        LevelManager.OnLoaded -= ResetTurns;
        player.OnMove -= IncreaseTurn;
        Player.OnAbility -= IncreaseTurn;
    }

    private void IncreaseTurn(Vector3 a, Vector3 b) { IncreaseTurn(); }
    private void IncreaseTurn(Ability a, int b) { IncreaseTurn(); }
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
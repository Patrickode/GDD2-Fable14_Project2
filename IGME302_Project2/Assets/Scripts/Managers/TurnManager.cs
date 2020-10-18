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
        LevelManager.OnLoaded += ResetTurns;
        player.OnMoveControllerSetup += SetIncreaseTurnCallback;
    }

    private void OnDisable()
    {
        LevelManager.OnLoaded -= ResetTurns;
        player.OnMoveControllerSetup -= SetIncreaseTurnCallback;
        UnsetIncreaseTurnCallback();
    }

    private void SetIncreaseTurnCallback()
    {
        player.OnMove += IncreaseTurn;
    }

    private void UnsetIncreaseTurnCallback()
    {
        player.OnMove -= IncreaseTurn;
    }

    private void IncreaseTurn(Vector3 oldPosition, Vector3 newPosition)
    {
        turnCount++;
        OnTurnEnd?.Invoke();
    }

    private void ResetTurns(Level levelLoaded)
    {
        turnCount = 0;
    }
}
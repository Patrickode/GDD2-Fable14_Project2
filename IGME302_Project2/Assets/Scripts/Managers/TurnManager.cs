using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turnCount { get; private set; }
    Action OnTurnEnd;

    [SerializeField]
    private Player player;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

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
    }

    private void ResetTurns()
    {
        turnCount = 0;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Action OnActivated;

    private Player player;
    private List<LevelEffect> levelEffects;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        levelEffects = GetComponents<LevelEffect>().ToList();
    }

    private void OnEnable()
    {
        player.OnMove += CheckPlayerOnPlate;
        OnActivated += TriggerLevelEffects;
    }

    private void OnDisable()
    {
        player.OnMove -= CheckPlayerOnPlate;
        OnActivated -= TriggerLevelEffects;
    }

    private void CheckPlayerOnPlate(Vector3 oldPosition, Vector3 newPosition)
    {
        if (newPosition == transform.position)
            OnActivated?.Invoke();
    }

    private void TriggerLevelEffects()
    {
        foreach (LevelEffect effect in levelEffects)
            effect.ActivateEffect();
    }
}
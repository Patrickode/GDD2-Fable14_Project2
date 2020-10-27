using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Action OnActivated;

    private Player player;
    private List<LevelEffect> levelEffects;

    [SerializeField]
    private AudioClip activateSound = null;

    private SoundEffectsManager soundEffectsManager;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        levelEffects = GetComponents<LevelEffect>().ToList();

        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
    }

    private void OnEnable()
    {
        player.OnMove += CheckPlayerOnPlate;
        OnActivated += TriggerLevelEffects;
        OnActivated += PlayActivateSound;
    }

    private void OnDisable()
    {
        player.OnMove -= CheckPlayerOnPlate;
        OnActivated -= TriggerLevelEffects;
        OnActivated -= PlayActivateSound;
    }

    private void CheckPlayerOnPlate(Vector3 oldPosition, Vector3 newPosition)
    {
        if (Vector3.Distance(transform.position + LevelManager.GridOffset, newPosition) < 0.6f)
            OnActivated?.Invoke();
    }

    private void TriggerLevelEffects()
    {
        foreach (LevelEffect effect in levelEffects)
            effect.ActivateEffect();
    }

    // Button by 13F_Panska_Koprivikova_Klara at freesound.org
    // https://freesound.org/people/13F_Panska_Koprivikova_Klara/sounds/378301/
    private void PlayActivateSound()
    {
        soundEffectsManager.PlaySound(activateSound);
    }
}
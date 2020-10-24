using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SetInitialSoundEffectsMuteValue : MonoBehaviour
{
    private AudioSource soundEffectsManagerPrefabAudioSource;
    private Toggle checkbox;

    void Start()
    {
        soundEffectsManagerPrefabAudioSource = FindObjectOfType<SoundEffectsManager>().soundEffectsManagerPrefab.GetComponent<AudioSource>();
        checkbox = GetComponent<Toggle>();
        checkbox.isOn = soundEffectsManagerPrefabAudioSource.mute;
    }
}

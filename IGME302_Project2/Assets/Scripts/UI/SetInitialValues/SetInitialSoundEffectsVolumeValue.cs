using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SetInitialSoundEffectsVolumeValue : MonoBehaviour
{
    private AudioSource soundEffectsManagerPrefabAudioSource;
    private Slider volumeSlider;
    void Start()
    {
        soundEffectsManagerPrefabAudioSource = FindObjectOfType<SoundEffectsManager>().soundEffectsManagerPrefab.GetComponent<AudioSource>();
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = soundEffectsManagerPrefabAudioSource.volume;
    }
}

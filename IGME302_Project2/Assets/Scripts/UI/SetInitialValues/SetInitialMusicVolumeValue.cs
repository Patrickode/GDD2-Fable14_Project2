using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SetInitialMusicVolumeValue : MonoBehaviour
{
    private AudioSource musicManagerPrefabAudioSource;
    private Slider volumeSlider;
    void Start()
    {
        musicManagerPrefabAudioSource = FindObjectOfType<MusicManager>().musicManagerPrefab.GetComponent<AudioSource>();
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = musicManagerPrefabAudioSource.volume;
    }
}

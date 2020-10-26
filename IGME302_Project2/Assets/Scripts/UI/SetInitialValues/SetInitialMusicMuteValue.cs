using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SetInitialMusicMuteValue : MonoBehaviour
{
    private AudioSource musicManagerPrefabAudioSource;
    private Toggle checkbox;

    private void Start()
    {
        musicManagerPrefabAudioSource = FindObjectOfType<MusicManager>().musicManagerPrefab.GetComponent<AudioSource>();
        checkbox = GetComponent<Toggle>();
        checkbox.isOn = musicManagerPrefabAudioSource.mute;
    }
}

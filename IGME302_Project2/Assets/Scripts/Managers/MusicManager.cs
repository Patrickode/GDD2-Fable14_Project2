using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject musicManagerPrefab;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
    }

    public void SetMute(bool mute)
    {
        audioSource.mute = mute;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsManager : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject soundEffectsManagerPrefab;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
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

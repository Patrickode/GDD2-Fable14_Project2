using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    void PlaySound(string soundName)
    {
        audioSource.PlayOneShot(AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/SoundEffects/" + soundName));
    }
}

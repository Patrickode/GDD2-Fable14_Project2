using UnityEngine;

public class SliderMethods : MonoBehaviour
{
    [SerializeField]
    private MusicManager musicManager;
    [SerializeField]
    private SoundEffectsManager soundEffectsManager;

    private AudioSource musicManagerPrefabAudioSource;
    private AudioSource soundEffectsManagerPrefabAudioSource;

    private void Awake()
    {
        if (!musicManager)
            musicManager = FindObjectOfType<MusicManager>();
        if (!soundEffectsManager)
            soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
    }

    private void Start()
    {
        if (musicManager)
            musicManagerPrefabAudioSource = musicManager.musicManagerPrefab.GetComponent<AudioSource>();
        if (soundEffectsManager)
            soundEffectsManagerPrefabAudioSource = soundEffectsManager.soundEffectsManagerPrefab.GetComponent<AudioSource>();
    }

    public void SetMusicVolume(float volume)
    {
        musicManager.SetVolume(volume);
        musicManagerPrefabAudioSource.volume = volume;
    }

    public void SetSoundEffectVolume(float volume)
    {
        soundEffectsManager.SetVolume(volume);
        soundEffectsManagerPrefabAudioSource.volume = volume;
    }
}

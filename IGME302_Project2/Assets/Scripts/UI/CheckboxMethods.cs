using UnityEngine;
using UnityEngine.InputSystem;

public class CheckboxMethods : MonoBehaviour
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

    public void MuteMusic(bool mute)
    {
        musicManager.SetMute(mute);
        musicManagerPrefabAudioSource.mute = mute;
    }

    public void MuteSoundEffects(bool mute)
    {
        soundEffectsManager.SetMute(mute);
        soundEffectsManagerPrefabAudioSource.mute = mute;
    }

    public void ToggleMuteMusic()
    {
        musicManager.ToggleMute();
        musicManagerPrefabAudioSource.mute = !musicManagerPrefabAudioSource.mute;
    }

    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            ToggleMuteMusic();
        }
    }
}

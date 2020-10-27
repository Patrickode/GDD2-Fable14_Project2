using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerSoundManager : MonoBehaviour
{
    private SoundEffectsManager soundEffectsManager;
    private Player player;

    [SerializeField]
    private AudioClip walkSound = null;
    [SerializeField]
    private AudioClip bowShootSound = null;
    [SerializeField]
    private AudioClip leapAbilitySound = null;
    [SerializeField]
    private AudioClip bumpSound = null;
    [SerializeField]
    private AudioClip deathSound = null;

    public AudioClip aimOnSound;
    public AudioClip aimOffSound;

    private void Awake()
    {
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        player.TileMoveController.bumpSound = bumpSound;

        player.OnMove += PlayWalkSound;
        Player.OnAbility += PlayBowShootSound;
        Player.OnAbility += PlayLeapAbilitySound;
        player.OnDeath += PlayDeathSound;
    }

    private void Destroy()
    {
        player.OnMove -= PlayWalkSound;
        Player.OnAbility -= PlayBowShootSound;
        Player.OnAbility -= PlayLeapAbilitySound;
        player.OnDeath -= PlayDeathSound;
    }

    // Bow.wav by Hanbaal at freesound.org
    // https://freesound.org/people/Hanbaal/sounds/178872/
    private void PlayBowShootSound(Ability ability, int index)
    {
        if (ability is ArrowAbility)
            soundEffectsManager.PlaySound(bowShootSound);
    }

    // Wet Spell shoot by Bertsz at freesound.org
    // https://freesound.org/people/Bertsz/sounds/524305/
    private void PlayLeapAbilitySound(Ability ability, int index)
    {
        if (ability is LeapAbility)
            soundEffectsManager.PlaySound(leapAbilitySound);
    }

    private void PlayWalkSound(Vector3 oldPosition, Vector3 newPosition)
    {
        soundEffectsManager.PlaySound(walkSound);
    }

    private void PlayDeathSound()
    {
        soundEffectsManager.PlaySound(deathSound);
    }
}

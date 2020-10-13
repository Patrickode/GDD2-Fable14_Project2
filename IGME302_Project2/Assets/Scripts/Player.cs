using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetFollower))]
public class Player : MovingEntity
{
    private PlayerControls controls;
    private List<Ability> abilities;

    /// <summary>
    /// The ability the player is currently aiming. Null if not aiming an ability.
    /// </summary>
    private Ability aimingAbility = null;

    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }

    protected override void Awake()
    {
        base.Awake();

        controls = new PlayerControls();
        abilities = new List<Ability>();

        //--- Events ---//

        //When movement input is received, use that input to move or activate an ability in that direction
        controls.Movement.Move.performed += ctx => ProcessMoveInput(ctx.ReadValue<Vector2>());
        //When bottom row keys are pressed, try to activate the corresponding ability.
        controls.Movement.Ability0.performed += _ => TryActivateAbility(0);
        controls.Movement.Ability1.performed += _ => TryActivateAbility(1);
        controls.Movement.Ability2.performed += _ => TryActivateAbility(2);
        controls.Movement.Ability3.performed += _ => TryActivateAbility(3);
        controls.Movement.Ability4.performed += _ => TryActivateAbility(4);
        controls.Movement.Ability5.performed += _ => TryActivateAbility(5);
        controls.Movement.Ability6.performed += _ => TryActivateAbility(6);
    }
    private void OnDestroy()
    {
        //Unsubscribe from all events because the player is being destroyed
        controls.Movement.Move.performed -= ctx => ProcessMoveInput(ctx.ReadValue<Vector2>());
        controls.Movement.Ability0.performed -= _ => TryActivateAbility(0);
        controls.Movement.Ability1.performed -= _ => TryActivateAbility(1);
        controls.Movement.Ability2.performed -= _ => TryActivateAbility(2);
        controls.Movement.Ability3.performed -= _ => TryActivateAbility(3);
        controls.Movement.Ability4.performed -= _ => TryActivateAbility(4);
        controls.Movement.Ability5.performed -= _ => TryActivateAbility(5);
        controls.Movement.Ability6.performed -= _ => TryActivateAbility(6);
    }

    /// <summary>
    /// Move if not aiming, and activate an ability in a direction if aiming.
    /// </summary>
    /// <param name="moveInput">The direction to move or activate an ability in.</param>
    private void ProcessMoveInput(Vector2 moveInput)
    {
        //If not aiming an ability, move as normal.
        if (!aimingAbility)
        {
            Move(moveInput);
        }
        //Otherwise, activate the ability we're aiming in the direction of move input.
        //Set it to null afterwards because we're not aiming it anymore.
        else
        {
            aimingAbility.Activate(this, moveInput.ToVector2Int());
            aimingAbility = null;
        }
    }

    private void TryActivateAbility(int indexToActivate)
    {
        //If the given index is out of range, bail out.
        if (indexToActivate < 0 || indexToActivate >= abilities.Count) { return; }

        //Get the ability to activate from the given index, and bail out if it has no uses left.
        Ability abilityToActivate = abilities[indexToActivate];
        if (abilityToActivate.usagesLeft <= 0) { Debug.Log("This ability has no uses left."); return; }

        //If we're already aiming this ability, cancel aiming.
        if (abilityToActivate.Equals(aimingAbility))
        {
            Debug.Log("Cancelled aiming.");
            aimingAbility = null;
        }
        //Otherwise, start aiming the ability if it's aimable,
        else if (abilities[indexToActivate].isAimable)
        {
            Debug.Log("Aiming...");
            aimingAbility = abilities[indexToActivate];
        }
        //or just activate it if it's not.
        else
        {
            abilityToActivate.Activate(this);
        }
    }

    /// <summary>
    /// Resets the player's abilities list and sets it equal to the level's default ability set
    /// </summary>
    /// <param name="instances">The ability instance array to set the player's ability list to.</param>
    public void SetAbilities(AbilityInstance[] instances)
    {
        //Reset the abilities list
        abilities.Clear();
        //Add all of the abilities from the instance array, and set each one's usages accordingly
        foreach (AbilityInstance instance in instances)
        {
            abilities.Add(instance.ability);
            abilities[abilities.Count - 1].usagesLeft = instance.usages;
        }
    }
}
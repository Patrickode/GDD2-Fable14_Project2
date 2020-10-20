using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    /// <summary>
    /// Whether this ability needs to be aimed or not.
    /// </summary>
    [HideInInspector] public bool isAimable;
    /// <summary>
    /// How many more times this ability can be used.
    /// </summary>
    [HideInInspector] public int usagesLeft;
    /// <summary>
    /// The icon that represents this ability.
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// Perform whatever logic this ability does.
    /// </summary>
    /// <param name="user">The entity that activated this ability.</param>
    /// <param name="direction">The direction to activate this ability in, if it's aimable.</param>
    public abstract void Activate(MovingEntity user, Vector2Int direction = default);

    /// <summary>
    /// Initialize this ability. Sets whether the ability is aimable or not.
    /// </summary>
    public abstract void Init();
}
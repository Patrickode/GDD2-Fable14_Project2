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
    /// Activate this ability and reduce its usages by one.
    /// </summary>
    /// <param name="direction">The direction to activate in, if this ability is aimable.</param>
    public virtual void Activate(Vector2Int direction = default) { usagesLeft--; }
}
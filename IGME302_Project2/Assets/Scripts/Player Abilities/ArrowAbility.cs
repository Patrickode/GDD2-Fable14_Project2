using UnityEngine;

public class ArrowAbility : Ability
{
    [SerializeField] private GameObject arrowPrefab = null;
    [Tooltip("How far from the player the arrow should spawn. 0 = On top of player. 1 = 1 unit away from " +
        "player in the direction activated.")]
    [SerializeField] private float arrowStartOffset = 0.5f;

    public override void Init() { isAimable = true; }

    public override void Activate(MovingEntity user, Vector2Int direction = default)
    {
        Vector2 arrowDir = (Vector2)direction * arrowStartOffset;

        Instantiate(
            arrowPrefab,
            user.transform.position + (Vector3)arrowDir,
            Quaternion.LookRotation(Vector3.forward, arrowDir)
        );

        usagesLeft--;
    }
}

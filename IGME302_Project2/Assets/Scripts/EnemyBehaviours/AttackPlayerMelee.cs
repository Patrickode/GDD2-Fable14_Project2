using UnityEngine;

public class AttackPlayerMelee : EnemyBehaviour
{
    [SerializeField]
    private Player player;

    private Vector2Int enemyPosition;
    private Vector2Int enemyPreviousPosition;

    protected override void Awake()
    {
        base.Awake();

        // Automatically set player if not set
        if (!player)
            player = FindObjectOfType<Player>();
    }

    public override void Behave()
    {
        if (!EnemyMovedThisTurn() && OnMeleeRange())
        {
            if (player)
                // Kill the player
                player.OnDeath?.Invoke();
        }
    }

    private bool EnemyMovedThisTurn()
    {
        enemyPreviousPosition = enemyPosition;
        enemyPosition = enemy.Position;
        return enemyPosition != enemyPreviousPosition;
    }

    private bool OnMeleeRange()
    {
        // Distance to the player is equal to 1?
        return Mathf.CeilToInt(Vector2Int.Distance(enemy.TileMoveController.Position, player.TileMoveController.Position)) == 1;
    }
}
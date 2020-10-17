using UnityEngine;

[RequireComponent(typeof(Enemy))]
public abstract class EnemyBehaviour : MonoBehaviour
{
    protected Enemy enemyScript;

    protected virtual void Awake()
    {
        // Automatically set enemy if not set
        if (!enemyScript)
            enemyScript = GetComponent<Enemy>();
    }
    public abstract void Behave();
}

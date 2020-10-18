using UnityEngine;
using System.Linq;

public class TargetFollower : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Transform Target
    {
        get => target;
        set
        {
            OnTargetChanged?.Invoke(Target, value);
            target = value;
        }
    }
    public float followSpeed = 10f;

    /// <summary>
    /// Event that fires whenever the target is changed.
    /// First Transform is the old target.
    /// Second Transform is the new target.
    /// </summary>
    public Action<Transform, Transform> OnTargetChanged;

    void Update()
    {
        if (target != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
            newPosition.z = transform.position.z;
            transform.position = newPosition; 
        }
    }
}

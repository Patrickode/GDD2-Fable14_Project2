using System;
using UnityEngine;

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
        // Move towards the target at all times if there is any
        if (Target)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, Target.position, followSpeed * Time.deltaTime);
            // Follower keeps its z position
            newPosition.z = transform.position.z;
            transform.position = newPosition; 
        }
    }

    private void OnDestroy()
    {
        if (Target)
            Destroy(Target.gameObject);
    }
}

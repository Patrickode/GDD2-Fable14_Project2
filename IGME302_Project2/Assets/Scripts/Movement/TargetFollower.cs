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
            target = value;
            OnTargetChanged?.Invoke();
        }
    }
    public float followSpeed = 10f;

    [SerializeField]
    private GameObject targetContainer;

    public Action OnTargetChanged;

    void Awake()
    {
        // Set the target container automatically if not set
        if (!targetContainer)
            targetContainer = GameObject.FindGameObjectWithTag("Target Container");

        // If object is meant to follow itself, create a target for it
        if (Target == transform || Target == null)
        {
            GameObject newTarget = new GameObject();
            newTarget.transform.position = transform.position;
            newTarget.name = $"{this.name}Target";

            // Organize it into the Target Container
            if (targetContainer)
                newTarget.transform.parent = targetContainer.transform;

            Target = newTarget.transform;
        }
    }

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

using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 10f;

    [SerializeField]
    private GameObject targetContainer;

    void Awake()
    {
        // Set the target container automatically if not set
        if (!targetContainer)
            targetContainer = GameObject.FindGameObjectWithTag("Target Container");

        // If object is meant to follow itself, create a target for it
        if (target == transform)
        {
            GameObject newTarget = Instantiate(new GameObject());
            newTarget.name = $"{this.name}Target";

            // Organize it into the Target Container
            if (targetContainer)
                newTarget.transform.parent = targetContainer.transform;

            target = newTarget.transform;
        }
    }

    void Update()
    {
        // Move towards the target at all times if there is any
        if (target)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
            // Follower keeps its z position
            newPosition.z = transform.position.z;
            transform.position = newPosition; 
        }
    }
}

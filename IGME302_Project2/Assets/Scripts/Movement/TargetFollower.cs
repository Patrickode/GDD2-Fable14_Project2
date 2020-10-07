using UnityEngine;
using System.Linq;

public class TargetFollower : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float followSpeed = 10f;

    void Start()
    {
        // Set target automatically if not set in the Inspector
        if (target == null)
        {
            // Grab the first object tagged as "Target"
            target = transform.Cast<Transform>().ToList().Find(t => t.tag == "FollowTarget");
        }
        
        // Change the target's parent so it does not shift with its follower.
        // Parented to TargetManager in case targets should be manipulated in the future
        if (target != null)
        {
            target.parent = null;

            Transform targetManager = GameObject.Find("TargetManager").transform;
            if (targetManager != null)
                target.parent = targetManager;
        }
        else
        {
            Debug.LogError("Dev Error: No target attached to {" + this + "} it may cause problems in related movement scripts.");
        }
    }

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

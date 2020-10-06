using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float followSpeed = 10f;

    void Start()
    {
        target.parent = null;
    }

    void Update()
    {
        if (target != null)
            transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
    }
}

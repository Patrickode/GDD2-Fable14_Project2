using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Tooltip("How fast the arrow moves in units per second.")]
    [SerializeField] private float arrowSpeed = 2.0f;

    private void Start() { Destroy(gameObject, 3); }

    void Update()
    {
        transform.Translate(transform.up * arrowSpeed * Time.deltaTime, Space.World);
    }
}

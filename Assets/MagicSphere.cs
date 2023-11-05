using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour
{
    Rigidbody sphere;
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Rigidbody rb = collision.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnTriggerExit(Collider collision)
    {
        Rigidbody rb = collision.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}

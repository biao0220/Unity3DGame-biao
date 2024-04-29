using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float laserSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
        GetComponentInChildren<Rigidbody>().velocity = transform.forward * laserSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public Rigidbody rb;
    public Transform forward ;
    Vector3 v;

    void Start()
    {
        v = new Vector3(forward.position.x - transform.position.x, forward.position.y - transform.position.y, forward.position.z - transform.position.z);
        Destroy(gameObject, 5);
    }

    void FixedUpdate () {
        rb.AddForce(1000f * v);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpaceObject"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }
    }
}

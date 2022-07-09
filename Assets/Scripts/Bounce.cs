using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce = 10.0f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Vector3 norm = other.contacts[0].normal;
            Vector3 vel = new Vector3(norm.x, 0f, norm.z);
            other.rigidbody.AddForce(vel.normalized * bounce, ForceMode.VelocityChange);
        }
    }
}

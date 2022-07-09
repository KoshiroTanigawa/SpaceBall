using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 15f;

    // Update is called once per frame
    void FixedUpdate()
    {
        var velox = speed * Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody>().velocity = new Vector3(velox, 0f, 0f);
    }
}

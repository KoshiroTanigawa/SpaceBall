using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorBlue : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}

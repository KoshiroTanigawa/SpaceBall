using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public int scorepoint = 10;

    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball") 
        {
            Destroy(gameObject, 0.2f);
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().AddScore(scorepoint);
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(gameObject, 0.2f);
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().AddScore(scorepoint);
        }
    }
}

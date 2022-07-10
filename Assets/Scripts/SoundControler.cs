using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;
    public AudioClip sound04;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject gm = GameObject.Find("GameManager");
        if (gm.GetComponent<GameManager>().IsInGame())
            if (other.gameObject.tag == "Obstacle")
            {
                audio.PlayOneShot(sound01);
            }

            else if (other.gameObject.tag == "Bumper")
            {
                audio.PlayOneShot(sound02);
            }

            else if (other.gameObject.tag == "Var")
            {
                audio.PlayOneShot(sound03);
            }

            else if (other.gameObject.tag == "ResetWall")
            {
                audio.PlayOneShot(sound04);
            }
    }
}

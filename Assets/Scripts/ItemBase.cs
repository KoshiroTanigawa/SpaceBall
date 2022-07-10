using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip _sound = default;

    void Start()
    {
        _audio = gameObject.AddComponent<AudioSource>();
    }

    public abstract void Effect();

    void OnTriggerEnter(Collider other)
    {
        GameObject gm = GameObject.Find("GameManager");

        if (gm.GetComponent<GameManager>().IsInGame())
        {
            if (other.gameObject.tag == "Ball")
            {
                GetComponent<Renderer>().material.color = Color.red;
                _audio.PlayOneShot(_sound);
                Destroy(gameObject, 0.3f);
                Effect();
            }
        }
    }
}

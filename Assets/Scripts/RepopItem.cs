using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepopItem : MonoBehaviour
{
    [SerializeField] GameObject _gate;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Invoke("Repop", 5f);
        }
    }

    public void Repop()
    {
        GameObject newGate = Instantiate(_gate, gameObject.transform);
        newGate.name = _gate.name;
    }
}

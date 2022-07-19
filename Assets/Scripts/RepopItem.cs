using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepopItem : MonoBehaviour
{
    [SerializeField] 
    GameObject _gate1;
    [SerializeField]
    GameObject _gate2;
    [SerializeField]
    GameObject _gate3;

    [SerializeField]
    Transform _pos1;
    [SerializeField]
    Transform _pos2;
    [SerializeField]
    Transform _pos3;

    void Update()
    {
        if (_gate1 == null)
        {
            Debug.Log("5秒後に_gate1がポップします");
            Invoke("Repop1", 5f);
        }

        if (_gate2 == null)
        {
            Debug.Log("5秒後に_gate2がポップします");
            Invoke("Repop2", 5f);
        }

        if (_gate3 == null)
        {
            Debug.Log("5秒後に_gate3がポップします");
            Invoke("Repop3", 5f);
        }
    }

    public void Repop1()
    {
        GameObject newGate = Instantiate(_gate1, _pos1);
        newGate.name = _gate1.name;
    }
    public void Repop2()
    {
        GameObject newGate = Instantiate(_gate2, _pos2);
        newGate.name = _gate2.name;
    }
    public void Repop3()
    {
        GameObject newGate = Instantiate(_gate3, _pos3);
        newGate.name = _gate3.name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBall : ItemBase
{
    [SerializeField] GameObject _ballPrefab2;
    //Transform _pos;

    public override void Effect()
    {
        //_pos = GetComponent<Transform>();
        GameObject newBall = Instantiate(_ballPrefab2);

        newBall.name = _ballPrefab2.name;
        Rigidbody _rb = newBall.GetComponent<Rigidbody>();

        _rb.AddForce(0, 1f, 0);
    }
}

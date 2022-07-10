using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCubu : ItemBase
{
    public int _scorepoint = 10;

    public override void Effect()
    {
        GameObject gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().AddScore(_scorepoint);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : ItemBase
{
    public int scorepoint = 10;

    public override void Effect()
    {
        GameObject gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().AddScore(scorepoint);
    }
}

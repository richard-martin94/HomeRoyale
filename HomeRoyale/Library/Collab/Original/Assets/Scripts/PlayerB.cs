using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour {

    Vector3 positionB;
    Transport T = new Transport();

    private void Awake()
    {
        positionB = this.transform.position;
    }

    public Vector3 PositionB
    {
        get { return positionB; }
        set { positionB = value; }
    }



}

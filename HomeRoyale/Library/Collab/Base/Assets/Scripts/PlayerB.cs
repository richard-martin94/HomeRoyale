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

    private void FixedUpdate()
    {
        positionB = this.transform.position;

        if (Vector3.Distance(positionB, T.Position) < 11.5f)
        {
            GameObject.FindGameObjectWithTag("cameraB").SetActive(false);
        }
        else
        {
            GameObject.FindGameObjectWithTag("cameraB").SetActive(true);
        }
    }

}

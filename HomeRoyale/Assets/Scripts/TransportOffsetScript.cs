using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportOffsetScript : MonoBehaviour {

    Vector3 offset;

    Vector3 transportPos;

    void Awake ()
    {
        offset = transform.position - GameObject.FindGameObjectWithTag("Transport").transform.position;
    }

    void FixedUpdate()
    {
        transform.position = transportPos + offset;

        transportPos = GameObject.FindGameObjectWithTag("Transport").transform.position;


    }
}

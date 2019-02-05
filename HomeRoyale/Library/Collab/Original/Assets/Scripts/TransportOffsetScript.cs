using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportOffsetScript : MonoBehaviour {

    // 13.6f
    Vector3 offset;

    PlayerA pA = new PlayerA();
    PlayerB pB = new PlayerB();

    Transport T = new Transport();

    void Start ()
    {// sets the offset to the object that has this scripts position
        this.gameObject.SetActive(false);
       
        offset = transform.position - GameObject.FindGameObjectWithTag("Transport").transform.position;	
	}
	


}

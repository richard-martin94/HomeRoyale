using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float timeStamp;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour {

    public Vector3 Position;
    public Vector3 aGoal;
    public Vector3 bGoal;
    public Vector3 playerAPos;
    public Vector3 playerBPos;

    Rigidbody rb = new Rigidbody();

    public float disA;
    public float disB;

    public bool toPlayerA;
    public bool toPlayerB;

    public float step;

    void Start () 
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Position = gameObject.transform.position;
        aGoal = new Vector3(-24.55f, 1.3f, -.95f);
        bGoal = new Vector3(24.55f, 1.3f, -.95f);
        toPlayerA = false;
        toPlayerB = false;
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        Position = gameObject.transform.position;

        playerAPos = GameObject.FindGameObjectWithTag("PlayerA").transform.position;
        playerBPos = GameObject.FindGameObjectWithTag("PlayerB").transform.position;

        disA = Vector3.Distance(playerAPos, Position);
        disB = Vector3.Distance(playerBPos, Position);


        if(disA < 6 && disB > 6)
        {
            toPlayerA = true;
            toPlayerB = false;
        }
        else if(disB < 6 && disA > 6)
        {
            toPlayerB = true;
            toPlayerA = false;
        }

        if (toPlayerA && !toPlayerB)
        {
            step = 100 * Time.deltaTime;
            rb.AddForce((-Vector3.right * step));
        }
        else if(toPlayerB && !toPlayerA)
        {
            step = 100 * Time.deltaTime;
            rb.AddForce((Vector3.right * step));
        }else if(toPlayerA && toPlayerB)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }



    }
}

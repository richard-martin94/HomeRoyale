using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour {

    Vector3 positionB;
    Vector3 transportPos;

    Vector3 spawnPos;

    int health;

    public GameObject bullet;

    float timeStamp;

    GameObject camB;

    float disTransport;
    
    Rigidbody rb = new Rigidbody();
    float fallMult;
    float lowFallMult;
    float leftRight;
    int moveSpeed;


    private void Awake()
    {
        health = 100;
        camB = GameObject.FindWithTag("camB");
        fallMult = 2.5f;
        lowFallMult = 2f;
        moveSpeed = 350;
        spawnPos = this.transform.position;
        positionB = gameObject.transform.position;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (health <= 0)
        {
            transform.position = spawnPos;
            health = 100;
        }

        leftRight = Input.GetAxis("Player2_Horz");
        positionB = gameObject.transform.position;
        transportPos = GameObject.FindGameObjectWithTag("Transport").transform.position;

        disTransport = Vector3.Distance(positionB, transportPos);

        if (leftRight != 0.0f)
        {
            rb.AddForce(Vector3.right * leftRight * moveSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Player2_Jump") && rb.velocity.y == 0.0f)
        {
            rb.velocity += Vector3.up * 18;
        }

        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Player2_Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowFallMult - 1) * Time.deltaTime;
        }

        if(Input.GetButton("ShootB") && timeStamp <= Time.time)
        {
            Fire();
        }

        if (disTransport < 11.5f)
        {
            camB.SetActive(false);
        }
        if(disTransport > 11.5f)
        {
           camB.SetActive(true);
        }

    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            health -= 50;
        }
    }

    void Fire()
    {
        GameObject Clone = Instantiate(bullet, transform.position + new Vector3(-.5f, 1, 0), new Quaternion(0,90,0,1));
        Clone.GetComponent<Rigidbody>().velocity += Vector3.left * 60;
        timeStamp = Time.time + .5f;
    }

}

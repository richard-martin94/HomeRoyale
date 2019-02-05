using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour {

    Vector3 positionA;
    Vector3 transportPos;

    float disTransport;

    Vector3 spawnPos;

    GameObject camA;

    int health;

    public GameObject bullet;

    float timeStamp;

    Rigidbody rb = new Rigidbody();

    float fallMult;
    float lowFallMult;
    float leftRight;
    int moveSpeed;

    private void Awake()
    {
        spawnPos = this.transform.position;
        positionA = this.transform.position;
        health = 100;
        camA = GameObject.FindWithTag("camA");
        fallMult = 2.5f;
        lowFallMult = 2f;
        moveSpeed = 350;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(health <= 0)
        {
            transform.position = spawnPos;
            health = 100;
        }

        leftRight = Input.GetAxis("Player1_Horz");
        positionA = gameObject.transform.position;
        transportPos = GameObject.FindGameObjectWithTag("Transport").transform.position;

        disTransport = Vector3.Distance(positionA, transportPos);

        if (leftRight != 0.0f)
        {
            rb.AddForce(Vector3.right * leftRight * moveSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Player1_Jump") && rb.velocity.y == 0.0f)
        {
            rb.velocity += Vector3.up * 18;
        }

        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Player1_Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowFallMult - 1) * Time.deltaTime;
        }

        
        if (Input.GetButton("ShootA") && timeStamp <= Time.time)
        {
            Fire();
        }

        if (disTransport < 11.5f)
        {
            camA.SetActive(false);
        }
        if(disTransport > 11.5f )
        {
            camA.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Bullet")
        {
            health -= 50;
        }
    }

    void Fire()
    {
        GameObject Clone = Instantiate(bullet, transform.position + new Vector3(1, 1, 0), new Quaternion(0, 90, 0, 1));
        Clone.GetComponent<Rigidbody>().velocity += Vector3.right * 60;
        timeStamp = Time.time + .5f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Test : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public GameObject mirrorPlayer;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0, 0, -speed);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        //MirrorPlayer();

    }

    public void MirrorPlayer()
    {
        this.transform.position = mirrorPlayer.transform.position;
    }

}

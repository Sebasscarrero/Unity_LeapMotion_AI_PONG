using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Test : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -speed);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // WASD
        if (Input.GetKey("d"))
        {
            rb.AddForce(force * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-force * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, force * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -force * Time.deltaTime);
        }

        // Boost
        if (Input.GetKey("e"))
        {
            rb.AddForce(0, 0, force * 5 * Time.deltaTime);
        }

        // Flight
        if (Input.GetKey("q"))
        {
            rb.AddForce(0, force * 3 * Time.deltaTime, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -- DO NOT USE --
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: DO NOT USE, a basic controller thrown together so I test moving the player to the goal
/// Written by: Sammy Chan
/// ---------- 

public class basiccontroller : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back);
    }
}

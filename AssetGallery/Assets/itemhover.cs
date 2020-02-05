using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script to give object a hovering and spinning effect
/// How to use:
///     Create an 'Empty' object and have the 3D model be a child of the hierarchy
///     Attach the script to the 'Empty' object
///         otherwise, if attached to the 3d model itself it will look weird
/// Written by: Sammy Chan
/// ---------- 

public class itemhover : MonoBehaviour
{

    public bool rotates = true;

    private float originalY;
    private bool goingUp = true;
    private float offset = 0.9f;
    private float maxTop;
    private float maxBot;

    private void Start()
    {
        originalY = transform.position.y;
        maxTop = originalY + offset;
        maxBot = originalY - offset;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxTop)
        {
            goingUp = false;
        }
        else if (transform.position.y < maxBot)
        {
            goingUp = true;
        }

        if (goingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }

        if (rotates)
        {
            transform.RotateAround(transform.position, Vector3.up, 60 * Time.deltaTime);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemhover : MonoBehaviour
{

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
        transform.RotateAround(transform.position, Vector3.up, 60 * Time.deltaTime);
        
    }
}

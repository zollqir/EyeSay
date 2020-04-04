using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public float pSpeed = 0.5f;
    Vector3 pVelocity;
    public float rotateSpeed = 40;

    void Update()
    {
        /*
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;
        */
        pVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W)){
            pVelocity.z = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pVelocity.z = -1.0f;
        }
        transform.Translate(pVelocity.normalized * Time.deltaTime * pSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, -rotateSpeed * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
        }
    }
}
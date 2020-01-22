using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 100f;
    

    //Fire ball spell, make sure projectile spell gas gravity set to 0
    void Fireball()
    {

        GameObject fireBall = Instantiate(projectile, transform.position + transform.forward * 2, Quaternion.identity) as GameObject;
        Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
        fireBallRigidBody.AddForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        //Placeholder trigger, replace with successful incantation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fireball();
        }
    }
}
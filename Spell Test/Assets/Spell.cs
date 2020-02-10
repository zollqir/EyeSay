using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Spell protoype
/// How to use: See specific spell for details
/// Written by: Sammy Chan
/// ---------- 

public class Spell : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 100f;
    public GameObject ui;

    /// ---
    /// Fire ball spell, make sure projectile spell has gravity set to 0
    /// Shoots fireball in forward direction of object it is attached to
    ///
    /// Instantiate(projectile, [Change this code to alter spawning position of projectile], Quaternion.identity)
    /// ---
    void Fireball()
    {
        if (!(ui.GetComponent<GameMenu>().isPaused))
        {
            GameObject fireBall = Instantiate(projectile, transform.position + transform.forward * 2, Quaternion.identity) as GameObject;
            Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
            fireBallRigidBody.AddForce(transform.forward * speed);
        }
    }

    /// Temporary trigger so that I could test the spell without a mic,
    ///     DELETE in final build, or keep as secret debug-mode function
    void Update()
    {
        //Placeholder trigger, replace with successful incantation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fireball();
        }
    }
}
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
    public GameObject barrier;
    public Camera vrCam;

    /// ---
    /// Fire ball spell
    /// Make sure projectile spell has gravity set to 0
    /// Shoots fireball in forward direction of object it is attached to
    ///
    /// Instantiate(projectile, [Change this code to alter spawning position of projectile], Quaternion.identity)
    /// ---
    void Fireball()
    {
        if (!(ui.GetComponent<GameMenu>().isPaused))
        {
            GameObject fireBall = Instantiate(projectile, transform.position + transform.forward * 2, transform.rotation) as GameObject;
            Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
            fireBallRigidBody.AddForce(transform.forward * speed);
        }
    }

    /// ---
    /// Petrify Spell
    /// Only works on ghosts and skullbats
    /// Finds camera with viewCheck script and runs it to see which enemies are in view
    ///     If in view, sets their petrified status to true
    /// Once petrifed, enemies are no longer considered hazards and ghosts become visible
    /// 
    /// ---
    void Petrify()
    {
        if (ui.GetComponent<GameMenu>().isPaused)
        {
            return;
        }
        AIInfo[] enemies = FindObjectsOfType<AIInfo>();

        //ViewCheck vrCam = FindObjectOfType<ViewCheck>();
        ViewCheck viewChecker = vrCam.GetComponent<ViewCheck>();

        foreach(AIInfo enemy in enemies)
        {
            if (viewChecker.InView(enemy.gameObject))
            {
                enemy.petrified = true;
            }
        }
    }

    /// ---
    /// Barrier Spell
    ///     Works with attached gameObject barrier
    ///     The Barriers should be attached to the vrCam
    ///     Calling this simply sets it to active and resets the timer for the shield
    ///     The shield will deactivate itself on its own within 10 seconds
    ///     Calling this spell again while the shield is still will reset the timer of the shield
    /// ---
    void Barrier()
    {
        if (ui.GetComponent<GameMenu>().isPaused)
        {
            return;
        }
        barrier.SetActive(true);
        barrier.GetComponent<ShieldScript>().ResetShield();
    }

    /// Temporary trigger so that I could test the spell without a mic,
    ///     DELETE/Comment out in final build, or keep as secret debug-mode function
    ///
    void Update()
    {
        //Placeholder trigger, replace with successful incantation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fireball();
            Petrify();
            //Barrier();
        }
    }
}
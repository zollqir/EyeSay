using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script for turret that shoots hazardous fireballs
/// How to use: Attach to where you want fireballs shooting out
///     Uses a modified version of the playerfireball but tagged as destrucibled and with a hazard script attached
///     firerate:       Time between each shot
///     fireDuration:   How long one "firing session" lasts
///     cooldown:       Time until next firing session
///         To have continous firing, set to 0
///     projectileSpeed: speed of projectile
///
///     Must be set to active to fire, Once deactivated the turret cannot be reactivated.
/// Written by: Sammy Chan
/// ----------
/// 

public class EnemyTurret : MonoBehaviour
{
    public bool active;
    public float firerate;
    public float fireDuration;
    public float cooldown;
    public GameObject projectile;
    public float projectileSpeed = 100f;
    float startTime;
    float timePassed;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Shoot", 0.0f, 1);
        if (ui == null){
            ui = GameObject.Find("UI Screens");
        }
        startTime = Time.time;
        timePassed = 0;
        StartCoroutine("Firing");
    }

    void Shoot()
    {
        GameObject fireBall = Instantiate(projectile, transform.position + transform.forward*2, transform.rotation) as GameObject;
        //fireBall.transform.rotation = ;
        Rigidbody fireBallRigidBody = fireBall.GetComponent<Rigidbody>();
        fireBallRigidBody.AddForce(transform.forward * projectileSpeed);
    }

    void RapidFire()
    {
        //InvokeRepeating("Shoot", 0.0f, firerate);
        //timePassed += Time.deltaTime;
        //if (timePassed > fireDuration)
        //{
        //    CancelInvoke("Shoot");
        //}
    }

    private IEnumerator Firing()
    {
        //RapidFire();
        //yield return new WaitForSecondsRealtime(cooldown);
        //timePassed = 0;

        while (active && Time.timeScale != 0)
        {
            timePassed = 0;
            startTime = Time.time;
            while (timePassed - startTime < fireDuration)
            {
                while (ui.GetComponent<GameMenu>().isPaused)
                {
                    yield return null;
                }
                Shoot();
                yield return new WaitForSecondsRealtime(firerate);
                timePassed += Time.time - startTime;
                //Debug.Log("startTime: " + startTime);
                //Debug.Log("In Loop - Time: " + timePassed);
            }
            yield return new WaitForSecondsRealtime(cooldown);
            
            //startTime = Time.time;
            //Debug.Log("Waiting");
        }

    }

    // Update is called once per frame
    //void Update()
    //{
    //    StartCoroutine("Firing");
    //}
}

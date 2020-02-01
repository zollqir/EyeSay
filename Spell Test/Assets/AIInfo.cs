using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script containing various attribtes of an NPC
///     and the various functions to be used by an AINode
/// How to use:
///     Note - Some of the functions below are for specific NPC types (ie; the Skull)
///     Modify to add additional functions for additional behaviours
///         ie; returning to last patrol point
/// Written by: Sammy Chan
/// ---------- 

public class AIInfo : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 5f;

    public GameObject wayPoints;
    private int numbPoints;

    public GameObject currentTarget;
    private int targetIndex;

    private GameObject playerChar;
    public float aggroRange = 5f;

    private int stepDir = 1;

    public int behaviourType;

    //Skull Stuff
    public GameObject passiveEffect;
    public GameObject hostileEffect;


    //// Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        numbPoints = wayPoints.transform.childCount;
        currentTarget = wayPoints.transform.GetChild(0).gameObject;
        targetIndex = 0;
        playerChar = GameObject.FindWithTag("player");
    }

    public void CircularPatrol()
    {
        if (TargetReached())
        {
            targetIndex = (targetIndex + 1) % numbPoints;
            currentTarget = wayPoints.transform.GetChild(targetIndex).gameObject;
            rb.velocity = Vector3.zero;
        }
        FaceTarget();
        GoTo();
    }
    public void LinearPatrol()
    {
        if (TargetReached())
        {
            if (targetIndex == numbPoints - 1)
            {
                stepDir = -1;
            }
            else if (targetIndex == 0)
            {
                stepDir = 1;
            }
            targetIndex = (targetIndex + stepDir) % numbPoints;
            currentTarget = wayPoints.transform.GetChild(targetIndex).gameObject;
            rb.velocity = Vector3.zero;
        }
        FaceTarget();
        GoTo();
    }


    public void Aggro()
    {
        currentTarget = playerChar;
        FaceTarget();
        GoTo();
    }

    public bool WithinAggroRange()
    {
        float distance = Vector3.Distance(gameObject.transform.position, playerChar.transform.position);
        if (distance < aggroRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void GoTo()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void FaceTarget()
    {
        transform.LookAt(currentTarget.transform);
        
    }

    bool TargetReached()
    {
        float distance = Vector3.Distance(gameObject.transform.position, currentTarget.transform.position);

        if (distance < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AdjustSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public void SkullPassiveMode()
    {
        GetComponentInChildren<SkullRattle>().rattleOff();
        passiveEffect.SetActive(true);
        hostileEffect.SetActive(false);
        AdjustSpeed(1);
    }
    public void SkullHostileMode()
    {
        GetComponentInChildren<SkullRattle>().rattleOn();
        passiveEffect.SetActive(false);
        hostileEffect.SetActive(true);
        AdjustSpeed(5);
    }
}

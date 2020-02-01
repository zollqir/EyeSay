using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -- DO NOT USE --
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Enemy AI (OUTDATED - DO NOT USE)
/// How to use: Don't
/// Written by: Sammy Chan
/// ---------- 

public class EnemyAI : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 5f;

    public GameObject wayPoints;
    private int numbPoints;

    public GameObject currentTarget;
    private int targetIndex;

    private GameObject playerChar;
    public float aggroRange = 5f;

    public bool patrolTypeCircle = true;
    private int stepDir = 1;
    public bool idle = false;
    //private bool atTarget;

    //// Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        numbPoints = wayPoints.transform.childCount;
        currentTarget = wayPoints.transform.GetChild(0).gameObject;
        targetIndex = 0;
        playerChar = GameObject.FindWithTag("player");
        //atTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            return;
        }

        if (WithinAggroRange())
        {
            Aggro();
        }
        else
        {
            if (patrolTypeCircle)
            {
                CircularPatrol();
            }
            else
            {
                LinearPatrol();
            }
        }
    }

    void CircularPatrol()
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
    void LinearPatrol()
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


    void Aggro()
    {
        currentTarget = playerChar;
        FaceTarget();
        GoTo();
    }
    bool WithinAggroRange()
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
}

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
    private float currentSpeed;
    public float speed = 5f;
    public float chaseSpeed = 10f;

    public GameObject wayPoints = null;
    private int numbPoints = 0;

    public GameObject currentTarget;
    private int targetIndex;

    private GameObject playerChar;
    public float aggroRange = 5f;

    private int stepDir = 1;

    public int behaviourType;

    public bool petrified = false;
    public bool gargoylePermaChase = false;

    //Skull Stuff
    //public GameObject passiveEffect;
    //public GameObject hostileEffect;


    //// Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
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
            //rb.velocity = Vector3.zero;
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
            //rb.velocity = Vector3.zero;
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
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    public void FaceTarget()
    {
        //transform.LookAt(currentTarget.transform);
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, currentSpeed* Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        
    }

    public void LookAtPlayer()
    {
        currentTarget = playerChar;
        FaceTarget();
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

    //  Skull Bat Animations    //
    public void AnimatorGoHostile()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("hostileMode", true);
    }
    public void AnimatorGoPassive()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("hostileMode", false);
    }

    //  Ghost Animations    //
    public void AnimatorGhostScream()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.Play("Scream");
    }
    public bool IsScreaming()
    {
        Animator anim = GetComponentInChildren<Animator>();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Scream"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FreezeAnimation()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.speed = 0;
    }
    public void StopShaking() {
        GetComponentInChildren<SkullShake>().enabled = false;
    }
    public void PetrifyColor()
    {
        Renderer[] _material = GetComponentsInChildren<Renderer>();
        Color originalColour = _material[0].material.color;
        foreach (Renderer texture in _material)
        {
            texture.material.color = Color.Lerp(originalColour, Color.yellow, 0.5f);
        }
    }
    // Change ghost's layer to default making it visible
    public void MakeVisible(GameObject obj)
    {
        obj.layer = 0;
        foreach (Transform child in obj.transform)
        {
            child.gameObject.layer = 0;
            MakeVisible(child.gameObject);
        }
    }

    // For the gargoyle to prevent it from flying in the air
    public void GroundedFaceTarget()
    {
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 5 * Time.deltaTime, 0.0f);
        Quaternion groundedDirection = Quaternion.LookRotation(newDirection);
        Vector3 _eulerAngles = groundedDirection.eulerAngles;
        _eulerAngles.x = 0;
        _eulerAngles.z = 0;
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.eulerAngles = _eulerAngles;

    }
    public void GroundedAggro()
    {
        currentTarget = playerChar;
        GroundedFaceTarget();
        GoTo();
    }

    public void changeSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

}

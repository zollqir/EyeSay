using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script for the crystal goal 
/// How to use:
///     Add script as component to the Crystal GameObject
///         Add the corresponding active and inactive materials to onMat and OffMat
/// Written by: Sammy Chan
/// ---------- 

public class CrystalGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active = false;

    public GameObject theCrystal;
    public Material onMat;
    public Material offMat;

    public void Activate()
    {
        active = true;
        theCrystal.GetComponent<MeshRenderer>().material = onMat;
    }
    public void Deactivate()
    {
        active = false;
        theCrystal.GetComponent<MeshRenderer>().material = offMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            //This line can be deleted assuming the wind condition script for each level
            // properly calls the Activate() and Deactivate() functions when necessary                                     
            theCrystal.GetComponent<MeshRenderer>().material = onMat; 

            transform.RotateAround(transform.position, Vector3.up, 60 * Time.deltaTime);
        }
        else
        {
            //This line can be deleted assuming the wind condition script for each level
            // properly calls the Activate() and Deactivate() functions when necessary  
            theCrystal.GetComponent<MeshRenderer>().material = offMat; //
        }
    }
}

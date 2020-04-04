using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script to turn lamp on & off
///  - Note: The light may need to be reized if the lamppost is resized
/// Written by: Sammy Chan
/// ----------
/// 

public class LampPostScript : MonoBehaviour
{
    public GameObject flame;

    public bool active;

    private void Start()
    {
        if (active)
        {
            flame.SetActive(true);
        }
        else
        {
            flame.SetActive(false);
            active = false;
        }
    }

    public void Activate()
    {
        active = true;
        flame.SetActive(true);
    }
    public void Deactivate()
    {
        active = false;
        flame.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "meteroPrefab(Clone)")
        {
            Activate();
        }
        //else
        //{
        //    Debug.Log(collision.gameObject.name);
        //}
    }
}

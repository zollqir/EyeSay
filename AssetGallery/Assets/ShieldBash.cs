using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script attached to shield. Destroys any destrucibles that come in
///     contact with the shield
/// How to use: Attached to shield prefab
/// Written by: Sammy Chan
/// ----------
/// 
public class ShieldBash : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "destructible")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "destructible")
        {
            Destroy(other.gameObject);
        }

    }
}

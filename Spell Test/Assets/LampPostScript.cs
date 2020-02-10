using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

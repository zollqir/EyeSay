using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Cause the skull to shake violently
/// How to use:
///     Attach to 'Empty' object that is 'grandchild' of the 'Main Empty' object
///         ie; the child of 'Empty object' holding the SkullShake.cs component
/// Written by: Sammy Chan
/// ---------- 

public class SkullRattle : MonoBehaviour
{
    bool rattle = false;

    public void rattleOn()
    {
        rattle = true;
    }
    public void rattleOff()
    {
        rattle = false;
    }

    void Update()
    {
        if (rattle)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            transform.localRotation = Quaternion.Euler(x, y, z);
        }
    }
}

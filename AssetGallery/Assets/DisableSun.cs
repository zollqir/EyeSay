using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSun : MonoBehaviour
{

    public Light sunLight;

    void OnPreCull()
    {
        if (sunLight != null)
            sunLight.enabled = false;
    }

    void OnPreRender()
    {
        if (sunLight != null)
            sunLight.enabled = false;
    }
    void OnPostRender()
    {
        if (sunLight != null)
            sunLight.enabled = true;
    }
}

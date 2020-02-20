using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any)){
            gameObject.GetComponent<GenerateSpell>().EnableRecognizer();
            gameObject.GetComponent<GenerateSpell>().AddNewSpell("Fireball");
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            gameObject.GetComponent<GenerateSpell>().DisableRecognizer();
        }
    }
}

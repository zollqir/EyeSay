using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerManager : MonoBehaviour
{
    ///Quaternion rotation;
    public GameObject wizard;
    public Vector3 offset;
    private void Start()
    {
        //rotation = transform.rotation;
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
        //offset = new Vector3(2f, 2f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = wizard.transform.position + offset;
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        {
            gameObject.GetComponent<GenerateSpell>().EnableRecognizer();
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            gameObject.GetComponent<GenerateSpell>().DisableRecognizer();
            
        }        
    }
    
}

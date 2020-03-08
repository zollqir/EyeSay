using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLevelScript : MonoBehaviour
{
    bool winState = false;
    public GameObject exit;

    public GameObject lampA;
    public GameObject lampB;
    public GameObject lampC;

    LampPostScript lampAInfo;
    LampPostScript lampBInfo;
    LampPostScript lampCInfo;

    private void Start()
    {
        lampAInfo = lampA.GetComponent<LampPostScript>();
        lampBInfo = lampB.GetComponent<LampPostScript>();
        lampCInfo = lampC.GetComponent<LampPostScript>();
    }

    bool CheckLamps()
    {
        if (lampAInfo.active && lampBInfo.active && lampCInfo.active)
        {
            winState = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!winState)
        {
            if (CheckLamps())
            {
                exit.GetComponent<CrystalGoal>().Activate();
            }
        }   
    }
}

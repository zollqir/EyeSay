using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostLevelScript : MonoBehaviour
{
    public GameObject ghostA;
    public GameObject ghostB;
    public GameObject ghostC;
    public GameObject player;

    bool ghostAActive = false;
    bool ghostBActive = false;
    bool ghostCActive = false;

    // Update is called once per frame
    void Update()
    {
        if (!ghostAActive) {
            if (player.transform.position.z >= 20 && player.transform.position.x >= -6)
            {
                ghostA.GetComponent<AIInfo>().speed = 5;
                ghostA.GetComponent<AIInfo>().changeSpeed(5);
                ghostAActive = true;
            }
        }
        if (!ghostBActive)
        {
            if (player.transform.position.z >= 33)
            {
                ghostB.GetComponent<AIInfo>().speed = 5;
                ghostB.GetComponent<AIInfo>().changeSpeed(5);
                ghostBActive = true;
            }
        }
        if (!ghostCActive)
        {
            if (player.transform.position.z >= 45)
            {
                ghostC.GetComponent<AIInfo>().speed = 5;
                ghostC.GetComponent<AIInfo>().changeSpeed(5);
                ghostCActive = true;
            }
        }
    }
}

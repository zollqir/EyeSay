using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -- Should probably integrate this into the "main player" script which controls movment and spells lists, etc,
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Triggers game over and win screens
///     Should probably copy into the main player script which controlls 
/// How to use:
///     Attach to player object
///     Attach object with GameMenu.cs component to 'uiObj'
/// Written by: Sammy Chan
/// ---------- 

public class playerController : MonoBehaviour
{

    public GameObject uiObj;

    // Brings up a the gameOver screen
    // Triggerd by objects with the 'Hazard.cs' component
    public void killPlayer()
    {
        uiObj.GetComponent<GameMenu>().Lose();
    }

    private void OnCollisionEnter(Collision other)
    {
        //Check if the player has reached the goal
        if (other.gameObject.tag == "goal")
        {
            //Check if the goal is active and triggers Win screen if so
            if (other.gameObject.GetComponent<CrystalGoal>().active == true)
            {
                uiObj.GetComponent<GameMenu>().Win();
            }
        }

    }
}

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
    public GameObject blood;
    GameObject bloodFX;

    // Brings up a the gameOver screen
    // Triggerd by objects with the 'Hazard.cs' component
    public void killPlayer()
    {


        DeathAnimation();
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameMenu theMenu = uiObj.GetComponent<GameMenu>();
        theMenu.Invoke("Lose", 2.0f) ;
        //uiObj.GetComponent<GameMenu>().Lose();
    }

    public void DeathAnimation()
    {
        GameObject bloodFX = Instantiate(blood, transform.position, Quaternion.identity);
        //yield return new WaitForSeconds(5f);
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

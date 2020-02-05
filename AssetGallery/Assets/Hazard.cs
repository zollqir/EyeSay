using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Code that triggers a gameover state one the 
/// How to use: Add script as component to hazards and enemies, player character must be tagged "player"
///     Triggers the 'killPlayer()' function in the playerController which brings uo a game ober screen
/// Written by: Sammy Chan
/// ---------- 

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (other.gameObject.tag == "player")
        {
            // Placeholder "Game Over" to reset scene
            //SceneManager.LoadScene(scene.name);
            //Debug.Log("Dead");
            other.gameObject.GetComponent<playerController>().killPlayer();
        }
    }
}

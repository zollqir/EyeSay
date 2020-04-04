using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Main menu Script
/// How to use: Attach Script to 'Empty' object in a Canvas
///     For each button, add the releveant functions to the 'On Click()' part
/// Written by: Sammy Chan
/// ---------- 

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Replace "Test Dump" with 'Level 1' once it is created
        SceneManager.LoadScene("GhostLevel");
    }

    // Added more functions for each specific level create following the same format as Playgame
    public void LevelOne()
    {
        SceneManager.LoadScene("GhostLevel");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Gargoyle Level");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("ShadowMaze");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

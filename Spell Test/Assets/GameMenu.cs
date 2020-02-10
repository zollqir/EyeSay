using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Menus displayed while playing the game
/// How to use: Too much too explain
/// Written by: Sammy Chan
/// ---------- 

public class GameMenu : MonoBehaviour
{
    public bool isPaused = false;
    public bool gameComplete = false;//Player has already one or lost

    public GameObject playerChar;

    public GameObject pauseUI;
    public GameObject winUI;
    public GameObject loseUI;

    private void Update()
    {
        //if (playerChar.GetComponent<playerController>().hasWon){
        //    Win();
        //}
        //if (playerChar.GetComponent<playerController>().hasLost)
        //{
        //    Lose();
        //}



        if (gameComplete)
        {
            //Debug.Log("Finished!");
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        isPaused = false;
        gameComplete = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    // Pause Stuff //
    public void Resume()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        
    }
    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        gameComplete = false;
        //playerChar.GetComponent<playerController>().hasLost = false;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public bool checkPaused()
    {
        return isPaused;
    }

    //Win Stuff//
    public void Win()
    {
        gameComplete = true;
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    //Lose Stuff//
    public void Lose()
    {
        gameComplete = true;
        loseUI.SetActive(true);
        Time.timeScale = 0f;
    }
}

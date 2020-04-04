using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Example win condition
/// How to use:
///     Attach this script to an 'Empty' object in the game world
///     Attach the Crystal object to the script as goalPost
///     Each level will require their own "Win Condition" script
///     The Win condition, once met should activate the Crystal,
///         and deactivated if the level has such conditions
///     The Update() function should keep track of whether the objective is met
///
///     Completion of the actual level requires touching the active crystal
///         See playerController.cs or details
///         
///     The example below:
///         The 'objective' is a desctrubile object
///             Keeps checking if the object has been destroyed
///             activats crystal once destroyed
///             
/// Written by: Sammy Chan
/// ---------- 

public class DevLevelWinCondition : MonoBehaviour
{
    public GameObject goalPost;
    public GameObject objective; // Not necessary depending on how you want to make the level

    void Update()
    {
        if (objective.GetComponent<LampPostScript>().active)
        {
            goalPost.GetComponent<CrystalGoal>().Activate();
        }
    }
}
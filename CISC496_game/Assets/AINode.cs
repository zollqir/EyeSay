using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Finite Stae Machine Node
/// How to use:
///     Make sure, when using Transition() to return a new state
///         that the 'npc' value for that Node is also assigned
///         ie; nextnode.npc = npc
/// Written by: Sammy Chan
/// ---------- 

public abstract class AINode
{
    public GameObject npc;

    public abstract void Entry();

    public abstract void Exit();

    public abstract AINode Transition();

    public abstract void Action();
}

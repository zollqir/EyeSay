using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: AI Nodes for the 'Skull Enemy' only
///     Modify and Repurpose for different enemy types
/// How to use: 
/// Written by: Sammy Chan
/// ----------
/// 

public class CircularPatrolNode : AINode
{

    public override void Entry()
    {

    }
    public override void Exit()
    {

    }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().CircularPatrol();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new AggroNode();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return this;
        }
    }
}

public class LinearPatrolNode : AINode
{

    public override void Entry()
    {

    }
    public override void Exit()
    {

    }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().LinearPatrol();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new AggroNode();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return this;
        }
    }
}

public class AggroNode : AINode
{
    public override void Entry()
    {
        npc.GetComponent<AIInfo>().SkullHostileMode();
    }
    public override void Exit()
    {
        npc.GetComponent<AIInfo>().SkullPassiveMode();
    }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().Aggro();
    }
    public override AINode Transition()
    {
        return this;
    }
}

public class IdleNode : AINode
{
    public override void Entry()
    {

    }
    public override void Exit()
    {

    }
    public override void Action()
    {

    }
    public override AINode Transition()
    {
        return this;
    }
}



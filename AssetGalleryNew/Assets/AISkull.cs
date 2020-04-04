using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: AI Nodes for all enemies
/// How to use: 
/// Written by: Sammy Chan
/// ----------
/// 

//----------------- SkullBat AI Nodes -----------------//
//
//
public class SkullBatCircularPatrol: AINode
{
    public override void Entry(){}
    public override void Exit() {}
    public override void Action()
    {
        npc.GetComponent<AIInfo>().CircularPatrol();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new SkullBatPetrified();
            nextNode.npc = npc;
            return nextNode;
        }

        else if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new SkullBatAggro();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class SkullBatLinearPatrol: AINode
{
    public override void Entry(){}
    public override void Exit(){}
    public override void Action()
    {
        npc.GetComponent<AIInfo>().LinearPatrol();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new SkullBatPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new SkullBatAggro();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class SkullBatAggro: AINode
{
    public override void Entry()
    {
        npc.GetComponent<AIInfo>().AnimatorGoHostile();
    }
    public override void Exit(){}
    public override void Action()
    {
        npc.GetComponent<AIInfo>().Aggro();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new SkullBatPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class SkullBatIdle : AINode
{
    public override void Entry(){}
    public override void Exit(){}
    public override void Action(){}
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new SkullBatPetrified();
            nextNode.npc = npc;
            return nextNode;
        }

        else if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new SkullBatAggro();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class SkullBatPetrified : AINode
{
    public override void Entry() {
        AIInfo theAI = npc.GetComponent<AIInfo>();
        theAI.FreezeAnimation();
        theAI.StopShaking();
        npc.GetComponent<Hazard>().active = false;
        theAI.PetrifyColor();
    }
    public override void Exit() { }
    public override void Action() { }
    public override AINode Transition()
    {
        return null;
    }
}
//----------------- Ghost AI Nodes -----------------//
//
//
public class GhostCircularPatrol : AINode
{
    public override void Entry() { }
    public override void Exit() { }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().CircularPatrol();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new GhostPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new GhostScream();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class GhostLinearPatrol : AINode
{
    public override void Entry() { }
    public override void Exit() { }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().LinearPatrol();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new GhostPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new GhostScream();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class GhostAggro : AINode
{
    public override void Entry(){}
    public override void Exit() { }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().Aggro();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new GhostPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}
public class GhostScream : AINode
{
    public override void Entry(){
        npc.GetComponent<AIInfo>().AnimatorGhostScream();
    }
    public override void Exit() { }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().LookAtPlayer();
    }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new GhostPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else if (!npc.GetComponent<AIInfo>().IsScreaming())
        {
            AINode nextNode = new GhostAggro();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}

public class GhostIdle : AINode
{
    public override void Entry() { }
    public override void Exit() { }
    public override void Action() { }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().petrified)
        {
            AINode nextNode = new GhostPetrified();
            nextNode.npc = npc;
            return nextNode;
        }
        else if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new GhostScream();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}
public class GhostPetrified : AINode
{
    public override void Entry()
    {
        AIInfo theAI = npc.GetComponent<AIInfo>();
        theAI.FreezeAnimation();
        theAI.PetrifyColor();
        npc.GetComponent<Hazard>().active = false;
        theAI.MakeVisible(npc);
    }
    public override void Exit() { }
    public override void Action() { }
    public override AINode Transition()
    {
        return null;
    }
}
//----------------- Gargoyle AI Nodes -----------------//
//
//

public class GargoyleInactive: AINode
{
    public override void Entry()
    {
        npc.GetComponent<Hazard>().active = false;
    }
    public override void Exit() { }
    public override void Action() { }
    public override AINode Transition()
    {
        if (npc.GetComponent<AIInfo>().WithinAggroRange())
        {
            AINode nextNode = new GargoyleSleep();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}
public class GargoyleSleep : AINode
{
    public override void Entry()
    {
        npc.GetComponent<Hazard>().active = false;
    }
    public override void Exit() { }
    public override void Action() { }
    public override AINode Transition()
    {
        ViewCheck vrCam = Object.FindObjectOfType<ViewCheck>();
        AIInfo theNPC = npc.GetComponent<AIInfo>();

        if (vrCam.InView(npc))
        {
            return null;
        }
        else if (!(theNPC.WithinAggroRange()) && !(theNPC.gargoylePermaChase))
        {
            AINode nextNode = new GargoyleInactive();
            nextNode.npc = npc;
            return nextNode;
        }

        else
        {
            AINode nextNode = new GargoyleChase();
            nextNode.npc = npc;
            return nextNode;
        }
    }
}
public class GargoyleChase : AINode
{
    public override void Entry()
    {
        npc.GetComponent<Hazard>().active = true;
    }
    public override void Exit() { }
    public override void Action()
    {
        npc.GetComponent<AIInfo>().GroundedAggro();
    }
    public override AINode Transition()
    {
        ViewCheck vrCam = Object.FindObjectOfType<ViewCheck>();
        if (vrCam.InView(npc))
        {
            AINode nextNode = new GargoyleSleep();
            nextNode.npc = npc;
            return nextNode;
        }
        else
        {
            return null;
        }
    }
}


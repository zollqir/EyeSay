using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: AI Controller
/// How to use: Remember Last semester stuff
///     Attach to enemy
///     Set behaviour type in inspector to appropriate value
/// Written by: Sammy Chan
/// ---------- 

public class AIController : MonoBehaviour
{

    AINode currentNode;

    /// Dictionary with different Nodes that can act as starting nodes
    ///  Number depends on ai type
    ///     Skullbat:
    ///         10 = Skullbat idle
    ///         11 = Skullbat Circular Patrol
    ///         12 = Skullbat Linear Patrol
    ///     Ghost:
    ///         20 = Skullbat idle
    ///         21 = Skullbat Circular Patrol
    ///         22 = Skullbat Linear Patrol
    ///     Gargoyle:
    ///         30 = Only behaviour type
    ///         the bool 'gargoylePermaChase' defines wether or not
    ///             the gargoyle will attempt to chase the player forever
    ///             or go back become inactive if the player managed to escapes
    ///             its range
    ///
    ///     CircularPatrol: Once the last patrol point is reached it will head to the first patrol point
    ///     LinearPatrol: Once the last patrol point is reached it will go to its previous patrol point and head backwards
    Dictionary<int, AINode> aiTypes = new Dictionary<int, AINode>();

    SkullBatIdle skullA = new SkullBatIdle();
    SkullBatCircularPatrol skullB = new SkullBatCircularPatrol();
    SkullBatLinearPatrol skullC = new SkullBatLinearPatrol();

    GhostIdle ghostA = new GhostIdle();
    GhostCircularPatrol ghostB = new GhostCircularPatrol();
    GhostLinearPatrol ghostC = new GhostLinearPatrol();

    GargoyleInactive gargoyleA = new GargoyleInactive();

    private void Start()
    {
        //Skullbat Types
        aiTypes.Add(10, skullA);
        aiTypes.Add(11, skullB);
        aiTypes.Add(12, skullC);

        //ghost Types
        aiTypes.Add(20, ghostA);
        aiTypes.Add(21, ghostB);
        aiTypes.Add(22, ghostC);

        //gargoyle
        aiTypes.Add(30, gargoyleA);



        //int aiTypeKey = gameObject.GetComponent<BehaviourType>().n;
        int aiTypeKey = gameObject.GetComponent<AIInfo>().behaviourType;

        currentNode = aiTypes[aiTypeKey];
        currentNode.npc = gameObject;
    }

    void Update()
    {
        //if (currentNode != currentNode.Transition())
        //{
        //    currentNode.Exit();
        //    currentNode = currentNode.Transition();
        //    currentNode.Entry();
        //}
        if (currentNode.Transition() != null)
        {
            currentNode.Exit();
            currentNode = currentNode.Transition();
            currentNode.Entry();
        }
        currentNode.Action();
    }
}

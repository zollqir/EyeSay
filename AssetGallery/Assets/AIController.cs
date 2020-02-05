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

    // Dictionary with differnt Nodes that can act as starting nodes,
    //  expand upon if further behaviours are developed
    // 0 = Idle
    // 1 = Skull Circular Patrol
    // 2 = Skull Linear Patrol
    Dictionary<int, AINode> aiTypes = new Dictionary<int, AINode>();
    IdleNode typeIdle = new IdleNode();
    CircularPatrolNode typeA = new CircularPatrolNode();
    LinearPatrolNode typeB = new LinearPatrolNode();


    private void Start()
    {
        aiTypes.Add(0, typeIdle);
        aiTypes.Add(1, typeA);
        aiTypes.Add(2, typeB);

        int aiTypeKey = gameObject.GetComponent<AIInfo>().behaviourType;

        currentNode = aiTypes[aiTypeKey];
        currentNode.npc = gameObject;
    }

    void Update()
    {
        if (currentNode != currentNode.Transition())
        {
            currentNode.Exit();
            currentNode = currentNode.Transition();
            currentNode.Entry();
        }
        currentNode.Action();
    }
}

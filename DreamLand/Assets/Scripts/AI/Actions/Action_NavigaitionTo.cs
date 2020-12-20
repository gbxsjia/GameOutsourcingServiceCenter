using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_NavigaitionTo : AI_Action_Base
{
    public Vector3 TargetPosition;
    public float Distance;

    public NavMeshAgent agent;

    private NavMeshPath path=new NavMeshPath();
    public Action_NavigaitionTo(Vector3 position, float distance)
    {
        TargetPosition = position;
        Distance = distance;
     
     
    }

    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        agent = character.GetComponent<NavMeshAgent>();

        agent.CalculatePath(TargetPosition, path);
        foreach(Vector3 p in path.corners)
        {
            Debug.DrawLine(p, p + Vector3.up, Color.red, 10f);
        }
    }
    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);

        if (path.corners.Length >= 2)
        {
            character.Move(path.corners[1]-character.transform.position);
        }

        if (Vector3.Distance(character.transform.position, TargetPosition) <= Distance)
        {
            ActionFinish();
        }
    }
}

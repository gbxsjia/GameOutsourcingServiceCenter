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

    private float ResetPathTimer;
    private float ResetTimerDuration = 0.2f;
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
    }
    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        ResetPathTimer += Time.deltaTime;
        if (ResetPathTimer >= ResetTimerDuration)
        {
            ResetPathTimer = 0;
            agent.CalculatePath(TargetPosition, path);
        }
        foreach (Vector3 p in path.corners)
        {
            Debug.DrawLine(p, p + Vector3.up * 5, Color.red, 0.2f);
        }

        if (path.corners.Length >= 2)
        {
            character.Move(path.corners[1] - character.transform.position);
            if (Vector3.Distance(character.transform.position, path.corners[1]) <= 0.1f)
            {
                agent.CalculatePath(TargetPosition, path);
            }
        }
        else
        {
            ActionFinish();            
        }

        if (Vector3.Distance(character.transform.position, TargetPosition) <= Distance)
        {
            ActionFinish(); 
        }
    }
    public override void BeforeExit()
    {
        base.BeforeExit();
        Character.Move(Vector3.zero);
    }
}

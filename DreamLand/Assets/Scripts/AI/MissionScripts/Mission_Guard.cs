using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Guard : AI_Mission_Base
{
    float MoveDistance;
    float SprintDistance;
    GameObject Target;

    int FollowPriority=0;
    public Mission_Guard(GameObject target,float moveDistance,float sprintDistance)
    {
        Target = target;
        MoveDistance = moveDistance;
        SprintDistance = sprintDistance;
        Priority = 60;
    }
    public override void MissionStart(AI_Base brain, Character_Base character)
    {
        base.MissionStart(brain, character);
    }
    public override void OnActionEmpty()
    {
        SetUpActions();
        ActionStart();
    }
    public override void MissionUpdate(AI_Base brain, Character_Base character)
    {
        base.MissionUpdate(brain, character);
        float distance = Vector3.Distance(Target.transform.position , character.transform.position );
        if (distance > SprintDistance)
        {
            SetFollowPriority(2);
        }
        else if (distance > MoveDistance)
        {
            SetFollowPriority(1);
        }
        else
        {
            SetFollowPriority(0);
        }
    }

    public void SetFollowPriority(int amount)
    {
        if (FollowPriority != amount)
        {
            OnPriorityChange(FollowPriority,amount);
            FollowPriority = amount;
            SetUpActions();
            ActionStart();
        }
    }
    public void OnPriorityChange(int oldPriority,int newPriority)
    {
        AbortAllAction();
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        switch (FollowPriority)
        {
            case 0:
                ownerCharacter.SetMoveMode(MoveMode.walk);
                AddNewAction(new Action_AttackAround(null));
                break;
            case 1:
                ownerCharacter.SetMoveMode(MoveMode.walk);
                AddNewAction(new Action_AttackAround(Target.transform));
                break;
            case 2:
                ownerCharacter.SetMoveMode(MoveMode.run);
                AddNewAction(new Action_MoveFollow(Target, 0.1f, 0.1f));
                break;
        }
    }
}

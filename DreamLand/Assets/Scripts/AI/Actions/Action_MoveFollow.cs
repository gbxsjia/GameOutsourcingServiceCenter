using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_MoveFollow : AI_Action_Base
{
    GameObject Target;
    float StopRange;
    float MinDuration;
    float timer;
    public Action_MoveFollow(GameObject target,float stopRange,float minDuration)
    {
        Target = target;
        StopRange = stopRange;
        MinDuration = minDuration;
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        timer = MinDuration;
    }

    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        if (Target == null)
        {
            ActionFinish();
        }
        Vector3 Direction = Target.transform.position - Character.transform.position;
        if (Direction.magnitude <= StopRange)
        {
            character.Move(Vector3.zero);
            if (timer <= 0)
            {
                ActionFinish();
            }            
        }
        else
        {
            Character.Move(Direction.normalized);
        }
        timer -= Time.deltaTime;  
    }
}

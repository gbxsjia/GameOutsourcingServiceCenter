using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : AI_Action_Base
{
    public Transform TargetTransform;
    public Action_Attack(Transform targetTransform)
    {
        TargetTransform = targetTransform;
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        if (character.canAttack())
        {
            character.AttackCommand(TargetTransform.position-Character.transform.position);
            ActionFinish();
        }     
    }
    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        if (character.canAttack())
        {
            character.AttackCommand(TargetTransform.position - Character.transform.position);
            ActionFinish();
        }
    }

}

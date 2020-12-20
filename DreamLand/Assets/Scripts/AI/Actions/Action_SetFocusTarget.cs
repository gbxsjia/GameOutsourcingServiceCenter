using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_SetFocusTarget : AI_Action_Base
{
    public Transform FocusTarget;
    public Action_SetFocusTarget(Transform target)
    {
        FocusTarget = target;
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        character.SetFocusTransform(FocusTarget);
        ActionFinish();
    }

}

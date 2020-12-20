using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Action_Move : AI_Action_Base
{
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
    }
    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
    }
    public override void ActionInterrupt(AI_Base brain, Character_Base character)
    {
        base.ActionInterrupt(brain, character);
    }
}

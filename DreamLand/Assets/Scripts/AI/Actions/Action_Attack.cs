using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : AI_Action_Base
{
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        character.AttackCommand();
        character.BehaviourEndEvent += OnBehaviourEnd;
    }

    private void OnBehaviourEnd(Behaviour obj)
    {
        Character.BehaviourEndEvent -= OnBehaviourEnd;
        ActionFinish();
    }
}

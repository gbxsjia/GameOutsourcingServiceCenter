using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action_Moveto : AI_Action_Base
{
    public Vector3 TargetPosition;
    public float Distance;
    public Action_Moveto(Vector3 position, float distance)
    {
        TargetPosition = position;
        Distance = distance;
    }

    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        character.Move(TargetPosition - character.transform.position);
        character.RotateTowards(TargetPosition);
        if (Vector3.Distance(character.transform.position, TargetPosition) <= Distance)
        {
            character.Move(Vector3.zero);
            ActionFinish();
        }
    }

    public override void BeforeExit()
    {
        base.BeforeExit();
        Character.Move(Vector3.zero);
    }
}

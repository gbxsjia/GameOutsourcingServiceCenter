﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_RotateTowards : AI_Action_Base
{
    public Vector3 targetPosition;
    public float AngleRange;
    public Action_RotateTowards(Vector3 position, float angleRange)
    {
        targetPosition = position;
        AngleRange = angleRange;
    }

    public override void BeforeExit()
    {
        base.BeforeExit();
    }
    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        character.SetFocusTransform(null);        
        float angle = character.RotateTowards(targetPosition);
        if (angle <= AngleRange)
        {
            ActionFinish();
        }
    }
}

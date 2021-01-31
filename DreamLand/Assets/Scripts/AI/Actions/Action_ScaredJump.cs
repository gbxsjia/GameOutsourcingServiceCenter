using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_ScaredJump : AI_Action_Base
{
    private float timer;
    public float Duration = 0.5f;
    public Transform RotateToTransform;
    public Action_ScaredJump(Transform rotateToTransform)
    {
        timer = Duration;
        RotateToTransform = rotateToTransform;
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        character.JumpStart(character.transform.position, Duration, 0.75f, "");
    }

    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);

        if (RotateToTransform)
        {
            character.Rotate(RotateToTransform.position);
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ActionFinish();
        }
    }
}

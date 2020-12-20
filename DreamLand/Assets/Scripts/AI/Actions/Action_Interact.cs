using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Interact : AI_Action_Base
{
    public InteractItem_Base Item;
    public float Duration;
    public string AnimationName;

    private float timer;
    private bool isInteracting;
    public Action_Interact(InteractItem_Base item, float duration, string animationName="Interact") 
    {
        Item = item;
        AnimationName = animationName;
        Duration = duration;
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        if (Item)
        {
            Item.InteractStart(character);
            timer = Duration;
            isInteracting = true;
            character.PlayAnimation(AnimationName);
        }
    }

    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        if (isInteracting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 )
            {
                if (Item)
                {
                    Item.InteractEnd(character);
                }
                ActionFinish();
            }
        }
    }
}

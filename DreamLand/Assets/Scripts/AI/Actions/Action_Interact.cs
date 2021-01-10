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
            Behaviour b= character.StartBehaviour(new Behaviour(AnimationName, Duration, BehaviourType.Interact, new float[] {}));
            b.BehaviourFinishEvent += OnBehaviourFinish;
        }
    }



    private void OnBehaviourFinish()
    {
        if (Item)
        {
            Item.InteractEnd(Character,true);
        }
        ActionFinish();
    }
    public override void ActionInterrupt(AI_Base brain, Character_Base character)
    {
        base.ActionInterrupt(brain, character);
        if (isInteracting)
        {
            if (Item)
            {
                Item.InteractEnd(Character,false);
            }
        }
    }
}

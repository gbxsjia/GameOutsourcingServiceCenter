using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour
{
    public Behaviour(string animName, float duration, BehaviourType type, float[] eventTiming)
    {
        AnimationName = animName;
        Duration = timer = duration;
        Type = type;
        EventTiming = (float[])eventTiming.Clone();
    }
    public string AnimationName;
    public float Duration;
    public BehaviourType Type;
    public float[] EventTiming;

    private int eventIndex = 0;
    private float timer;

    private Character_Base Character;

    public event System.Action<Behaviour, int> BehaviourTimingEvent;
    public virtual void StartBehaviour(Character_Base character)
    {
        character.PlayAnimation(AnimationName);
        Character = character;
    }
    public virtual void UpdateBehaviour(Character_Base character)
    {
        timer -= Time.deltaTime;

        if (Duration - timer > EventTiming[eventIndex])
        {
            if (BehaviourTimingEvent != null)
            {
                BehaviourTimingEvent(this, eventIndex);
            }
            eventIndex++;
        }
        if (timer <= 0)
        {
            BehaviourFinish();
        }
        
    }

    public virtual void BehaviourFinish()
    {       
        Character.FinishBehaviour();        
    }
}

public enum BehaviourType
{
    Attack,
    Stun,
}
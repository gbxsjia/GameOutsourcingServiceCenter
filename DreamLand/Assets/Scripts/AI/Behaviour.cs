using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
    public event System.Action BehaviourFinishEvent;
    public virtual void StartBehaviour(Character_Base character)
    {
        if (AnimationName.Length != 0)
        {
            character.PlayAnimation(AnimationName);
        }
      
        Character = character;
    }
    public virtual void UpdateBehaviour(Character_Base character)
    {
        timer -= Time.deltaTime;

        if (eventIndex < EventTiming.Length && Duration - timer > EventTiming[eventIndex])
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
    public virtual void BehaviourInterrpt()
    {

    }

    public virtual void BehaviourFinish()
    {
        if (BehaviourFinishEvent != null)
        {
            BehaviourFinishEvent();
        }
        Character.FinishBehaviour();        
    }
}

public enum BehaviourType
{
    Attack,
    Stun,
}
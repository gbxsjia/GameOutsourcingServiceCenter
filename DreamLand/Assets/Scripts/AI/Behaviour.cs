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
        if (eventTiming != null)
        {
            EventTiming = (float[])eventTiming.Clone();
        }     
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
    public event System.Action BehaviourInterruptEvent;
    public event System.Action BeforeExitEvent;
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

        if (EventTiming!=null && eventIndex < EventTiming.Length && Duration - timer > EventTiming[eventIndex])
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
        if (BehaviourInterruptEvent != null)
        {
            BehaviourInterruptEvent();
        }
        BeforeExit();
    }

    public virtual void BehaviourFinish()
    {
        if (BehaviourFinishEvent != null)
        {
            BehaviourFinishEvent();
        }
        BeforeExit();
        Character.FinishBehaviour();        
    }
    protected virtual void BeforeExit()
    {
        if (BeforeExitEvent != null)
        {
            BeforeExitEvent();
        }
    }
}

public enum BehaviourType
{
    Attack,
    Interact,
    Stun,
    Jump,
}
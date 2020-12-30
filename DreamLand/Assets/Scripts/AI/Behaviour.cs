using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour
{
    public Behaviour(string animName, float duration, BehaviourType type)
    {
        AnimationName = animName;
        Duration = timer = duration;
        Type = type;
    }
    public string AnimationName;
    public float Duration;
    public BehaviourType Type;

    private float timer;

    private Character_Base Character;

    public virtual void StartBehaviour(Character_Base character)
    {
        character.PlayAnimation(AnimationName);
        Character = character;
    }
    public virtual void UpdateBehaviour(Character_Base character)
    {
        timer -= Time.deltaTime;
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
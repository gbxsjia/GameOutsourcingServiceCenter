using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_AttackAround : AI_Action_Base
{
    public AIPerception perception;
    public Character_Base Character;
    public Transform FollowTransform;
    public Action_AttackAround(Transform followTransform)
    {
        FollowTransform = followTransform;
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        perception = character.GetComponentInChildren<AIPerception>();
        Character = character;
    }

    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        if (character.canAttack())
        {
            GameObject g = FindNearestEnemy();
            if (g != null)
            {
                character.AttackCommand(g.transform.position - Character.transform.position);
            }
        }
        if (FollowTransform != null)
        {
            character.Move(FollowTransform.position - character.transform.position);
        }
        else
        {
            character.Move(Vector3.zero);
        }
    }
   
    public GameObject FindNearestEnemy()
    {
        GameObject result = null;
        float distance = Mathf.Infinity;
        foreach(Character_Base ch in perception.CharactersInSight)
        {
            if (ch.CState.Camp != Character.CState.Camp && ch.CState.isAlive)
            {
                float tempDis = Vector3.Distance(ch.transform.position, Character.transform.position);
                if (tempDis <= distance)
                {
                    distance = tempDis;
                    result = ch.gameObject;
                }
            }
        }
        return result;
    }
}

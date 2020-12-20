using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Action_Base
{
    public AI_Mission_Base Mission;
    public AI_Base Brain;
    public Character_Base Character;

    public virtual void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        Mission = mission;
        Brain = brain;
        Character = character;
    }
    public virtual void ActionInterrupt(AI_Base brain, Character_Base character)
    {
        BeforeExit();
    }
    public virtual void ActionFinish()
    {
        BeforeExit();
        Mission.ActionFinish(this, true);       
    }
    public virtual void BeforeExit()
    {

    }
    public virtual void ActionUpdate(AI_Base brain, Character_Base character)
    {

    }

}

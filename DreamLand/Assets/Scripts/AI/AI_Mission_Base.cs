using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI_Mission_Base
{
    public int Priority;

    public List<AI_Action_Base> ActionList = new List<AI_Action_Base>();
    private AI_Action_Base currentAction;

    public AI_Base ownerBrain;
    public Character_Base ownerCharacter;

    protected int AchivementCounts = 1;
    protected int AchiveIndex = 0;
    public virtual void SetUpActions()
    {

    }
    public virtual void MissionStart(AI_Base brain, Character_Base character)
    {
        ownerBrain = brain;
        ownerCharacter = character;
        SetUpActions();
        ActionStart();
    }
    public virtual void MissionUpdate(AI_Base brain, Character_Base character)
    {
        currentAction.ActionUpdate(brain, character);
    }

    public virtual void MissionEnd(AI_Base brain, Character_Base character)
    {
        brain.MissionEnd(this, true);
    }

    public virtual void MissionAbort(AI_Base brain, Character_Base character, AI_Mission_Base newMission)
    {
        currentAction.ActionInterrupt(brain, character);
    }
    public virtual void ActionStart()
    {
        if (ActionList.Count > 0)
        {
            currentAction = ActionList[0];
            ActionList.RemoveAt(0);
            currentAction.ActionStart(this, ownerBrain, ownerCharacter);
        }
  
    }
    public virtual void ActionFinish(AI_Action_Base action, bool success)
    {
        currentAction = null;
        if (ActionList.Count > 0)
        {
            ActionStart();
        }
        else
        {
            AchiveIndex++;
            if (AchiveIndex >= AchivementCounts)
            {
                MissionEnd(ownerBrain, ownerCharacter);
            }
            else
            {
                SetUpActions();
                ActionStart();
            }
        }       
    }

    public void AddNewAction(AI_Action_Base action)
    {
        ActionList.Add(action);
    }
    public AI_Action_Base GetCurrentAction()
    {
        return currentAction;
    }
}

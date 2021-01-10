using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_WaitForInteract : AI_Action_Base
{
    public InteractItem_Base Item;
    public Action_WaitForInteract(InteractItem_Base item)
    {
        Item = item;        
    }
    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);
        Check(character);
    }
    public override void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        base.ActionStart(mission, brain, character);
        Check(character);
    }
    public void Check(Character_Base character)
    {
        if (Item.CanInteract())
        {
            Item.OccupySlot(character);
            ActionFinish();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mission_UseItem : AI_Mission_Base
{
    public InteractItem_Base TargetItem;
    public float Duration;

    public Mission_UseItem(InteractItem_Base item, float duration)
    {
        TargetItem = item;
        Duration = duration;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        Transform slot= TargetItem.GetSlot(ownerCharacter);
        if (slot)
        {
            AddNewAction(new Action_Moveto(slot.position, 0.5f));
            AddNewAction(new Action_RotateTowards(slot.position + slot.forward, 1f));
            AddNewAction(new Action_Interact(TargetItem, Duration));
        }
    }
}

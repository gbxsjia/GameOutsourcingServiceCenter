using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mission_UseItem : AI_Mission_Base
{
    public InteractItemType ItemType;

    public Mission_UseItem(InteractItemType itemType)
    {
        ItemType = itemType;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        InteractItem_Base TargetItem = null;
        float minDistance = Mathf.Infinity;
        foreach (InteractItem_Base item in InteractManager.instance.GetItemList(ItemType))
        {
            float distance = Vector3.Distance(item.transform.position, ownerCharacter.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                TargetItem = item;
            }
        }

        if (TargetItem)
        {
            AddNewAction(new Action_NavigaitionTo(TargetItem.GetSlot().position, 2));
            AddNewAction(new Action_RotateTowards(TargetItem.GetSlot().position + TargetItem.GetSlot().forward, 2f));
            AddNewAction(new Action_WaitForInteract(TargetItem));
            AddNewAction(new Action_NavigaitionTo(TargetItem.GetSlot().position, 0.5f));
            AddNewAction(new Action_RotateTowards(TargetItem.GetSlot().position + TargetItem.GetSlot().forward, 2f));
            AddNewAction(new Action_Interact(TargetItem, 1));

        }
    }
}

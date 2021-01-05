using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_GetResource : AI_Mission_Base
{
    InteractItemType ResourceType;
    InteractItemType Storage;
    public Mission_GetResource(InteractItemType resourceType,InteractItemType storage)
    {
        ResourceType = resourceType;
        Storage = storage;
    }

    public override void SetUpActions()
    {
        base.SetUpActions();

        InteractItem_Base TargetItem = null;
        float minDistance = Mathf.Infinity;
        foreach (InteractItem_Base item in InteractManager.instance.GetItemList(ResourceType))
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
            Transform slot = TargetItem.GetSlot(ownerCharacter);
            if (slot)
            {
                AddNewAction(new Action_Moveto(slot.position, 0.5f));
                AddNewAction(new Action_RotateTowards(slot.position + slot.forward, 2f));
                AddNewAction(new Action_Interact(TargetItem, 1));
            }
        }

        TargetItem = null;
        minDistance = Mathf.Infinity;
        foreach (InteractItem_Base item in InteractManager.instance.GetItemList(Storage))
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
            Transform slot = TargetItem.GetSlot(ownerCharacter);
            if (slot)
            {
                AddNewAction(new Action_Moveto(slot.position, 0.5f));
                AddNewAction(new Action_RotateTowards(slot.position + slot.forward, 2f));
                AddNewAction(new Action_Interact(TargetItem, 1));
            }
        }
    }

}

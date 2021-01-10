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
        AchivementCounts = 2;
    }

    public override void SetUpActions()
    {
        base.SetUpActions();

        switch (AchiveIndex)
        {
            case 0:
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
                    AddNewAction(new Action_NavigaitionTo(TargetItem.GetSlot().position, 2));
                    AddNewAction(new Action_RotateTowards(TargetItem.GetSlot().position + TargetItem.GetSlot().forward, 2f));
                    AddNewAction(new Action_WaitForInteract(TargetItem));
                    AddNewAction(new Action_NavigaitionTo(TargetItem.GetSlot().position, 0.5f));
                    AddNewAction(new Action_RotateTowards(TargetItem.GetSlot().position + TargetItem.GetSlot().forward, 2f));
                    AddNewAction(new Action_Interact(TargetItem, 1));

                }

                break;
            case 1:
                InteractItem_Base HouseItem = null;
                minDistance = Mathf.Infinity;
                foreach (InteractItem_Base item in InteractManager.instance.GetItemList(Storage))
                {
                    float distance = Vector3.Distance(item.transform.position, ownerCharacter.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        HouseItem = item;
                    }
                }

                if (HouseItem)
                {
                    AddNewAction(new Action_NavigaitionTo(HouseItem.GetSlot().position, 2));
                    AddNewAction(new Action_RotateTowards(HouseItem.GetSlot().position + HouseItem.GetSlot().forward, 2f));
                    AddNewAction(new Action_WaitForInteract(HouseItem));
                    AddNewAction(new Action_NavigaitionTo(HouseItem.GetSlot().position, 0.5f));
                    AddNewAction(new Action_RotateTowards(HouseItem.GetSlot().position + HouseItem.GetSlot().forward, 2f));
                    AddNewAction(new Action_Interact(HouseItem, 1));
                }
                break;
        }
 
       
    }
    public override void MissionAbort(AI_Base brain, Character_Base character, AI_Mission_Base newMission)
    {
        base.MissionAbort(brain, character, newMission);
    }
}

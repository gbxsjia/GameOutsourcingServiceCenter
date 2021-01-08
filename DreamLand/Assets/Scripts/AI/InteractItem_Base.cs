using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem_Base : MonoBehaviour
{
    public InteractItemType type;

    public Transform InteractSlot;
    public Transform InteractWaitingPlace;
    public bool SlotState;
    public Character_Base SlotUser;

    public float Duration;

    private void Start()
    {
        InteractManager.instance.RegistItem(this);
    }

    public event System.Action<Character_Base> InteractStartEvent;
    public event System.Action<Character_Base> InteractEndEvent;
    public virtual bool InteractStart(Character_Base character)
    {
        if (InteractStartEvent != null)
        {
            InteractStartEvent(character);
        }
        SlotState = false;
        SlotUser = character;
        return true;
    }
    public virtual void InteractEnd(Character_Base character, bool success=true)
    {
        if (InteractEndEvent != null)
        {
            InteractEndEvent(character);
        }
        if (SlotUser == character)
        {
            SlotState = true;
            SlotUser = null;
        }
    }
    public Transform GetSlot()
    {
        return InteractSlot;
    }
    public Transform GetWaitingPlace()
    {
        return InteractWaitingPlace;
    }
    public virtual AI_Mission_Base GetMission()
    {
        AI_Mission_Base newMission = new Mission_UseItem(this,Duration);
        return newMission;
    }
}
public enum InteractItemType
{
    House,
    Resource,
    End
}
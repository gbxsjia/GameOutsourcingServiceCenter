using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem_Base : MonoBehaviour
{
    public Transform[] InteractSlots;
    public bool[] SlotState;
    public Character_Base[] SlotUsers;

    public float Duration;

    private void Awake()
    {
        SlotState = new bool[InteractSlots.Length];
        for (int i = 0; i < InteractSlots.Length; i++)
        {
            SlotState[i] = true;
        }
        SlotUsers = new Character_Base[InteractSlots.Length];
    }

    public event System.Action<Character_Base> InteractStartEvent;
    public event System.Action<Character_Base> InteractEndEvent;
    public virtual bool InteractStart(Character_Base character)
    {
        if (InteractStartEvent != null)
        {
            InteractStartEvent(character);
        }
        return true;
    }
    public virtual void InteractEnd(Character_Base character)
    {
        if (InteractEndEvent != null)
        {
            InteractEndEvent(character);
        }
        for (int i = 0; i < InteractSlots.Length; i++)
        {
            if (SlotUsers[i] == character)
            {
                SlotState[i] = true;
                SlotUsers[i] = null;
            }
        }
    }
    public Transform GetSlot(Character_Base character)
    {
        for (int i = 0; i < InteractSlots.Length; i++)
        {
            if (SlotState[i])
            {
                SlotState[i] = false;
                SlotUsers[i] = character;
                return InteractSlots[i];
            }
        }
        return null;
    }
    public virtual AI_Mission_Base GetMission()
    {
        AI_Mission_Base newMission = new Mission_UseItem(this,Duration);
        return newMission;
    }
}

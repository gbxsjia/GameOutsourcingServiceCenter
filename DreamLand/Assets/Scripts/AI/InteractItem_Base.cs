using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem_Base : MonoBehaviour
{
    public InteractItemType type;

    public Transform InteractSlot;
    public bool SlotState=true;
    public Character_Base SlotUser;

    public float Duration;

    private void Start()
    {
        InteractManager.instance.RegistItem(this);
        SlotState = true;
    }

    public event System.Action<Character_Base> InteractStartEvent;
    public event System.Action<Character_Base,bool> InteractEndEvent;
    public virtual bool InteractStart(Character_Base character)
    {
        if (InteractStartEvent != null)
        {
            InteractStartEvent(character);
        }
        
        return true;
    }
    public virtual void InteractEnd(Character_Base character, bool success=true)
    {
        if (InteractEndEvent != null)
        {
            InteractEndEvent(character,success);
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
    public void OccupySlot(Character_Base character)
    {
        if (CanInteract())
        {
            SlotState = false;
            SlotUser = character;
        }
    }
    public bool CanInteract()
    {
        return SlotState;
    }

}
public enum InteractItemType
{
    Chest,
    Resource,
    House,
    End
}
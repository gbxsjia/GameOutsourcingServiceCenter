using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPerception : MonoBehaviour
{
    public float AlertRange=7f;

    public List<InteractItem_Base> ItemsInSight;

    public event System.Action<InteractItem_Base> NewItemEnterEvent;
    public event System.Action<InteractItem_Base> ItemExitEvent;

    public List<Character_Base> CharactersInSight;

    public event System.Action<Character_Base> NewCharacterEnterEvent;
    public event System.Action<Character_Base> CharacterExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        InteractItem_Base item = other.GetComponentInParent<InteractItem_Base>();
        if (item)
        {
            ItemsInSight.Add(item); 
            if (NewItemEnterEvent != null)
            {
                NewItemEnterEvent(item);
            }
        }
        else
        {
            Character_Base ch = other.GetComponent<Character_Base>();
            if (ch && ch.CState.isAlive)
            {
                CharactersInSight.Add(ch);
                if (NewCharacterEnterEvent != null)
                {
                    NewCharacterEnterEvent(ch);
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        InteractItem_Base item = other.GetComponentInParent<InteractItem_Base>();
        if (item)
        {
            ItemsInSight.Remove(item);
            if (ItemExitEvent!=null)
            {
                ItemExitEvent(item);
            }
       
        }
        else
        {
            Character_Base ch = other.GetComponent<Character_Base>();
            if (ch)
            {
                CharactersInSight.Remove(ch);
                if (CharacterExitEvent != null)
                {
                    CharacterExitEvent(ch);
                }
            }
        }
    }
}

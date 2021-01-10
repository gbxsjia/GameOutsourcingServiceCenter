using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ChangeStateValue : MonoBehaviour
{
    public InteractItem_Base InteractItem;

    public ChangeStateValueInfo[] SuccessChangeValues;
    public ChangeStateValueInfo[] FailChangeValues;
    private void Start()
    {
        InteractItem = GetComponent<InteractItem_Base>();
        InteractItem.InteractEndEvent += OnEndInteract;
    }

    private void OnEndInteract(Character_Base character, bool success)
    {
        CharacterState_Base CState = character.GetComponent<CharacterState_Base>();

        if (success)
        {            
            foreach (ChangeStateValueInfo info in SuccessChangeValues)
            {
                switch (info.valueType)
                {
                    case StateValueType.Stamina:
                        CState.AIStamina += info.amount;
                        break;
                }
            }
        }
        else
        {
            foreach (ChangeStateValueInfo info in FailChangeValues)
            {
                switch (info.valueType)
                {
                    case StateValueType.Stamina:
                        CState.AIStamina += info.amount;
                        break;
                }
            }
        }
    }

}

[System.Serializable]
public class ChangeStateValueInfo
{
    public StateValueType valueType;
    public float amount;
}
public enum StateValueType
{
    Stamina,
}
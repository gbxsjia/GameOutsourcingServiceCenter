using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public static InteractManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            int count = (int)InteractItemType.End;
            AllInteractItems = new List<InteractItem_Base>[count];
            for (int i = 0; i < count; i++)
            {
                AllInteractItems[i] = new List<InteractItem_Base>();
            }
        }
    }

    private List<InteractItem_Base>[] AllInteractItems;
    public void RegistItem(InteractItem_Base item)
    {
        AllInteractItems[(int)item.type].Add(item);
    }
    public void RemoveItem(InteractItem_Base item)
    {
        AllInteractItems[(int)item.type].Remove(item);
    }
    public List<InteractItem_Base> GetItemList(InteractItemType type)
    {
        return AllInteractItems[(int)type];
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPerception : MonoBehaviour
{
    public List<InteractItem_Base> ItemsInSight;

    public event System.Action<InteractItem_Base> NewItemEnterEvent;
    public event System.Action<InteractItem_Base> ItemExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        InteractItem_Base item = other.GetComponent<InteractItem_Base>();
        if (item)
        {
            ItemsInSight.Add(item);
            NewItemEnterEvent(item);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        InteractItem_Base item = other.GetComponent<InteractItem_Base>();
        if (item)
        {
            ItemsInSight.Remove(item);
            ItemExitEvent(item);
        }
    }
}
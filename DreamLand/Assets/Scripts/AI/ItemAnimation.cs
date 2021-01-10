using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    public InteractItem_Base InteractItem;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        InteractItem = GetComponent<InteractItem_Base>();
        InteractItem.InteractStartEvent += OnStartInteract;
        InteractItem.InteractEndEvent += OnEndInteract;
    }

    private void OnEndInteract(Character_Base character,bool success)
    {
        animator.SetTrigger("End");
    }

    private void OnStartInteract(Character_Base obj)
    {
        animator.SetTrigger("Start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Character_Base character;
    private void Start()
    {
        character = GetComponent<Character_Base>();
    }
    private void Update()
    {
        Vector3 InputDirection = Vector3.forward;
        InputDirection.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        character.Move(InputDirection);
        if (InputDirection != Vector3.zero)
        {
            character.RotateTowards(transform.position + InputDirection);
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            character.AttackCommand();
        }
    }
}

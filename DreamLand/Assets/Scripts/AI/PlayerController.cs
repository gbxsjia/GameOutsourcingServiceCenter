using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask GroundLayer;
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

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,100000, GroundLayer))
            {
                if (hit.collider)
                {
                    character.AttackCommand(hit.point - character.transform.position);
                }          
            }
        }
    }
}

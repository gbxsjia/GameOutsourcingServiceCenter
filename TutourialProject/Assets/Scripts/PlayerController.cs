using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Character currentCharacter;

    public float FollowLagSpeed;
    private Vector3 CameraOffset;

    public GameObject MarioBodyPrefab;
    private bool isMarioBody = true;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CameraOffset = transform.position - currentCharacter.transform.position;
    }

    private void Update()
    {
        Vector3 inputDirection=Vector3.zero;

        inputDirection.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (currentCharacter != null)
        {
            currentCharacter.Move(inputDirection);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentCharacter != null)
            {
                currentCharacter.Attack();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            BackToMario();
        }
        // follow body

        transform.position = Vector3.Lerp(transform.position, currentCharacter.transform.position + CameraOffset, FollowLagSpeed);
    }

    public void ChangeBody(Character newBody)
    {
        Destroy(currentCharacter.gameObject);
        currentCharacter = newBody;
        isMarioBody = false;
    }

    public void BackToMario()
    {
        if (!isMarioBody)
        {
            Vector3 newPosition = currentCharacter.transform.position;
            Quaternion newRotation = currentCharacter.transform.rotation;
            Destroy(currentCharacter.gameObject);
            GameObject g = Instantiate(MarioBodyPrefab, newPosition, newRotation);
            currentCharacter = g.GetComponent<Character>();
            isMarioBody = true;
        }
    }
}

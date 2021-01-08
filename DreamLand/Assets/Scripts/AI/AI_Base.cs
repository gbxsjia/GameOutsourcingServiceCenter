using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base : MonoBehaviour
{
    public Character_Base character;
    public CharacterState_Base state;
    public AIPerception perception;

    public AI_Mission_Base currentMission;
    public AI_Mission_Base defaultMission;

    private void Awake()
    {
        PossessCharacter(gameObject);
    }

    private void Start()
    {
   
    }
    public void StartDefaultMission()
    {
        defaultMission = new Mission_GetResource(InteractItemType.Resource, InteractItemType.House);
        StartNewMission(defaultMission);
    }

    public void PossessCharacter(GameObject target)
    {
        character = target.GetComponent<Character_Base>();
        state = target.GetComponent<CharacterState_Base>();
    }

    public void StartNewMission(AI_Mission_Base mission)
    {
        if (currentMission != null)
        {
            currentMission.MissionAbort(this, character, mission);
        }
        currentMission = mission;
        currentMission.MissionStart(this, character);
    }

    private void Update()
    {
        if (currentMission!=null)
        {
            currentMission.MissionUpdate(this, character);
        }      
    }

    public void MissionEnd(AI_Mission_Base mission, bool result)
    {
        currentMission = null;
    }


}

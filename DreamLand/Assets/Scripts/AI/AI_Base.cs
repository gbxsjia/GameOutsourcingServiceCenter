﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base : MonoBehaviour
{
    public Character_Base character;
    public CharacterState_Base state;


    public AI_Mission_Base currentMission;
    public AI_Mission_Base defaultMission;

    public PatrolPath[] Paths;

    public WorkType workType;

    public GameObject SharedTarget;

    private void Awake()
    {
        PossessCharacter(gameObject);
        StartCoroutine(LateStart());
      
    }

    private void Update()
    {
        if (currentMission != null)
        {
            currentMission.MissionUpdate(this, character);
        }
    }
    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1);
        GetNewMission();
    }

    public void PossessCharacter(GameObject target)
    {
        character = target.GetComponent<Character_Base>();
        state = target.GetComponent<CharacterState_Base>();
    }

    public void StartNewMission(AI_Mission_Base mission, int Priority=0)
    {
        mission.Priority = Priority;
        int oldPriority = -1;
        if (currentMission != null)
        {
            oldPriority = currentMission.Priority;
        }

        if (Priority > oldPriority)
        {
            if (currentMission != null)
            {
                currentMission.MissionAbort(this, character, mission);
            }

            currentMission = mission;
            currentMission.MissionStart(this, character);
        }
    }



    public void MissionEnd(AI_Mission_Base mission, bool result)
    {
        currentMission = null;
        GetNewMission();
    }

    public void GetNewMission()
    {

        switch (workType)
        {
            case WorkType.Farmer:
                if (state.AIStamina <= 40)
                {
                    StartNewMission(new Mission_UseItem(InteractItemType.House));
                }
                else
                {
                    StartNewMission(new Mission_GetResource(InteractItemType.Resource, InteractItemType.Chest));
                }
                break;

            case WorkType.Patroller:
                StartNewMission(new Mission_Patrol(Paths, 3));
                break;
            case WorkType.Guardian:
                StartNewMission(new Mission_Guard(SharedTarget, 0, 2));
                break;
        }
    }


}
public enum WorkType
{
    Farmer,
    Guardian,
    Patroller
}
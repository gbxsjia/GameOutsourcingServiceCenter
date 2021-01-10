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

    public PatrolPath[] Paths;

    public WorkType workType;

    private void Awake()
    {
        PossessCharacter(gameObject);
        StartCoroutine(LateStart());
        perception.NewCharacterEnterEvent += OnNewCharacterEnter;
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

    public void StartNewMission(AI_Mission_Base mission)
    {
        int oldPriority = -1;
        if (currentMission != null)
        {
            oldPriority = currentMission.Priority;
        }

        if (mission.Priority > oldPriority)
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

            case WorkType.Guardian:
                StartNewMission(new Mission_Patrol(Paths, 3));
                break;
        }

    }

    #region Events
    private void OnNewCharacterEnter(Character_Base character)
    {
        if (character.CState.Camp != state.Camp)
        {
            AI_Mission_Base scaredRun = new Mission_ScaredRunBack(character.transform);
            scaredRun.Priority = 10;
            StartNewMission(scaredRun);
        }
    }

    #endregion
}
public enum WorkType
{
    Farmer,
    Guardian
}
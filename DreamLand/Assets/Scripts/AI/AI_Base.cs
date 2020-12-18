using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base : MonoBehaviour
{
    public Character_Base character;
    public CharacterState_Base state;
    public AIPerception perception;

    public AI_Mission_Base currentMission;

    private void Awake()
    {
        PossessCharacter(gameObject);
    }
    public void PossessCharacter(GameObject target)
    {
        character = target.GetComponent<Character_Base>();
        state = target.GetComponent<CharacterState_Base>();
    }
    private void Start()
    {
        if (currentMission != null)
        {
            currentMission = new Mission_MoveTo(new Vector3(-2, 0, -5));
            currentMission.MissionStart(this, character);
        }

        perception.NewItemEnterEvent += OnItemEnter;
    }

    private void OnItemEnter(InteractItem_Base item)
    {
        if (currentMission==null)
        {
            currentMission = item.GetMission();
            currentMission.MissionStart(this,character);
        }
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

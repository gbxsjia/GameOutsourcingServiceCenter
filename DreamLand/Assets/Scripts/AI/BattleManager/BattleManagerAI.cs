using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagerAI : MonoBehaviour
{
    public int camp;
    private List<Character_Base> AllyCharacters = new List<Character_Base>();
    private List<AI_Base> AIBrains = new List<AI_Base>();
    private List<Character_Base> EnemyCharacters = new List<Character_Base>();

    private List<InteractItem_Base> AllItems = new List<InteractItem_Base>();

    private List<Transform> PossibleSlots = new List<Transform>();

    public float CoverHeight;
    public float EyeHeight;

    public bool IsSlotValid(Transform slot, bool needCover, bool canSeeEnemy, float minDistance, float maxDistance)
    {
        Vector3 enemyPos = EnemyCharacters[0].transform.position;
        float dis = Vector3.Distance(enemyPos, slot.position);
        if (dis < minDistance || dis > maxDistance)
        {
            return false;
        }

        if (needCover)
        {
            RaycastHit hit;
            if(!Physics.Raycast(slot.transform.position + Vector3.up *CoverHeight, enemyPos + Vector3.up * CoverHeight - slot.transform.position, out hit, 1))
            {
                //Debug.DrawLine(slot.transform.position + Vector3.up * CoverHeight, (enemyPos + Vector3.up * CoverHeight - slot.transform.position).normalized*1 + slot.transform.position + Vector3.up * CoverHeight, Color.red, 10f);
                return false;
            }
            else
            {
                //Debug.DrawLine(slot.transform.position + Vector3.up * CoverHeight, hit.point, Color.green, 10f);
            }
        }

        Debug.DrawLine(slot.transform.position, slot.transform.position + Vector3.up , Color.blue, 10f);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character_Base character = other.GetComponent<Character_Base>();
        if (character)
        {
            if (character.Camp == camp)
            {
                AllyCharacters.Add(character);
                AIBrains.Add(character.GetComponent<AI_Base>());
            }
            else
            {
                EnemyCharacters.Add(character);
            }
            return;
        }
        InteractItem_Base item = other.GetComponentInParent<InteractItem_Base>();
        if (item && !AllItems.Contains(item))
        {
            AllItems.Add(item);
        }
    }
    public void SetSurround()
    {
        PossibleSlots.Clear();
        foreach(InteractItem_Base item in AllItems)
        {
            foreach(Transform slot in item.InteractSlots)
            {
                if (IsSlotValid(slot, true, true, 3, 10))
                {
                    PossibleSlots.Add(slot);
                }
            }
        }

        foreach(AI_Base ai in AIBrains)
        {
            Transform t = GetNearestSlot(ai.transform.position);
            if (t != null)
            {
                Debug.DrawLine(t.position, t.position + Vector3.up, Color.green, 10f);
                PossibleSlots.Remove(t);
                ai.currentMission = new Mission_MoveTo(t.position, true, EnemyCharacters[0].transform);
                ai.currentMission.MissionStart(ai, ai.character);
            }
          
        }
    }
    public Transform GetNearestSlot(Vector3 origin)
    {
        float minDis = Mathf.Infinity;
        Transform result = null;
        foreach(Transform slot in PossibleSlots)
        {
            float newDis = Vector3.Distance(slot.position, origin);
            if (newDis <= minDis)
            {
                result = slot;
                minDis = newDis;
            }
        }
        return result;
    }

}

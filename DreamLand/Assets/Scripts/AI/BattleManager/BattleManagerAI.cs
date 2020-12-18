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

    public void UpdateSlots()
    {
        PossibleSlots.Clear();
        foreach (InteractItem_Base item in AllItems)
        {
            PossibleSlots.AddRange(item.InteractSlots);
        }
    }

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
            if(Physics.Raycast(slot.transform.position + Vector3.up *CoverHeight, enemyPos-slot.transform.position, 1))
            {

            }
        }

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
        InteractItem_Base item = other.GetComponent<InteractItem_Base>();
        if (item)
        {
            AllItems.Add(item);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagerAI : MonoBehaviour
{
    public int camp;
    private List<Character_Base> AllyCharacters = new List<Character_Base>();
    private List<AI_Base> AIBrains = new List<AI_Base>();
    private List<Character_Base> EnemyCharacters = new List<Character_Base>();

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
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Reaction : MonoBehaviour
{
    [SerializeField]
    private AI_Base brain;
    [SerializeField]
    private AIPerception perception;

    public ReactionPair[] InitialReactionConfig;
    private Dictionary<StimulusType, ReactionType> ReactionConfigs= new Dictionary<StimulusType, ReactionType>();
    private void Awake()
    {
        for (int i = 0; i < InitialReactionConfig.Length; i++)
        {
            ReactionConfigs.Add(InitialReactionConfig[i].stimulus, InitialReactionConfig[i].reaction);
        }
        if (brain == null)
        {
            brain = GetComponent<AI_Base>();
        }
        if (perception == null)
        {
            perception = GetComponentInChildren<AIPerception>();
        }
        perception.NewCharacterEnterEvent += OnNewCharacterEnter;
    }

    #region Events
    private void OnNewCharacterEnter(Character_Base character)
    {
        if (!ReactionConfigs.ContainsKey(StimulusType.SeeEnemy))
        {
            return;
        }
        if (character.CState.Camp != brain.state.Camp)
        {
            OnEnemyEnter(character);
        }
    }
    private void OnEnemyEnter(Character_Base character)
    {
        switch (ReactionConfigs[StimulusType.SeeEnemy])
        {
            case ReactionType.RunAway:
                AI_Mission_Base scaredRun = new Mission_ScaredRunBack(character.transform);
                brain.StartNewMission(scaredRun, 10);
                break;
            case ReactionType.ChaseAttack:
                brain.StartNewMission(new Mission_ChaseAttack(character), 10);
                break;
        }
    }
    private void OnAllyEnter(Character_Base character)
    {

    }
    #endregion
}

public enum StimulusType
{
    SeeEnemy,
    SeeAlly,
}
public enum ReactionType
{
    RunAway,
    ChaseAttack
}
[System.Serializable]
public class ReactionPair
{
    public StimulusType stimulus;
    public ReactionType reaction;
}
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
        switch (ReactionConfigs[StimulusType.SeeEnemy])
        {
            case ReactionType.RunAway:
                if (character.CState.Camp != brain.state.Camp)
                {
                    AI_Mission_Base scaredRun = new Mission_ScaredRunBack(character.transform);
                    scaredRun.Priority = 10;
                    brain.StartNewMission(scaredRun);
                }
                break;
        }
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
    RunAway
}
[System.Serializable]
public class ReactionPair
{
    public StimulusType stimulus;
    public ReactionType reaction;
}
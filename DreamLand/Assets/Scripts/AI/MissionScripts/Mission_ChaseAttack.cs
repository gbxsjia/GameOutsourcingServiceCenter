using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_ChaseAttack : AI_Mission_Base
{
    public Character_Base Enemy;
    public Mission_ChaseAttack(Character_Base enemy)
    {
        Enemy = enemy;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        AddNewAction(new Action_MoveFollow(Enemy, ownerCharacter.GetAttackRange(), 1f));
        AddNewAction(new Action_Attack(Enemy.transform));
    }
    public override void ActionFinish(AI_Action_Base action, bool success)
    {
        currentAction = null;
        if (Enemy == null || !Enemy.CState.isAlive)
        {
            MissionEnd(ownerBrain, ownerCharacter);
        }

        if (ActionList.Count > 0)
        {
            ActionStart();
        }
        else
        {
            SetUpActions();
            ActionStart();
        }
    }
}

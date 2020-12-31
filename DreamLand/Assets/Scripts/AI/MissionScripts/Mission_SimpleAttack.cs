using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_SimpleAttack : AI_Mission_Base
{
    public int Times;
    public Mission_SimpleAttack(int times)
    {
        Times = times;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();

        for (int i = 0; i < Times; i++)
        {
            AddNewAction(new Action_Attack());
        }
    }
}

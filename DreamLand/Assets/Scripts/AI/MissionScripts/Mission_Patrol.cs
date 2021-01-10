using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Patrol : AI_Mission_Base
{
    public PatrolPath[] PatrolPaths;
    public float StayDuration;
    public Mission_Patrol(PatrolPath[] Paths, float stayDuration)
    {
        PatrolPaths = Paths;
        StayDuration = stayDuration;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        AddNewAction(new Action_PatrolMove(PatrolPaths[0].Path));
    }
}

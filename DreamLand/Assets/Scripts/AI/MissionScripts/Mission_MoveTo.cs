using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mission_MoveTo : AI_Mission_Base
{
    public Vector3 TargetPosition;
    public bool UseNavigation;

    public Mission_MoveTo(Vector3 position, bool useNavigation=false)
    {
        TargetPosition = position;
        UseNavigation = useNavigation;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        AddNewAction(new Action_RotateTowards(TargetPosition, 5));
        if (UseNavigation)
        {
            AddNewAction(new Action_NavigaitionTo(TargetPosition, 1f));
        }
        else
        {
            AddNewAction(new Action_Moveto(TargetPosition, 1.5f));
        }
     
    }
}

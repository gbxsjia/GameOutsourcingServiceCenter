using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mission_MoveTo : AI_Mission_Base
{
    public Vector3 TargetPosition;
    public bool UseNavigation;
    public Transform FocusTarget;

    public Mission_MoveTo(Vector3 position, bool useNavigation=false, Transform focusTarget=null)
    {
        TargetPosition = position;
        UseNavigation = useNavigation;
        FocusTarget = focusTarget;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();

        if (UseNavigation)
        {
            AddNewAction(new Action_NavigaitionTo(TargetPosition, 0.4f));
        }
        else
        {
            AddNewAction(new Action_Moveto(TargetPosition, 0.4f));
        }
   
    }
}

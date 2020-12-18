using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Mission/MoveTo")]
public class Mission_MoveTo : AI_Mission_Base
{
    public Vector3 TargetPosition;

    public Mission_MoveTo(Vector3 position)
    {
        TargetPosition = position;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        AddNewAction(new Action_RotateTowards(TargetPosition, 5));
        AddNewAction(new Action_Moveto(TargetPosition,1.5f));
    }
}

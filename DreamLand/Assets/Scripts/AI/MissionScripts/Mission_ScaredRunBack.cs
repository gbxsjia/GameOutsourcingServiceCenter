using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_ScaredRunBack : AI_Mission_Base
{
    public Transform ScaringTransform;
    public Mission_ScaredRunBack(Transform scaringTransform)
    {
        ScaringTransform = scaringTransform;
    }
    public override void SetUpActions()
    {
        base.SetUpActions();
        AddNewAction(new Action_ScaredJump(ScaringTransform));
        AddNewAction(new Action_Moveto((ownerCharacter.transform.position - ScaringTransform.position).normalized*5f + ownerCharacter.transform.position, 1f));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_SetFocusTarget : AI_Action_Base
{
    public Transform FocusTarget;
    public Action_SetFocusTarget(Transform target)
    {
        FocusTarget = target;
        ActionFinish();
    }

}

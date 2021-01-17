using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_PatrolMove :AI_Action_Base
{
    public Vector3[] Path;
    public Action_PatrolMove(Vector3[] path)
    {
        Path = path;
    }

    public int WaypointIndex;

    public override void ActionUpdate(AI_Base brain, Character_Base character)
    {
        base.ActionUpdate(brain, character);

        Vector3 TargetPosition = Path[WaypointIndex];

        character.Move(TargetPosition - character.transform.position);
        if (Vector3.Distance(character.transform.position, TargetPosition) <= 1)
        {
            WaypointIndex++;
            if (WaypointIndex >= Path.Length)
            {
                ActionFinish();
            }
        }
    }

    public override void BeforeExit()
    {
        base.BeforeExit();
        Character.Move(Vector3.zero);
    }
}

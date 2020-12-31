using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDebuger : MonoBehaviour
{
    public bool debugMode;
    public LayerMask mask;
    private void Update()
    {
        if (debugMode && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,mask))
            {
                AI_Base ai = hit.collider.GetComponent<AI_Base>();
                if (ai)
                {
                    Debug.Log("Mission: " + ai.currentMission);
                    for (int i = 0; i < ai.currentMission.ActionList.Count; i++)
                    {
                        Debug.Log("Action: " + ai.currentMission.ActionList[i]);
                    }
                }
            }
        }
    }
}

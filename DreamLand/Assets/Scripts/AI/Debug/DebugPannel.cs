using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPannel : MonoBehaviour
{
    public Text CurrentMissionText;
    public Text[] ActionListText;

    public AI_Base DebugAI;
      

    public void Update()
    {
        if (DebugAI)
        {
            AI_Mission_Base mission =DebugAI.currentMission;
            if (mission!=null)
            {
                CurrentMissionText.text = mission.ToString();
                if (mission.GetCurrentAction()!=null)
                {
                    ActionListText[0].text = mission.GetCurrentAction().ToString();
                }
                for (int i = 1; i < ActionListText.Length; i++)
                {
                    if (i <= mission.ActionList.Count)
                    {
                        ActionListText[i].text = mission.ActionList[i - 1].ToString();
                        ActionListText[i].color = new Color(0.3f, 0.3f, 0.3f);
                    }
                    else
                    {
                        ActionListText[i].text = "";
                    }
                }
            }
        }
    }
}

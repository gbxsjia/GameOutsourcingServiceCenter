using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_UnitBar : MonoBehaviour
{
    public Image HealthFill;
    public TextMeshProUGUI HealthText;

    public Image WillPowerFill;

    public CharacterState_Base attributes;
    public Character_Base character;

    [SerializeField]
    Vector3 offset;


    public void SetOwner(Character_Base c, CharacterState_Base cState)
    {
        character = c;
        attributes = cState;
    }
    private void Update()
    {
        if (!character || !attributes)
        {
            return;
        }

        WillPowerFill.fillAmount = attributes.WillPowerCurrent / attributes.WillPowerMax;


        HealthFill.fillAmount = (float)attributes.HealthCurrent / (float)attributes.HealthMax;
        HealthText.text = attributes.HealthCurrent.ToString();

        transform.position = character.transform.position + offset;
    }
}

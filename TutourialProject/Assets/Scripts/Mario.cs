using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : Character
{
    public GameObject HatPrefab;

    public bool hasHat=true;
    public override void Attack()
    {
        base.Attack();
        if (hasHat)
        {
            GameObject g = Instantiate(HatPrefab, transform.position + transform.forward * 1f, transform.rotation);
            hasHat = false;
        }       
    }

    public void HatBack(Hat theHat)
    {
        hasHat = true;
        Destroy(theHat.gameObject);
    }
}

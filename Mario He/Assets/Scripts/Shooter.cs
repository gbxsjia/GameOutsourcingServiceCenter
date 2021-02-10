using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Character

{
    public GameObject BulletPrefab;
    private void Update()
    { 
    if (Input.GetMouseButtonDown(1))
        {
         Attack();
         
        }
    }

    public override void Attack()
    {
     base.Attack();

     GameObject g = Instantiate(BulletPrefab, transform.position + transform.forward * 1f, transform.rotation);

        
    }


}

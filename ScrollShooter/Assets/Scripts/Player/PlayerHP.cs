using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHP : Damageble
{
    public override void TakeDamage()
    {
        base.TakeDamage();       
        
        rb.AddForce(Vector2.up * 100 * Time.deltaTime, ForceMode2D.Impulse);  //подпрыгивает от получения урона
    }   
}

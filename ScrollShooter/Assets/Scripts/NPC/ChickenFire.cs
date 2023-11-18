using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFire : BaseChickenEnemy
{    
    [Header("Fire Settings")]
    [SerializeField] private FireBullet fireBullet;
    [SerializeField] private Transform firePoint;

    private void Awake()
    {
        StartCoroutine(Fire());
    }
    
    private IEnumerator Fire()
    {      
        for(;;)
        {
            FireBullet newBullet = Instantiate(fireBullet, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
        
    }
}

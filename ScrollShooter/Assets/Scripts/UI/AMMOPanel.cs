using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMMOPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] ammoImgs;
    [SerializeField] private Animation ChargingAnim;
    [SerializeField] private PlayerShoot player;

    /// <summary>
    /// Уменьшение патронов при стрельбе
    /// </summary>
    public void AmmoDecrease()
    {
        for (int i = ammoImgs.Length-1; i >= 0; i--)
        {
            CheckCanAttack();
            if (ammoImgs[i].activeInHierarchy)
            {
                    ammoImgs[i].SetActive(false);                    
                    break;
            } 
        }
    }

    /// <summary>
    /// Проверка на наличие патронов
    /// </summary>
    private void CheckCanAttack()
    {
        if (!ammoImgs[1].activeInHierarchy)
        {
            player.OnRechargeStart?.Invoke();
            ChargingAnim.Play();
        }        
    }   

    public void RechargingEnded()
    {
        player.OnRechargeEnd?.Invoke();
    }
   
}

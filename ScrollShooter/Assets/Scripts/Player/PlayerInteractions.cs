using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractions : MonoBehaviour
{
    public UnityEvent OnTakeCoin;
    private Damageble player;

    private bool canTakeDamage = true;

    private void Start()
    {
        player = GetComponent<PlayerHP>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy_1") && canTakeDamage)
        {
            player.OnTakeDamage?.Invoke();
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Поднятие аптечки
        if (collision.gameObject.CompareTag("med"))
        {
            player.OnTakeHP?.Invoke();
            collision.gameObject.SetActive(false);
        }

        //Поднятие монеты
        if (collision.gameObject.CompareTag("coin") && collision.gameObject.TryGetComponent<Coin>(out var coin))
        {
            OnTakeCoin?.Invoke();            
            coin.CoinTaked();
            Destroy(coin, 1f);            
        }
    }

    #region INVISFRAME
    public void InvisFrameON()
    {
        canTakeDamage = false;
    }

    public void InvisFrameOFF()
    {
        canTakeDamage = true;
    }
    #endregion
}

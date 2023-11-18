using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageble : MonoBehaviour
{
    [SerializeField] private int hp;

    public UnityEvent OnTakeDamage;
    public UnityEvent OnTakeHP;
    public UnityEvent OnDead;

    protected Animator anim;
    protected Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void TakeDamage()
    {
        hp--;
        anim.SetTrigger("damaged");
        CheckIsDead();
    }

    public virtual void TakeHP()
    {
        hp++;        
    }

    private void CheckIsDead()
    {
        if (hp <= 0) Dead();        
    }

    protected virtual void Dead()
    {
        OnDead?.Invoke();
    }
}

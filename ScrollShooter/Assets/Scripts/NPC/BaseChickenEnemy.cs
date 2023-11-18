using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChickenEnemy : Damageble
{   
    [Header("Move Settings")]
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected LayerMask groundMask;
        
    protected SpriteRenderer sr;
    protected AudioSource source;
    protected GameObject player;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SoundValue");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void FixedUpdate()
    {
        Move();
        Jump();
        PlayerPosCheck();              
    }

    /// <summary>
    /// Движение в сторону игрока
    /// </summary>
    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// Прыжок при столкновении со стеной
    /// </summary>
    protected virtual void Jump()
    {
        Collider2D ground = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 0.05f), new Vector3(0.25f, 0.045f, 1f), 0, groundMask);
        if (ground) rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Force);
    }

    /// <summary>
    /// Проверка позиции игрока и поворот в его сторону
    /// </summary>
    protected virtual void PlayerPosCheck()
    {
        if (player.transform.position.x > transform.position.x) sr.flipX = true;
        else sr.flipX = false;
    }

    protected override void Dead()
    {
        base.Dead();
        StopAllCoroutines();
        Destroy(gameObject, 0.1f);
    }   

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            OnTakeDamage?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}

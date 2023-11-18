using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float speed;    
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundMask;

    private bool onGround;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVector;

    public SpriteRenderer sr;
    public bool take_coin;
   
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Walk();
        Jump();
    }

    /// <summary>
    /// Движение игрока
    /// </summary>
    private void Walk()
    {
        moveVector.x = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        anim.SetFloat("velocity",Mathf.Abs(rb.velocity.x));
        SpriteDirectionCheck();
    }

    /// <summary>
    /// Прыжок игрока
    /// </summary>
    private void Jump()
    {
        onGround = Physics2D.OverlapCircle(transform.position, 0.05f , groundMask);
        if(Input.GetButtonDown(GlobalStringVars.JUMP) && onGround)
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Проверка направления движения
    /// </summary>
    private void SpriteDirectionCheck()
    {
        if (rb.velocity.x < 0) sr.flipX = true;
        else if (rb.velocity.x > 0) sr.flipX = false;       
    }    
}

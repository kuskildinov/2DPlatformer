using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private AudioSource source;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SoundValue");
        PlayerPosCheck();
        Destroy(gameObject, 1f);
    }

    /// <summary>
    /// Проверка позиции игрока
    /// </summary>
    private void PlayerPosCheck()
    {
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
            rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Force);            
        }
        else
        {
            sr.flipX = false;
            rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

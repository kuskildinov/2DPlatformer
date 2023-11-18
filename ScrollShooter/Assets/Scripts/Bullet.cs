using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private GameObject player;
    private Rigidbody2D rb;
    private AudioSource source;
    private bool PlayerLookRight;
    private Vector2 shootDirection;
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerLookRight = player.GetComponent<PlayerShoot>().PlayerLookRight;

        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SoundValue");

        rb = GetComponent<Rigidbody2D>();
        FireDirectionCheck();
        Destroy(gameObject, 0.5f);
    }

    public void FireDirectionCheck()
    {
        if (PlayerLookRight) shootDirection = Vector2.left;
        if (!PlayerLookRight) shootDirection = Vector2.right;
        rb.AddForce(shootDirection * bulletSpeed, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

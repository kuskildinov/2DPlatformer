using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinTaked;
    private AudioSource source;
    private Animator anim;
    public bool taked;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        source.volume = PlayerPrefs.GetFloat("SoundValue");
    }
    public void CoinTaked()
    {
        taked = true;
        anim.SetTrigger("taked");
        source.clip = coinTaked;
        source.Play();
    }
}

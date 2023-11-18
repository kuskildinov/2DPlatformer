using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    [SerializeReference] private AudioClip[] clips;
    [SerializeField] private AudioSource ChickensBackgroundSound;
    private AudioSource source;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        ChickensBackgroundSound.volume = PlayerPrefs.GetFloat("MusicValue");
        source.volume = PlayerPrefs.GetFloat("MusicValue");
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }
}

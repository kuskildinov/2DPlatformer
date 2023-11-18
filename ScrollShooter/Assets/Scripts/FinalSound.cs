using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSound : MonoBehaviour
{
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("MusicValue"); 
    }
}

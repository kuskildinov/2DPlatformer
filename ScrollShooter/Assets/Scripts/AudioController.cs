using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SoundSlider;
    
    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicValue");
        SoundSlider.value = PlayerPrefs.GetFloat("SoundValue");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("MusicValue", MusicSlider.value);
        PlayerPrefs.SetFloat("SoundValue", SoundSlider.value);
    }
}

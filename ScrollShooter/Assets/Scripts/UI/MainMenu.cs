using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text versText;

    private AudioSource source;
    private void Start()
    {
        versText.text = "vers." + Application.version;
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        source.volume = PlayerPrefs.GetFloat("MusicValue");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

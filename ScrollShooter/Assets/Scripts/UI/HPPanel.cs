using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] heartImgs;

    public void DecreaseHeartWhenPlayerDamaged()
    {
        for (int i = heartImgs.Length - 1; i >= 0; i--)
        {
            if (heartImgs[i].activeInHierarchy)
            {
                heartImgs[i].SetActive(false);              
                break;
            }
        }
    }

    public void AddHeartWhenPlayerTakeMED()
    {
        for (int i = heartImgs.Length - 1; i >= 0; i--)
        {
            if (heartImgs[i].activeInHierarchy && i < heartImgs.Length - 1)
            {
                heartImgs[i + 1].SetActive(true);
                break;
            }
        }
    }   
}

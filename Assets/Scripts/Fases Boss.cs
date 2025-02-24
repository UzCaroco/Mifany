using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasesBoss : MonoBehaviour
{
    [SerializeField] Sprite[] imagensbackground;
    [SerializeField] GameObject[] Boss;
    [SerializeField] SpriteRenderer renderBackground;
    void Start()
    {
        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            renderBackground.sprite = imagensbackground[0];

            Boss[0].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            renderBackground.sprite = imagensbackground[1];
            Boss[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            renderBackground.sprite = imagensbackground[2];
            Boss[2].SetActive(true);
        }
    }



}

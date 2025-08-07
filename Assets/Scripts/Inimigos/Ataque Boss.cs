using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBoss : MonoBehaviour
{
    [SerializeField] GameObject[] objForDesable;
    Animator ani;
    [SerializeField] CutsceneSitonus CutsceneSitonus;
    
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Atacar()
    {
        ani.SetTrigger("IsAttack");
    }

    public void Morrer()
    {
        for (int i = 0; i < objForDesable.Length; i++)
        {
            objForDesable[i].SetActive(false);
        }
        
        ani.SetTrigger("IsDead");

        //PlayerPrefs.SetInt("ConclusaoDeFase", PlayerPrefs.GetInt("ConclusaoDeFase") + 1);
        switch (PlayerPrefs.GetInt("ConclusaoDaFase"))
        {
            case 0:
                if (PlayerPrefs.GetInt("FaseAtual") == 1)
                {
                    PlayerPrefs.SetInt("ConclusaoDaFase", 1);
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("FaseAtual") == 2)
                {
                    PlayerPrefs.SetInt("ConclusaoDaFase", 2);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("FaseAtual") == 3)
                {
                    PlayerPrefs.SetInt("ConclusaoDaFase", 3);
                }
                break;
        }
        Debug.Log("ConclusaoDaFase: " + PlayerPrefs.GetInt("ConclusaoDaFase"));
    }

    public void AtivarCutscene()
    {
        CutsceneSitonus.AtivarCutscene();
        

        gameObject.SetActive(false);
    }
}

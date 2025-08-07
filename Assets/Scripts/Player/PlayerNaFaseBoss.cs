using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNaFaseBoss : MonoBehaviour
{
    [SerializeField] byte indexPhase;
    Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Atacar()
    {
        ani.SetTrigger("IsAttack");
    }

    public void AtivarCutscenePlayer()
    {
        ani.SetTrigger("Cutscene");
    }

    public void CarregarNovaCena()
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            PlayerPrefs.SetInt("FaseAtual", 2);


            if (PlayerPrefs.GetInt("choosePhase") == 1)
            {
                PlayerPrefs.SetInt("choosePhase", 2);
            }

            SceneManager.LoadScene(indexPhase);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            PlayerPrefs.SetInt("FaseAtual", 3);

            if (PlayerPrefs.GetInt("choosePhase") == 2)
            {
                PlayerPrefs.SetInt("choosePhase", 3);
            }

            SceneManager.LoadScene(indexPhase);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            SceneManager.LoadScene(0);
        }
    }
}

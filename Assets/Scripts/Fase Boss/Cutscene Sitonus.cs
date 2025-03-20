using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSitonus : MonoBehaviour
{
    [SerializeField] byte indexPhase;
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    
    public void AtivarCutscene()
    {
        ani.SetTrigger("Cutscene");
    }

    public void CarregarNovaCena()
    {
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

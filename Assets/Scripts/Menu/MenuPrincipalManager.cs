using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private Button resetBtn, faseBtn;
    [SerializeField] private byte[] levelDoJogo;
    [SerializeField] private string menu;

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCreditos;
    [SerializeField] private GameObject painelReset;

    private void Start()
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (!PlayerPrefs.HasKey("choosePhase"))
        {
            PlayerPrefs.SetInt("choosePhase", 1);

            resetBtn.interactable = false;
            faseBtn.interactable = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("FaseAtual") >= 1)
            {
                faseBtn.interactable = true;
                resetBtn.interactable = true;
            }
            else
            {
                faseBtn.interactable = false;
                resetBtn.interactable = false;
            }
        }
    }

    public void Jogar()
    {
        if (!PlayerPrefs.HasKey("FaseAtual"))
        {
            PlayerPrefs.SetInt("FaseAtual", 1);

            SceneManager.LoadScene(levelDoJogo[0]);
        }
        else
        {
            SceneManager.LoadScene(levelDoJogo[0]);
        }

        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

    }
    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void AbrirCreditos()
    {
        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(true);
    }
    public void FecharCreditos()
    {
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
    }
     public void AbrirReset()
    {
        painelMenuInicial.SetActive(false);
        painelReset.SetActive(true);
    }
    public void FecharReset()
    {
        painelMenuInicial.SetActive(true);
        painelReset.SetActive(false);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteKey("choosePhase");
        PlayerPrefs.DeleteKey("FaseAtual");
        PlayerPrefs.Save();

        resetBtn.interactable = false;
        faseBtn.interactable = false;

        FecharReset();
    }

    public void LoadScenePhases()
    {
        SceneManager.LoadScene(levelDoJogo[1]);
    }

    public void SairdoJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }
}

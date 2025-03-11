using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private byte[] levelDoJogo;
    [SerializeField] private string menu;

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCreditos;

    private void Start()
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (!PlayerPrefs.HasKey("choosePhase"))
        {
            PlayerPrefs.SetInt("choosePhase", 1);
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
            SceneManager.LoadScene(levelDoJogo[1]);
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

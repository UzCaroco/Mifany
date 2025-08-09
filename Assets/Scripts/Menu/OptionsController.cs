using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject btnPause;
    [SerializeField] GameObject PainelOpcoes;
    [SerializeField] GameObject PainelConfiguracao;

    [SerializeField] private string menu;

    [SerializeField] music musicScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            AbrirOpcoes();
        }
    }

    public void AbrirOpcoes()
    {
        PainelOpcoes.SetActive(true);
        Time.timeScale = 0f;

        if (btnPause != null)
        {
            btnPause.SetActive(false);
        }
        if (audioSource != null)
        {
            audioSource.Pause();
        }

    }
    public void FecharOpcoes()
    {
        PainelOpcoes.SetActive(false);
        PainelConfiguracao.SetActive(false);
        Time.timeScale = 1f;

        if (btnPause != null)
        {
            btnPause.SetActive(true);
        }
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (musicScript != null)
        {
            musicScript.jogoPausado = false;
        }
    }

    public void AbrirConfiguracao()
    {
        PainelOpcoes.SetActive(false);
        PainelConfiguracao.SetActive(true);
    }
    public void FecharConfiguracao()
    {
        PainelConfiguracao.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }
    
    void OnApplicationFocus(bool temFoco)
    {
        if (!temFoco)
        {
            PausarJogo();
        }
    }

    void OnApplicationPause(bool pausado)
    {
        if (pausado)
        {
            PausarJogo();
        }
    }

    void PausarJogo()
    {
        AbrirOpcoes();
        musicScript.jogoPausado = true;
    }
}

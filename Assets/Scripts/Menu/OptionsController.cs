using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] GameObject PainelOpcoes;
    [SerializeField] GameObject PainelConfiguracao;

    [SerializeField] private string menu;

    // Update is called once per frame
    void Update()
    {
        AbrirOpcoes();
    }

    void AbrirOpcoes()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PainelOpcoes.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void FecharOpcoes()
    {
        PainelOpcoes.SetActive(false);
        PainelConfiguracao.SetActive(false);
        Time.timeScale = 1f;
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
}

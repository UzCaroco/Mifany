using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] GameObject PainelOpcoes;
    [SerializeField] GameObject PainelConfiguracao;

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
            Debug.Log("ola");
        }
    }
    public void FecharOpcoes()
    {
        Debug.Log("oi");
        PainelOpcoes.SetActive(false);
        PainelConfiguracao.SetActive(false);
    }

    public void AbrirConfiguracao()
    {
        Debug.Log("aqui");
        PainelOpcoes.SetActive(false);
        PainelConfiguracao.SetActive(true);
    }
    public void FecharConfiguracao()
    {
        PainelConfiguracao.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
}

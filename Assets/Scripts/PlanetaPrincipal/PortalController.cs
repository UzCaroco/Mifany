using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] MeshRenderer[] gameObjMaterialForChange;
    [SerializeField] Material CenarioCasasPretoBranco;
    [SerializeField] Material CenarioCasasColorido;
    [SerializeField] byte levelDoJogo;

    private void Start()
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));
        
        if (PlayerPrefs.GetInt("FaseAtual", 1) >= 3)
        {
            for (int i = 0; i < gameObjMaterialForChange.Length; i++)
            {
                gameObjMaterialForChange[i].material = CenarioCasasColorido;
            }
        }
        else
        {
            for (int i = 0; i < gameObjMaterialForChange.Length; i++)
            {
                gameObjMaterialForChange[i].material = CenarioCasasPretoBranco;
            }
        }
   }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("FaseAtual", 1) == 1)
                levelDoJogo = 3;

            else if (PlayerPrefs.GetInt("FaseAtual", 1) == 2)
                levelDoJogo = 5;

            else if (PlayerPrefs.GetInt("FaseAtual", 1) >= 3)
                levelDoJogo = 7;
        }

        SceneManager.LoadScene(levelDoJogo);
    }
}

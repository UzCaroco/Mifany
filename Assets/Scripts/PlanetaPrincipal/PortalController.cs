using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] byte levelDoJogo;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (collision.CompareTag("Player"))
            SceneManager.LoadScene(levelDoJogo);
    }
}

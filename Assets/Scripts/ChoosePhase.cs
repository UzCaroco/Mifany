using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePhase : MonoBehaviour
{
    [SerializeField] byte whatPhaseIs = 0;
    [SerializeField] GameObject ErroMassage;
    [SerializeField] byte indexPhase;

    [SerializeField] bool inside;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Progressão: " + PlayerPrefs.GetInt("choosePhase"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && inside)
        {
            switch (whatPhaseIs)
            {
                case 1:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 1)
                    {
                        SceneManager.LoadScene(indexPhase);
                        PlayerPrefs.SetInt("FaseAtual", 1);
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 2)
                    {
                        SceneManager.LoadScene(indexPhase);
                        PlayerPrefs.SetInt("FaseAtual", 2);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 3)
                    {
                        SceneManager.LoadScene(indexPhase);
                        PlayerPrefs.SetInt("FaseAtual", 3);
                    }
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputTutorial : MonoBehaviour
{
    [SerializeField] KeyCode key1, key2;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // Se estiver na cena do planeta
        {
            if (!PlayerPrefs.HasKey("InputTutorialCenaPlaneta"))
            {
                PlayerPrefs.SetInt("InputTutorialCenaPlaneta", 0);
            }

            if (PlayerPrefs.GetInt("InputTutorialCenaPlaneta") == 1) // Se o tutorial j� foi conclu�do
            {
                Destroy(gameObject);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3) // Se estiver na cena de correndo
        {
            if (!PlayerPrefs.HasKey("InputTutorialCenaCorrendo"))
            {
                PlayerPrefs.SetInt("InputTutorialCenaCorrendo", 0);
            }

            if (PlayerPrefs.GetInt("InputTutorialCenaCorrendo") == 1) // Se o tutorial j� foi conclu�do
            {
                Destroy(gameObject);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4) // Se estiver na cena do boss
        {
            if (!PlayerPrefs.HasKey("InputTutorialCenaBoss"))
            {
                PlayerPrefs.SetInt("InputTutorialCenaBoss", 0);
            }

            if (PlayerPrefs.GetInt("InputTutorialCenaBoss") == 1) // Se o tutorial j� foi conclu�do
            {
                Destroy(gameObject);
            }
        }


    }
    void Update()
    {
        if(Input.GetKeyDown(key1) || Input.GetKeyDown(key2))
        {
            Debug.Log("Key 1 pressed");

            if (SceneManager.GetActiveScene().buildIndex == 1) // Se estiver na cena do planeta
            {
                PlayerPrefs.SetInt("InputTutorialCenaPlaneta", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3) // Se estiver na cena de correndo
            {
                PlayerPrefs.SetInt("InputTutorialCenaCorrendo", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4) // Se estiver na cena do boss
            {
                PlayerPrefs.SetInt("InputTutorialCenaBoss", 1);
            }

            Destroy(gameObject);

        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (SceneManager.GetActiveScene().buildIndex == 4) // Se estiver na cena do boss
                {
                    PlayerPrefs.SetInt("InputTutorialCenaBoss", 1);
                }

                Destroy(gameObject);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Touch detected");

                if (SceneManager.GetActiveScene().buildIndex == 1) // Se estiver na cena do planeta
                {
                    PlayerPrefs.SetInt("InputTutorialCenaPlaneta", 1);
                }
                else if (SceneManager.GetActiveScene().buildIndex == 3) // Se estiver na cena de correndo
                {
                    PlayerPrefs.SetInt("InputTutorialCenaCorrendo", 1);
                }

                Destroy(gameObject);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePhase : MonoBehaviour
{
    [SerializeField] byte whatPhaseIs = 0;
    [SerializeField] GameObject ErroMassage;
    [SerializeField] string nameLevelPhase;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("choosePhase"))
        {
            PlayerPrefs.SetInt("choosePhase", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (whatPhaseIs)
            {
                case 1:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 1)
                        SceneManager.LoadScene(nameLevelPhase);
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 2)
                        SceneManager.LoadScene(nameLevelPhase);
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 3)
                        SceneManager.LoadScene(nameLevelPhase);
                    break;
            }
        }
    }
}

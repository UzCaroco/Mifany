using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePhase : MonoBehaviour
{
    [SerializeField] GameObject gameModePainel;
    Coroutine startCorou;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] spritesPortais = new Sprite[2];

    [SerializeField] byte whatPhaseIs = 0;
    [SerializeField] GameObject ErroMassage;
    [SerializeField] byte indexPhase;

    [SerializeField] bool inside;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log("Progress�o: " + PlayerPrefs.GetInt("choosePhase"));
        OpenPortal(PlayerPrefs.GetInt("choosePhase"));
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) && inside)
        {
            switch (whatPhaseIs)
            {
                case 1:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 1)
                    {
                        PlayerPrefs.SetInt("FaseAtual", 1); //3 e 4

                        if (PlayerPrefs.GetInt("ConclusaoDaFase") >= 1)
                        {
                            gameModePainel.SetActive(true);
                        }
                        else
                        {
                            indexPhase = 3;
                            startCorou = StartCoroutine(InsideThePortal());
                        }
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 2)
                    {
                        PlayerPrefs.SetInt("FaseAtual", 2); //5 e 6
                        
                        if (PlayerPrefs.GetInt("ConclusaoDaFase") >= 2)
                        {
                            gameModePainel.SetActive(true);
                        }
                        else
                        {
                            indexPhase = 5;
                            startCorou = StartCoroutine(InsideThePortal());
                        }
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("choosePhase", 1) >= 3)
                    {
                        PlayerPrefs.SetInt("FaseAtual", 3); //7 e 8
                        
                        if (PlayerPrefs.GetInt("ConclusaoDaFase") >= 3)
                        {
                            gameModePainel.SetActive(true);
                        }
                        else
                        {
                            indexPhase = 7;
                            startCorou = StartCoroutine(InsideThePortal());
                        }
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

    public void ClosePainelGameMode()
    {
        gameModePainel.SetActive(false);
    }

    public void StartCoroutineForChangeScene(int playerChoose)
    {
        if (PlayerPrefs.GetInt("FaseAtual", 1) == 1)
        {
            if (playerChoose == 2)
            {
                indexPhase = 4;
            }
            else
            {
                indexPhase = 3;
            }
        }
        else if (PlayerPrefs.GetInt("FaseAtual", 1) == 2)
        {
            if (playerChoose == 2)
            {
                indexPhase = 6;
            }
            else
            {
                indexPhase = 5;
            }
        }

        else if (PlayerPrefs.GetInt("FaseAtual", 1) == 3)
        {
            if (playerChoose == 2)
            {
                indexPhase = 8;
            }
            else
            {
                indexPhase = 7;
            }
        }

        startCorou = StartCoroutine(InsideThePortal());
    }

    IEnumerator InsideThePortal()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(indexPhase);
    }

    void OpenPortal(int progressaoFase)
    {
        switch (progressaoFase) {
            case 1:
                if (whatPhaseIs == 1)
                {
                    spriteRenderer.sprite = spritesPortais[1];
                    spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    spriteRenderer.sprite = spritesPortais[0];
                    spriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
                }
            break;
            
            case 2:
                if (whatPhaseIs <= 2)
                {
                    spriteRenderer.sprite = spritesPortais[1];
                    spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    spriteRenderer.sprite = spritesPortais[0];
                    spriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
                }
                break;
            
            case 3:
                if (whatPhaseIs <= 3)
                {
                    spriteRenderer.sprite = spritesPortais[1];
                    spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    spriteRenderer.sprite = spritesPortais[0];
                    spriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
                }
            break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayC : MonoBehaviour
{
    [SerializeField] byte indexPhase;

    [SerializeField] LayerMask layer;
    [SerializeField] GameObject poderMifany, poderInimigo;
    [SerializeField] Sprite[] spritesPoder;

    [SerializeField] music ScriptMusic;
    [SerializeField] PlayerNaFaseBoss scriptPlayerNaFaseBoss;
    [SerializeField] AtaqueBoss[] scriptAtaqueBoss = new AtaqueBoss[3];
    [SerializeField] Slider sliderBoss, sliderPlayer;
    [SerializeField] AudioSource audioSource;

    float danoBom, danoPerfeito, danoBoss;

    float[] totalDeNotas = new float[3];
    short totalDeAcertos = 0;

    bool jogando = false;

    void Start()
    {
        Debug.DrawRay(transform.position, Vector2.left * 19, Color.green);
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        jogando = true;

        totalDeNotas[0] = ScriptMusic.tons1.Length;
        CalculosDeDanoNoBoss(totalDeNotas[0]);

    }

    void CalculosDeDanoNoBoss(float total)
    {
        danoPerfeito = 100 / total;
        danoBom = 60 / total;

        float porcentagem = 0.41f * total;
        danoBoss = 100 / porcentagem;

        Debug.Log($"Dano Perfeito {danoPerfeito}");
        Debug.Log($"Dano Bom {danoBom}");
        Debug.Log($"Dano Boss {danoBoss}");
    }
    int x = 0;
    void Update()
    {
        if (!audioSource.isPlaying && jogando)
        {
            jogando = false;


            if  (PlayerPrefs.GetInt("FaseAtual") == 1)
            {
                PlayerPrefs.SetInt("FaseAtual", 2);


                if (PlayerPrefs.GetInt("choosePhase") == 1)
                {
                    PlayerPrefs.SetInt("choosePhase", 2);
                }

                SceneManager.LoadScene(indexPhase);
            }
            else if (PlayerPrefs.GetInt("FaseAtual") == 2)
            {
                PlayerPrefs.SetInt("FaseAtual", 3);

                if (PlayerPrefs.GetInt("choosePhase") == 2)
                {
                    PlayerPrefs.SetInt("choosePhase", 3);
                }

                SceneManager.LoadScene(indexPhase);
            }
            else if (PlayerPrefs.GetInt("FaseAtual") == 3)
            {
                SceneManager.LoadScene(0);
            }
            
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f, layer);

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
        {
            x++;
            Debug.Log(x);

            if (hit.collider.gameObject.transform.position.x >= 3.3 && hit.collider.gameObject.transform.position.x <= 4.3)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("PERFEITO");

                totalDeAcertos++;
                sliderBoss.value -= danoPerfeito;

                scriptPlayerNaFaseBoss.Atacar();

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                img.sprite = spritesPoder[0];
            }
            else if (hit.collider.gameObject.transform.position.x >= 1.8 && hit.collider.gameObject.transform.position.x <= 5.8)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("OK");

                totalDeAcertos++;
                sliderBoss.value -= danoBom;

                scriptPlayerNaFaseBoss.Atacar();

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                img.sprite = spritesPoder[1];
            }
            else if ((hit.transform.position.x < 1.8 || hit.transform.position.x > 5.8))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("ERROU");

                sliderPlayer.value -= danoBoss;

                GameObject instancia = Instantiate(poderInimigo, new Vector2(2.2f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                scriptAtaqueBoss[0].Atacar();

                img.sprite = spritesPoder[2];
                
            }
        }
        try
        {
            if (hit.transform.position.x >= 7.67)
            {
                Destroy(hit.collider.gameObject);

                sliderPlayer.value -= danoBoss;

                GameObject instancia = Instantiate(poderInimigo, new Vector2(2.2f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                scriptAtaqueBoss[0].Atacar();

                img.sprite = spritesPoder[2];


            }
        }
        catch
        {

        }
    }
}

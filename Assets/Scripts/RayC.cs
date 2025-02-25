using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayC : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject poderMifany, poderInimigo;
    [SerializeField] Sprite[] spritesPoder;

    [SerializeField] music ScriptMusic;
    [SerializeField] PlayerNaFaseBoss scriptPlayerNaFaseBoss;
    [SerializeField] Slider sliderBoss, sliderPlayer;
    [SerializeField] AudioSource audioSource;

    float danoBom, danoPerfeito, danoBoss;

    float[] totalDeNotas = new float[3];
    short totalDeAcertos = 0;

    bool jogando = false;

    void Start()
    {
        Debug.DrawRay(transform.position, Vector2.left * 19, Color.green);
        Debug.Log(PlayerPrefs.GetInt("FaseAtual"));

        jogando = true;

        totalDeNotas[0] = ScriptMusic.tons1.Length;
        totalDeNotas[1] = ScriptMusic.tons2.Length;
        totalDeNotas[2] = ScriptMusic.tons3.Length;

        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            CalculosDeDanoNoBoss(totalDeNotas[0]);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            CalculosDeDanoNoBoss(totalDeNotas[1]);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            CalculosDeDanoNoBoss(totalDeNotas[2]);
        }
    }

    void CalculosDeDanoNoBoss(float total)
    {
        Debug.Log($"Total {total}");
        danoPerfeito = 100 / total;
        danoBom = 60 / total;

        float porcentagem = 0.41f * total;
        danoBoss = 100 / porcentagem;

        Debug.Log($"Dano Perfeito {danoPerfeito}");
        Debug.Log($"Dano Bom {danoBom}");
        Debug.Log($"Dano Boss {danoBoss}");
    }

    void Update()
    {
        if (!audioSource.isPlaying && jogando)
        {
            jogando = false;
            SceneManager.LoadScene(0);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f, layer);

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
        {
            if (hit.collider.gameObject.transform.position.x >= 3.3 && hit.collider.gameObject.transform.position.x <= 4.3)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("PERFEITO");

                totalDeAcertos++;
                sliderBoss.value -= danoPerfeito;

                scriptPlayerNaFaseBoss.Atacar();

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                if (PlayerPrefs.GetInt("FaseAtual") == 1)
                {
                    img.sprite = spritesPoder[0];
                }
                else if (PlayerPrefs.GetInt("FaseAtual") == 2)
                {
                    img.sprite = spritesPoder[1];
                }
                else if (PlayerPrefs.GetInt("FaseAtual") == 3)
                {
                    img.sprite = spritesPoder[2];
                }
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

                if (PlayerPrefs.GetInt("FaseAtual") == 1)
                {
                    img.sprite = spritesPoder[3];
                }
                else if (PlayerPrefs.GetInt("FaseAtual") == 2)
                {
                    img.sprite = spritesPoder[3];
                }
                else if (PlayerPrefs.GetInt("FaseAtual") == 3)
                {
                    img.sprite = spritesPoder[3];
                }
            }
            else if ((hit.transform.position.x < 1.8 || hit.transform.position.x > 5.8))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("ERROU");

                sliderPlayer.value -= danoBoss;

                GameObject instancia = Instantiate(poderInimigo, new Vector2(2.2f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                if (PlayerPrefs.GetInt("FaseAtual") == 1)
                {
                    img.sprite = spritesPoder[4];
                }
                else if (PlayerPrefs.GetInt("FaseAtual") == 2)
                {
                    img.sprite = spritesPoder[5];
                }
                else if (PlayerPrefs.GetInt("FaseAtual") == 3)
                {
                    img.sprite = spritesPoder[6];
                }
            }
            else if (hit.transform.position.x > 7.67)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

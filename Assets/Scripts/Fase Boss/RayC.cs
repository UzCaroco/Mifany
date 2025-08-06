using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayC : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject poderMifany, poderInimigo, Perfeito, Bom, Ruim, Errou;
    [SerializeField] Sprite[] spritesPoder;

    [SerializeField] music ScriptMusic;
    [SerializeField] PlayerNaFaseBoss scriptPlayerNaFaseBoss;
    [SerializeField] AtaqueBoss scriptAtaqueBoss;
    [SerializeField] Slider sliderBoss, sliderPlayer;
    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject ComboInstancia;
    [SerializeField] Canvas canvas;
    GameObject instanciaCombo;

    float danoBom, danoPerfeito, danoBoss, _70notas;

    float[] totalDeNotas = new float[3];
    short totalDeAcertos = 0;
    ushort combo = 0;

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
        danoBom = 70 / total;

        float porcentagem = 0.30f * total;
        danoBoss = 100 / porcentagem;

        _70notas = 0.7f * total;

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

            if (totalDeAcertos >= _70notas)
            {
                scriptAtaqueBoss.Morrer();
            }
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f, layer);

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
        {
            x++;
            Debug.Log(x);

            if (hit.collider.gameObject.transform.position.x >= 3.3 && hit.collider.gameObject.transform.position.x <= 4.3)
            {
                Vector2 posicao = new Vector2(hit.collider.gameObject.transform.position.x, 2.4f);
                Instantiate(Perfeito, posicao, Quaternion.identity);

                Destroy(hit.collider.gameObject);
                Debug.Log("PERFEITO");

                combo++;
                if (instanciaCombo != null)
                {
                    Destroy(instanciaCombo);
                }
                instanciaCombo = Instantiate(ComboInstancia, canvas.transform);
                RectTransform rectTransform = instanciaCombo.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(-869, 253f);
                TextMeshProUGUI textoCombo = instanciaCombo.GetComponent<TextMeshProUGUI>();
                textoCombo.text = $"<color=#FFFFFF>COMBO</color>\n<color=#FFE500>x{combo.ToString()}</color>"; 

                totalDeAcertos++;
                sliderBoss.value -= danoPerfeito;

                scriptPlayerNaFaseBoss.Atacar();

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                img.sprite = spritesPoder[0];

                
            }
            else if (hit.collider.gameObject.transform.position.x >= 1.8 && hit.collider.gameObject.transform.position.x <= 5.8)
            {
                Vector2 posicao = new Vector2(hit.collider.gameObject.transform.position.x, 2.4f);
                Instantiate(Bom, posicao, Quaternion.identity);

                Destroy(hit.collider.gameObject);

                Debug.Log("OK");

                combo = 0;
                totalDeAcertos++;
                sliderBoss.value -= danoBom;

                scriptPlayerNaFaseBoss.Atacar();

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                img.sprite = spritesPoder[1];
            }
            else if ((hit.transform.position.x < 1.8 || hit.transform.position.x > 5.8))
            {
                Vector2 posicao = new Vector2(hit.collider.gameObject.transform.position.x, 2.4f);
                Instantiate(Ruim, posicao, Quaternion.identity);

                Destroy(hit.collider.gameObject);

                Debug.Log("ERROU");

                combo = 0;
                sliderPlayer.value -= danoBoss;

                GameObject instancia = Instantiate(poderInimigo, new Vector2(2.2f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                scriptAtaqueBoss.Atacar();

                img.sprite = spritesPoder[2];
                
            }
        }
        try
        {
            if (hit.transform.position.x >= 7.67)
            {
                Vector2 posicao = new Vector2(hit.collider.gameObject.transform.position.x, 2.4f);
                Instantiate(Errou, posicao, Quaternion.identity);

                Destroy(hit.collider.gameObject);

                combo = 0;
                sliderPlayer.value -= danoBoss;

                GameObject instancia = Instantiate(poderInimigo, new Vector2(2.2f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                scriptAtaqueBoss.Atacar();

                img.sprite = spritesPoder[2];


            }
        }
        catch
        {

        }
    }
}

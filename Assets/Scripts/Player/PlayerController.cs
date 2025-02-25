using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    static PlayerController player;
    Vector2[] vt = new Vector2[3];
    int posicaoNaPista = 1;



    bool wPressionado => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    bool sPressionado => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

    private void Awake()
    {
        if (player == null)
        {
            player = this;
            DontDestroyOnLoad(gameObject);

            PlayerPrefs.SetInt("FaseAtual", 3);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        vt[0] = new Vector2(-6f, -3.15f);
        vt[1] = new Vector2(-6f, -2.3f);
        vt[2] = new Vector2(-6f, -1.2f);
    }

    void Update()
    {
        MudarDePosicao();
    }


    void MudarDePosicao()
    {
        if(posicaoNaPista >= 0 && posicaoNaPista < 2 && wPressionado)
        {
            posicaoNaPista++;
            transform.position = vt[posicaoNaPista];
        }
        else if (posicaoNaPista > 0 && posicaoNaPista <= 2 && sPressionado)
        {
            posicaoNaPista--;
            transform.position = vt[posicaoNaPista];
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(2);
        }
    }

}

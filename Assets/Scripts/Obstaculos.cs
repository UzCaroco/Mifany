using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstaculos : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rend;
    Vector2 vetor, vt;
    [SerializeField] Vector2[] posicao = new Vector2[3];

    [SerializeField] float velocidadeInicial = 5f, velocidadeMaxima = 10, velocidadeAtual, tempoFinal, aceleracao;
    [SerializeField] AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        vetor = new Vector2 (-1, 0).normalized;

        tempoFinal = audioSource.clip.length;
        aceleracao = (velocidadeMaxima - velocidadeInicial) / tempoFinal;
    }

    private void Update()
    {
        velocidadeAtual = velocidadeInicial + aceleracao * audioSource.time;

        if (transform.position.x < -11)
        {
            int sorteio = Random.Range(0, 3);

            transform.position = posicao[sorteio];
            rend.sortingOrder = sorteio;

        }
    }

    private void FixedUpdate()
    {
        vt = vetor * Time.deltaTime * velocidadeAtual + rb.position;
        rb.MovePosition(vt);



    }
}

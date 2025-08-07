using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    MeshRenderer rend;
    Vector2 vt;
    [SerializeField] float velocidadeInicial = 2f, velocidadeMaxima = 9f, velocidadeAtual, tempoFinal, aceleracao;
    [SerializeField] AudioSource audioSource;


    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        tempoFinal = audioSource.clip.length;
        aceleracao = (velocidadeMaxima - velocidadeInicial) / tempoFinal;
    }

    void Update()
    {
        velocidadeAtual = velocidadeInicial + aceleracao * audioSource.time;

        vt = new Vector2 (velocidadeAtual * Time.deltaTime, 0);
        rend.material.mainTextureOffset += vt;
    }
}

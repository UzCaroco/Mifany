using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class music : MonoBehaviour
{
    public float[] tons1 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };

    [SerializeField] Sprite[] spritesVermelhos = new Sprite[5];

    [SerializeField] float posicaoInicial, posicaoFinal;
    [SerializeField] float tempoDeViagem = 2f; // Tempo em segundos para chegar ao destino



    public GameObject prefabNota;

    public bool jogoPausado = false;


    // Start is called before the first frame update
    void Start()
    {
        TonsDaMusica();
    }


    void TonsDaMusica()
    {


        //CalcularEspacoEntreNotas(tons1);
        CarregarCorrotinas(tons1);


    }

    void CarregarCorrotinas(float[] notas)
    {
        foreach (float x in notas)
        {
            StartCoroutine(CarregarNotaMusical(x));
            Debug.Log("corrotina iniciada");
        }
    }
    IEnumerator CarregarNotaMusical(float tempo)
    {
        // Esperar até chegar o momento spawn, mas respeitando o pause

        float tempoRestante = tempo - tempoDeViagem;
        float tempoPassado = 0f;

        while (tempoPassado < tempoRestante)
        {
            if (!jogoPausado)
            {
                tempoPassado += Time.unscaledDeltaTime; //tempo real
            }
            yield return null; // Espera o próximo frame
        }

        // Calcula velocidade baseada no tempo fixo de viagem
        float distancia = posicaoFinal - posicaoInicial;
        float vel = distancia / tempoDeViagem;

        GameObject instancia = Instantiate(prefabNota, new Vector3(posicaoInicial, 3.5f, 0f), Quaternion.identity);

        int nota = Random.Range(0, 5);

        SpriteRenderer spriteRend = instancia.GetComponent<SpriteRenderer>();
        spriteRend.sprite = ResultadoSorteio(nota);
        NotaMusical scriptNota = instancia.GetComponent<NotaMusical>();
        scriptNota.velocidade = vel;
    }



    /*void CalcularEspacoEntreNotas(float[] tons)
    {
        Queue<float> fila = new Queue<float>();
        Queue<float> filaInstanciacao = new Queue<float>();

        float primeiro, segundo;

        fila.Enqueue(tons[0]);

        for (int i = 1; i < tons.Length - 1; i++)
        {
            fila.Enqueue(tons[i] - tempoDeViagem);
        }
        Debug.Log("quantidade na fila "+fila.Count);
        Debug.Log("quantidade na fila " +tons.Length);


        for (int i = 0; i < tons.Length - 2; ++i)
        {

            primeiro = fila.Peek(); 
            fila.Dequeue();
            segundo = fila.Peek();

            filaInstanciacao.Enqueue(segundo - primeiro);

        }
        
        StartCoroutine(CalcularVelocidadeDasNotas(filaInstanciacao));
    }



    

    IEnumerator CalcularVelocidadeDasNotas(Queue<float> intervalos)
    {
        while (intervalos.Count > 0)
        {
            // Espera o intervalo definido entre as notas
            yield return new WaitForSecondsRealtime(intervalos.Dequeue());

            // Calcula velocidade baseada no tempo fixo de viagem
            float distancia = posicaoFinal - posicaoInicial;
            float vel = distancia / tempoDeViagem;

            InstanciarNota(vel);

            
        }
    }



    void InstanciarNota(float vel)
    {
        GameObject instancia = Instantiate(prefabNota, new Vector3(posicaoInicial, 3.5f, 0f), Quaternion.identity);

        int nota = Random.Range(0, 5);

        SpriteRenderer spriteRend = instancia.GetComponent<SpriteRenderer>();
        spriteRend.sprite = ResultadoSorteio(nota);
        NotaMusical scriptNota = instancia.GetComponent<NotaMusical>();
        scriptNota.velocidade = vel;
    }*/

    Sprite ResultadoSorteio(int x)
    {
        return spritesVermelhos[x];
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class music : MonoBehaviour
{
    public float[] tons1 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };
    public float[] tons2 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };
    public float[] tons3 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };

    [SerializeField] Sprite[] spritesVermelhos = new Sprite[5];
    [SerializeField] Sprite[] spritesAmarelos = new Sprite[5];
    [SerializeField] Sprite[] spritesAzuis = new Sprite[5];

    [SerializeField] float posicaoInicial = -9.5f, posicaoFinal = 3.8f;
    [SerializeField] float tempoDeViagem = 2f; // Tempo em segundos para chegar ao destino

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clip;


    public GameObject prefabNota;
    
    private void Awake()
    {
        posicaoInicial = -9.5f;
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            tempoDeViagem = 1;
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            tempoDeViagem = 2f;
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            tempoDeViagem = 3f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TonsDaMusica();
    }


    void TonsDaMusica()
    {
        

        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            //CalcularEspacoEntreNotas(tons1);
            CarregarCorrotinas(tons1);
            audioSource.clip = clip[0];
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            //CalcularEspacoEntreNotas(tons2);
            CarregarCorrotinas(tons2);
            audioSource.clip = clip[1];
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            //CalcularEspacoEntreNotas(tons3);
            CarregarCorrotinas(tons3);
            audioSource.clip = clip[2];
            audioSource.Play();
        }


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
        yield return new WaitForSecondsRealtime(tempo - tempoDeViagem);

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
        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            return spritesAmarelos[x];
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            return spritesAzuis[x]; 
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            return spritesVermelhos[x];
        }

        return null;
    }

}

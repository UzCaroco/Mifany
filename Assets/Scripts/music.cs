using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    [SerializeField] float[] tons1 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };
    [SerializeField] float[] tons2 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };
    [SerializeField] float[] tons3 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };

    [SerializeField] Sprite[] spritesVermelhos = new Sprite[5];
    [SerializeField] Sprite[] spritesAmarelos = new Sprite[5];
    [SerializeField] Sprite[] spritesAzuis = new Sprite[5];

    [SerializeField] float posicaoInicial, posicaoFinal;

    public GameObject prefabNota;
    bool momentoPERFEITO, momentoOK;


    
    // Start is called before the first frame update
    void Start()
    {
        TonsDaMusica();
    }


    void TonsDaMusica()
    {
        

        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            CalcularEspacoEntreNotas(tons1);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            CalcularEspacoEntreNotas(tons2);
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            CalcularEspacoEntreNotas(tons3);
        }


    }

    




    void CalcularEspacoEntreNotas(float[] tons)
    {
        Debug.Log("Ativou");
        Queue<float> fila = new Queue<float>();

        for (int i = 0; i < tons.Length - 1; i++)
        {
            fila.Enqueue(tons[i + 1] - tons[i]); // Calcula o tempo de diferença entre os tons
        }
        
        StartCoroutine(CalcularVelocidadeDasNotas(fila));
    }



    [SerializeField] float tempoDeViagem = 2f; // Tempo em segundos para chegar ao destino

    IEnumerator CalcularVelocidadeDasNotas(Queue<float> intervalos)
    {
        while (intervalos.Count > 0)
        {
            // Calcula velocidade baseada no tempo fixo de viagem
            float distancia = posicaoFinal - posicaoInicial;
            float vel = distancia / tempoDeViagem;

            InstanciarNota(vel);

            // Espera o intervalo definido entre as notas
            yield return new WaitForSecondsRealtime(intervalos.Dequeue());
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
    }

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

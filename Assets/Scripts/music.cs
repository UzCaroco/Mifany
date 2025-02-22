using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    [SerializeField] float[] tons1 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };
    [SerializeField] float[] tons2 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };
    [SerializeField] float[] tons3 = new float[] { 0, 4, 8, 10, 12, 13, 14, 18 };

    public GameObject prefabNota;
    bool momentoPERFEITO, momentoOK;


    
    // Start is called before the first frame update
    void Start()
    {
        TonsDaMusica();
    }

    // Update is called once per frame
    void Update()
    {
        if (momentoPERFEITO && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Clique Perfeito");
        }
        else if (momentoOK && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Clique OK");
        }
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
            Debug.Log(fila.Peek());
        }
        Debug.Log("Ativou" + fila.Peek());
        
        StartCoroutine(CalcularVelocidadeDasNotas(fila));







    }

    IEnumerator CalcularVelocidadeDasNotas(Queue<float> intervalos)
    {
        Debug.Log("Ativou CERTAMENTE");

        

        for (int i = 0; i < intervalos.Count; i++)
        {
            i = 0;
            float vel = 11.8f / intervalos.Peek();
            Debug.Log("velocidade:");
            Debug.Log(vel);

            InstanciarNota(vel);
            //StartCoroutine(TempoDeCliqueOK(intervalos.Peek()));
            //StartCoroutine(TempoDeCliquePERFEITO(intervalos.Peek()));
            //StartCoroutine(BloquearClique(intervalos.Peek()));

            yield return new WaitForSeconds(intervalos.Peek());
            intervalos.Dequeue();
        }

        
    }



    void InstanciarNota(float vel)
    {


        GameObject instancia = Instantiate(prefabNota, new Vector3(-6f, 3.5f, 0f), Quaternion.identity);

        NotaMusical scriptNota = instancia.GetComponent<NotaMusical>();
        scriptNota.velocidade = vel;
    }






    /*IEnumerator TempoDeCliqueOK(float interval)
    {
        yield return new WaitForSeconds(interval * 95/100);
        momentoOK = true;
        Debug.Log("Clique Agora OK");
    }
    IEnumerator TempoDeCliquePERFEITO(float interval)
    {
        yield return new WaitForSeconds(interval * 99.5f/100);
        momentoPERFEITO = true;
        Debug.Log("Clique Agora PERFEITO");
    }
    IEnumerator BloquearClique(float interval)
    {
        yield return new WaitForSeconds(interval * 100.5f/100);
        momentoPERFEITO = false;
        momentoOK = false;
        Debug.Log("Não Pode Mais Clicar");
    }*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaMusical : MonoBehaviour
{

    public float velocidade;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            velocidade = 2;
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            velocidade = 2;
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            velocidade = 1.5f;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);

        /*if (transform.position.x > 3.8)
        {
            Destroy(gameObject);
            Debug.Log("boa");
        }*/

        /*if (transform.position.x >= 3.3 && transform.position.x <= 4.3 && clique)
        {
            Destroy(gameObject);
            Debug.Log("PERFEITO");
        }
        else if (transform.position.x >= 1.8 && transform.position.x <= 5.8 && clique)
        {
            Destroy(gameObject);
            Debug.Log("OK");
        }
        else if ((transform.position.x < 1.8 || transform.position.x > 5.8) && clique)
        {
            Destroy(gameObject);
            Debug.Log("ERROU");
        */
        if (transform.position.x > 7.67)
        {
            Destroy(gameObject);
        }
    }
}

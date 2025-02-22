using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaMusical : MonoBehaviour
{

    public float velocidade;

    bool clique => Input.GetKeyDown(KeyCode.Space);

    private void Start()
    {
        transform.position = new Vector2(-6, 3.5f);
    }

    void Update()
    {
        transform.position = new Vector3(velocidade * Time.fixedDeltaTime + transform.position.x, 0, 0);

        if (transform.position.x > 5.5 && transform.position.x <= 6 && clique)
        {
            Destroy(gameObject);
            Debug.Log("PERFEITO");
        }
        else if (transform.position.x > 5 && transform.position.x <= 5.5 && clique)
        {
            Destroy(gameObject);
            Debug.Log("OK");
        }
        else if (transform.position.x <= 5 && clique)
        {
            Destroy(gameObject);
            Debug.Log("ERROU");
        }
        else if (transform.position.x > 6)
        {
            Destroy(gameObject);
        }
    }
}

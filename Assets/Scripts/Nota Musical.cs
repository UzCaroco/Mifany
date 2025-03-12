using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotaMusical : MonoBehaviour
{

    public float velocidade;

    

    void Update()
    {
        if (transform.position.x > 7.67)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * velocidade * Time.fixedDeltaTime);
    }
}

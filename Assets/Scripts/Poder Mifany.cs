using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderMifany : MonoBehaviour
{
    public float velocidade = 30f;

    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}

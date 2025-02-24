using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderBoss : MonoBehaviour
{
    public float velocidade = 30f;

    void Update()
    {
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

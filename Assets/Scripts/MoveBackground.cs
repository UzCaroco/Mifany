using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    MeshRenderer rend;
    Vector2 vt;
    [SerializeField] float velocidade = 2;


    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        vt = new Vector2 (velocidade * Time.deltaTime, 0);
        rend.material.mainTextureOffset += vt;
    }
}

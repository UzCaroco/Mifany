using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNaFaseBoss : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Atacar()
    {
        ani.SetTrigger("IsAttack");
    }
}

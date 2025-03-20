using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBoss : MonoBehaviour
{
    Animator ani;
    [SerializeField] CutsceneSitonus CutsceneSitonus;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Atacar()
    {
        ani.SetTrigger("IsAttack");
    }

    public void Morrer()
    {
        ani.SetTrigger("IsDead");
    }

    public void AtivarCutscene()
    {
        CutsceneSitonus.AtivarCutscene();
        gameObject.SetActive(false);
    }
}

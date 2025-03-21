using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCamera : MonoBehaviour
{
    [SerializeField] byte indexPhase;
    [SerializeField] GameObject portal;
    [SerializeField] GameObject player;
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }


    public void AtivarCutscene()
    {
        ani.SetTrigger("Cutscene");
    }

    public void AtivarPortal()
    {
        portal.SetActive(true);
    }
}

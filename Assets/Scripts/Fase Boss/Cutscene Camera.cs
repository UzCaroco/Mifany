using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CutsceneCamera : MonoBehaviour
{
    
    [SerializeField] GameObject portal;
    [SerializeField] PlayerNaFaseBoss player;
    [SerializeField] CutsceneSitonus cutsceneSitonus;
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

    public void AtivarPlayerESitonus()
    {
        player.AtivarCutscenePlayer();
        cutsceneSitonus.MudarVelocidade();
    }
}

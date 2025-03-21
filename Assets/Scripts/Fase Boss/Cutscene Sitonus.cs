using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSitonus : MonoBehaviour
{
    [SerializeField] CutsceneCamera CutsceneCamera;
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    
    public void AtivarCutscene()
    {
        ani.SetTrigger("Cutscene");
        
    }

    public void CutscenePortal()
    {
        CutsceneCamera.AtivarCutscene();
    }

    public void MudarVelocidade()
    {
        ani.speed = 0.5f;
    }

    
}

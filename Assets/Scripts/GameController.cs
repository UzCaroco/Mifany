using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static GameController gameController;

    [SerializeField] GameObject[] obstaculos;
    [SerializeField] MeshRenderer[] quads = new MeshRenderer[3];
    [SerializeField] Material[] materials;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clip;

    bool tocandoMusica = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tocandoMusica = true;

        GameObject obj = GameObject.FindGameObjectWithTag("Solo");
        quads[0] = obj.GetComponent<MeshRenderer>();
        Debug.Log(obj.name);

        obj = GameObject.FindGameObjectWithTag("Paisagem");
        quads[1] = obj.GetComponent<MeshRenderer>();
        Debug.Log(obj.name);

        obj = GameObject.FindGameObjectWithTag("Ceu");
        quads[2] = obj.GetComponent<MeshRenderer>();
        Debug.Log(obj.name);

        MudarMateriais();
    }

    void MudarMateriais()
    {
        Debug.Log(quads[0].name);

        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            quads[0].material = materials[2];
            quads[1].material = materials[1];
            quads[2].material = materials[0];

            audioSource.clip = clip[0];
            audioSource.Play();

            for (int i = 0; i < 4; i++)
            {
                obstaculos[i].SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            quads[0].material = materials[5];
            quads[1].material = materials[4];
            quads[2].material = materials[3];

            audioSource.clip = clip[1];
            audioSource.Play();

            for (int i = 4; i < 8; i++)
            {
                obstaculos[i].SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            quads[0].material = materials[8];
            quads[1].material = materials[7];
            quads[2].material = materials[6];

            audioSource.clip = clip[2];
            audioSource.Play();

            for (int i = 8; i < 12; i++)
            {
                obstaculos[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying && tocandoMusica)
        {
            tocandoMusica = false;
            SceneManager.LoadScene(3);
        }
    }
}

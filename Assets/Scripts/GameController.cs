using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] byte indexPhase;

    [SerializeField] GameObject[] obstaculos;
    [SerializeField] Material[] materials;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clip;

    bool tocandoMusica = false;
    void Start()
    {
        Debug.Log("Fase: "+ PlayerPrefs.GetInt("FaseAtual"));

        audioSource = GetComponent<AudioSource>();
        tocandoMusica = true;

    }


    private void Update()
    {
        if (!audioSource.isPlaying && tocandoMusica)
        {
            tocandoMusica = false;
            SceneManager.LoadScene(indexPhase);
        }
    }
}

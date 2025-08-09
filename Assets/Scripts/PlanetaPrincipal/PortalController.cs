using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] MeshRenderer[] gameObjMaterialForChange;
    [SerializeField] Material CenarioCasasPretoBranco;
    [SerializeField] Material CenarioCasasColorido;
    [SerializeField] byte levelDoJogo;

    private void Start()
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (PlayerPrefs.GetInt("ConclusaoDaFase") >= 3)
        {
            for (int i = 0; i < gameObjMaterialForChange.Length; i++)
            {
                gameObjMaterialForChange[i].material = CenarioCasasColorido;
            }
        }
        else
        {
            for (int i = 0; i < gameObjMaterialForChange.Length; i++)
            {
                gameObjMaterialForChange[i].material = CenarioCasasPretoBranco;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Fase: " + PlayerPrefs.GetInt("FaseAtual"));

        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("ConclusaoDaFase") == 3)
                levelDoJogo = 2;

            else if (PlayerPrefs.GetInt("FaseAtual", 1) == 1)
                levelDoJogo = 3;

            else if (PlayerPrefs.GetInt("FaseAtual", 1) == 2)
                levelDoJogo = 5;

            else if (PlayerPrefs.GetInt("FaseAtual", 1) >= 3)
                levelDoJogo = 7;
        }

        CarregarCena(levelDoJogo);
    }
    
    public void CarregarCena(int indexScene)
    {
        StartCoroutine(CarregarCenaAsync(indexScene));
    }

    IEnumerator CarregarCenaAsync(int indexScene)
    {
        // Começa a carregar a cena
        AsyncOperation operacao = SceneManager.LoadSceneAsync(indexScene);

        // Evita que a cena troque automaticamente quando terminar
        operacao.allowSceneActivation = false;

        // Enquanto não carregar tudo
        while (!operacao.isDone)
        {
            // Progresso do carregamento (0 a 0.9 é carregamento, 0.9 a 1 é ativação)
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);
            Debug.Log("Progresso: " + (progresso * 100) + "%");

            // Exemplo: ativa quando terminar
            if (progresso >= 1f)
            {
                operacao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

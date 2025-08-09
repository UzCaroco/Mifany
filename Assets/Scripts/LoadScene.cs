using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int indexSceneFoLoad;
    bool inside;
    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))) && inside)
        {
           LoadSceneWhat(indexSceneFoLoad);
        }
        else if ((Input.GetMouseButtonDown(0)) && inside)
        {
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPos2D = new Vector2(touchWorldPos.x, touchWorldPos.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPos2D, Vector2.zero);
            
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                LoadSceneWhat(indexSceneFoLoad);
            }
        }
    }

    public void LoadSceneWhat(int indexSceneForLoad)
    {
        StartCoroutine(CarregarCenaAsync(indexSceneForLoad));
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }
}

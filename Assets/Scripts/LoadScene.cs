using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int indexSceneFoLoad;
    bool inside;
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) && inside)
        {
            SceneManager.LoadScene(indexSceneFoLoad);
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

using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(indexSceneForLoad);
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

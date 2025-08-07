using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer layerPlayer; 
    [SerializeField] byte reloadScene;

    Rigidbody2D rb;
    static PlayerController player;
    Vector2[] vt = new Vector2[3];
    int posicaoNaPista = 1;

    bool wPressionado => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    bool sPressionado => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

    Vector2 touchStart;
    Vector2 touchEnd;
    //float swipeThreshold = 30f;
    bool swipeDetectado = false;

   
    void Start()
    {
        layerPlayer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        vt[0] = new Vector2(-6f, -3.15f);
        vt[1] = new Vector2(-6f, -2.3f);
        vt[2] = new Vector2(-6f, -1.2f);
    }

    void Update()
    {
        MudarDePosicao();
    }


    void MudarDePosicao()
    {
        if (posicaoNaPista >= 0 && posicaoNaPista < 2 && wPressionado)
        {
            posicaoNaPista++;
            transform.position = vt[posicaoNaPista];
        }
        else if (posicaoNaPista > 0 && posicaoNaPista <= 2 && sPressionado)
        {
            posicaoNaPista--;
            transform.position = vt[posicaoNaPista];
        }

        DetectarSwipe();

        layerPlayer.sortingOrder = 2 - posicaoNaPista;
    }

    void DetectarSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                swipeDetectado = false;
            }

            else if (touch.phase == TouchPhase.Moved && !swipeDetectado)
            {
                Vector2 delta = touch.position - touchStart;

                if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
                {
                    if (delta.y > 10f)
                    {
                        MoverParaCima();
                        swipeDetectado = true;
                    }
                    else if (delta.y < -10f)
                    {
                        MoverParaBaixo();
                        swipeDetectado = true;
                    }
                }
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                swipeDetectado = false;
            }
        }
    }

    void ResetSwipeThreshold()
    {
        //swipeThreshold = 30f;
    }

    void MoverParaCima()
    {
        if (posicaoNaPista < 2)
        {
            posicaoNaPista++;
            transform.position = vt[posicaoNaPista];
            //layerPlayer.sortingOrder = 2 - posicaoNaPista;
        }
    }

    void MoverParaBaixo()
    {
        if (posicaoNaPista > 0)
        {
            posicaoNaPista--;
            transform.position = vt[posicaoNaPista];
            //layerPlayer.sortingOrder = 2 - posicaoNaPista;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(reloadScene);
        }
    }
}

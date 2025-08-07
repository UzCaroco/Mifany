using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float dirX = 0;
    bool isFacingRight = true;

    [SerializeField] float speed;
    [SerializeField] Camera cam;

    Rigidbody2D rb;
    Animator animPlayer;

    
    Vector2 touchStart;
    Vector2 touchCurrent;
    float swipeThreshold = 20f;
    bool movendoPorTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectarInputCombinado();

        cam.transform.position = new Vector3(transform.position.x, 0, -10);

        DirectionCheck();
    }

    void DetectarInputCombinado()
    {
        float tecladoX = Input.GetAxisRaw("Horizontal"); // teclado funciona mesmo no WebGL no PC

        if (!Mathf.Approximately(tecladoX, 0f))
        {
            dirX = tecladoX;
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x;

                if (Mathf.Abs(deltaX) > 5f)
                {
                    dirX = Mathf.Sign(deltaX); // -1 ou 1
                }
            }
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                dirX = 0;
            }
        }
        else
        {
            dirX = 0;
        }
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }
    void MoveHorizontal()
    {
        //dirX = Input.GetAxisRaw("Horizontal");

        if (dirX != 0f)
        {
            rb.velocity = new Vector2((dirX * speed) * Time.fixedDeltaTime, rb.velocity.y);
            animPlayer.SetBool("isWalking", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animPlayer.SetBool("isWalking", false);
        }
    }

    void DirectionCheck()
    {
        if (isFacingRight && dirX < 0)
        {
            Flip();
        }
        if (!isFacingRight && dirX > 0)
        {
            Flip();
        }
    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    
    
}

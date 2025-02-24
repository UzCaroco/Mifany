using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float dirX = 0;

    [SerializeField] float speed;
    [SerializeField] Camera cam;

    Rigidbody2D rb;
    Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, 0 , -10);
        
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }
    void MoveHorizontal()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX != 0)
        {
            rb.velocity = new Vector2((dirX * speed) * Time.fixedDeltaTime, rb.velocity.y);
            animPlayer.SetBool("isWalking",true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animPlayer.SetBool("isWalking", false);
        }
    }
}

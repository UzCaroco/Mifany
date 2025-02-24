using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayC : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject poderMifany, poderInimigo;
    [SerializeField] Sprite[] spritesPoder;

    void Start()
    {
        Debug.DrawRay(transform.position, Vector2.left * 19, Color.green);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f, layer);

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
        {
            if (hit.collider.gameObject.transform.position.x >= 3.3 && hit.collider.gameObject.transform.position.x <= 4.3)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("PERFEITO");

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                Debug.Log(img);

                if (PlayerPrefs.GetInt("FaseInicial") == 1)
                {
                    img.sprite = spritesPoder[0];
                }
                else if (PlayerPrefs.GetInt("FaseInicial") == 2)
                {
                    img.sprite = spritesPoder[1];
                }
                else if (PlayerPrefs.GetInt("FaseInicial") == 3)
                {
                    img.sprite = spritesPoder[2];
                }
            }
            else if (hit.collider.gameObject.transform.position.x >= 1.8 && hit.collider.gameObject.transform.position.x <= 5.8)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("OK");

                GameObject instancia = Instantiate(poderMifany, new Vector2(-3.77f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                Debug.Log(img);

                if (PlayerPrefs.GetInt("FaseInicial") == 1)
                {
                    img.sprite = spritesPoder[3];
                }
                else if (PlayerPrefs.GetInt("FaseInicial") == 2)
                {
                    img.sprite = spritesPoder[3];
                }
                else if (PlayerPrefs.GetInt("FaseInicial") == 3)
                {
                    img.sprite = spritesPoder[3];
                }
            }
            else if ((hit.transform.position.x < 1.8 || hit.transform.position.x > 5.8))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("ERROU");

                GameObject instancia = Instantiate(poderInimigo, new Vector2(2.2f, 0), Quaternion.identity);
                SpriteRenderer img = instancia.GetComponent<SpriteRenderer>();

                Debug.Log(img);

                if (PlayerPrefs.GetInt("FaseInicial") == 1)
                {
                    img.sprite = spritesPoder[3];
                }
                else if (PlayerPrefs.GetInt("FaseInicial") == 2)
                {
                    img.sprite = spritesPoder[3];
                }
                else if (PlayerPrefs.GetInt("FaseInicial") == 3)
                {
                    img.sprite = spritesPoder[3];
                }
            }
            else if (hit.transform.position.x > 7.67)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

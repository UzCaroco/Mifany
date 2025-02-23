using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayC : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    void Start()
    {
        Debug.DrawRay(transform.position, Vector2.left * 19, Color.green);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20f, layer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ok");
        }

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public void Destruir()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(0, -1 * Time.fixedDeltaTime) + transform.position;
    }
}

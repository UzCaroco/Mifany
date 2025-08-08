using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTutorial : MonoBehaviour
{
    [SerializeField] KeyCode key1, key2;
    void Update()
    {
        if(Input.GetKeyDown(key1) || Input.GetKeyDown(key2))
        {
            Debug.Log("Key 1 pressed");
            Destroy(gameObject);
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Touch detected");
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController gameController;

    [SerializeField] MeshRenderer[] quads = new MeshRenderer[3];
    [SerializeField] Material[] materials;
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Solo");
        quads[0] = obj.GetComponent<MeshRenderer>();
        Debug.Log(obj.name);

        obj = GameObject.FindGameObjectWithTag("Paisagem");
        quads[1] = obj.GetComponent<MeshRenderer>();
        Debug.Log(obj.name);

        obj = GameObject.FindGameObjectWithTag("Ceu");
        quads[2] = obj.GetComponent<MeshRenderer>();
        Debug.Log(obj.name);

        MudarMateriais();
    }

    void MudarMateriais()
    {
        Debug.Log(quads[0].name);
        if (PlayerPrefs.GetInt("FaseAtual") == 1)
        {
            quads[0].material = materials[2];
            quads[1].material = materials[1];
            quads[2].material = materials[0];
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 2)
        {
            quads[0].material = materials[5];
            quads[1].material = materials[4];
            quads[2].material = materials[3];
        }
        else if (PlayerPrefs.GetInt("FaseAtual") == 3)
        {
            quads[0].material = materials[8];
            quads[1].material = materials[7];
            quads[2].material = materials[6];
        }
    }
}

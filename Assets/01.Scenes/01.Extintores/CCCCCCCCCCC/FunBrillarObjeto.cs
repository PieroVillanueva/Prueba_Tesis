using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBrillarObjeto : MonoBehaviour
{
    public Material mat;
    public float variante=1.5f;
    private bool subida;
    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<SkinnedMeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("Vector1_BB848DB5", variante);
        if (subida)
        {
            variante += 0.006f;
            if (variante >= 2.0) subida = false;
        }
        else
        {
            variante -= 0.006f;
            if (variante <= 1.3) subida = true;
        }
    }
}

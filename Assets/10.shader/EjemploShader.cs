using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploShader : MonoBehaviour
{
    public MeshRenderer meshMat;
    public bool useEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useEffect == true)
        {
            //true
            meshMat.material.SetFloat("_EMISSION", 1);
        }
        else
        {
            //false
            meshMat.material.SetFloat("_EMISSION", 0);
        }
    }
  
}

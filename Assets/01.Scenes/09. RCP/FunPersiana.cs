using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPersiana : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform[] modelos;
    public bool automatic = false;
    void Start()
    {
        modelos = GetComponentsInChildren<Transform>();
        if (automatic == true) 
        {           
            cerrarPersiana();
        }
        
        //abrirPersiana();

    }
    public void cerrarPersiana()
    {
        for (int i = 1; i < modelos.Length; i++)
        {
            modelos[i].localEulerAngles += new Vector3(0, 0, -45);
        }
    }
    public void abrirPersiana()
    {
        for (int i = 1; i < modelos.Length; i++)
        {
            modelos[i].localEulerAngles += new Vector3(0, 0, 45);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

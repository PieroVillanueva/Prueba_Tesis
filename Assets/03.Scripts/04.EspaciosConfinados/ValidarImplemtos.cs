using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidarImplemtos : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] apps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImplementosCompletos()
    {
        for (int i = 0; i < apps.Length; i++)
        {
            if (!apps[i])
            {
                Debug.Log("Accidente");
                break;
            }
            if (i == apps.Length - 1)
            {
                Debug.Log("Todo Correcto");
            }
        }
    }

    public void VerificarImplemento(bool asignado, int indice)
    {
        apps[indice] = asignado;
    }

    public bool VerificarPosicion(int indice)
    {
        if (apps[indice])
        {
            return true;
        }
        return false;
    }
}

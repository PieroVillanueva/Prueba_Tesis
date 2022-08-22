using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunValidacionesArenado : MonoBehaviour
{
    public bool[] eppColocado;
    public bool todosEPPColocados;
    public bool limpiezaRealizada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool validarArreglo(bool[] arreglo)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (!arreglo[i])
            {
                return false;
            }
        }
        return true;
    }
    public void colocarEpp(int posEpp)
    {
        eppColocado[posEpp] = true;
        if (validarArreglo(eppColocado))
        {
            todosEPPColocados = true;
        }
    }

}

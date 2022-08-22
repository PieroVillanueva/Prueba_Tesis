using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunLlamadoPool : MonoBehaviour
{

    public GameObject[] objetos;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void mostrarEPP()
    {
        for (int i = 0; i < objetos.Length; i++)// Se le asigna los letreros a los epp
        {
            Debug.Log("Obj seteado");
            objetos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = false;
            PoolManagerFun.instanciaCompartida.ObtenerObjeto(objetos[i]);
        }
        Debug.Log("Asignados");
    }
    public void ocultarEPP()
    {
        for (int i = 0; i < objetos.Length; i++)// Se le cambia el no volver a asignar a los epp y que los letreros se separen
        {
            objetos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = true;
        }
        Debug.Log("DesAsignados");
    }

}

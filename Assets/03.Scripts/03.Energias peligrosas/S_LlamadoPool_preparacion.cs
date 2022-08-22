using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_LlamadoPool_preparacion : MonoBehaviour
{
    public GameObject[] objetivos;
    // Start is called before the first frame update
    public void activar()
    {
        /*for(int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = false;
            PoolManagerFun.instanciaCompartida.ObtenerObjeto(objetivos[i]);
        }*/
        if (objetivos.Length != 0)
        {
            foreach (GameObject obj in objetivos)
            {
                obj.GetComponent<ObjetoFuncion>().noVolverAsignar = false;
                PoolManagerFun.instanciaCompartida.ObtenerObjeto(obj);
            }
        }
    }

    // Update is called once per frame
    public void desactivar()
    {
        if (objetivos.Length != 0)
        {
            foreach (GameObject obj in objetivos)
            {
                obj.GetComponent<ObjetoFuncion>().noVolverAsignar = true;

            }
        }
        /*for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = true;
        }*/
    }
}

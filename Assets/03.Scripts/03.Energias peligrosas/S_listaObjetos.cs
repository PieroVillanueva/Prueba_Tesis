using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_listaObjetos : MonoBehaviour
{
    public List<GameObject> objetosLista;   

    public void agregarALista(GameObject objeto)
    {
        if (verificarLista(objeto) == true)
        {
            Debug.Log("nuevo objeto");
            objetosLista.Add(objeto);
            return;
        }
        Debug.Log("ya hay un objeto similar");
        return;
    }

    bool verificarLista(GameObject objeto)
    {
        for(int i = 0; i < objetosLista.Count; i++)
        {
            if (objeto == objetosLista[i])
            {
                return false;
            }
        }        
        return true;
    }
    

    public bool comprobarLista(int cantidadObjs)
    {
        if (objetosLista.Count == cantidadObjs) return true;
        return false;
    }    
}

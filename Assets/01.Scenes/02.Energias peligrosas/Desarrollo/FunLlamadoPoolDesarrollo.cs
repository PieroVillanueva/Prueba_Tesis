using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunLlamadoPoolDesarrollo : MonoBehaviour
{
    public GameObject[] objetos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void activar(int inicio, int fin)
    {
        for (int i = inicio; i < fin; i++)//Activa letreros para los objetos del arreglo objetos[]
        {
            objetos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = false;
            PoolManagerFun.instanciaCompartida.ObtenerObjeto(objetos[i]);            
        }
    }
    public void desactivar(int inicio, int fin)
    {
        for (int i = inicio; i < fin; i++)//Desactiva la asignación de objetos del arreglo objetos[]
        {
            objetos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = true;           //Habilitar no volver a asignar para que el letrero se separe del objeto dentro de su update
        }
    }
}

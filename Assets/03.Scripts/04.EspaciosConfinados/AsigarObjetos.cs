using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsigarObjetos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] listaObj;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Asignar()
    {
        for (int i = 0; i < listaObj.Length; i++)
        {
            if (i < 7)
            {
                ManagerLetrero.instanciaCompartida.ObtenerObjeto(listaObj[i]);
            }
            
        }
    }
    public void AsignarTableroApps()
    {
        for (int i = 0; i < listaObj.Length; i++)
        {
            if (i == 7)
            {
                ManagerLetrero.instanciaCompartida.ObtenerObjeto(listaObj[i]);
            }

        }
    }
    public void DesactivarLetreros()
    {
        for (int i = 0; i < listaObj.Length; i++)
        {
            if (listaObj[i].CompareTag("Tablero"))
            {
                listaObj[i].GetComponent<ObjetoLetrero>().Desactivar();
            }
        }
    }

    public void DesactivarLetrerosNoFirma()
    {
        for (int i = 0; i < listaObj.Length; i++)
        {
            if (i != 1)
            {
                listaObj[i].GetComponent<ObjetoLetrero>().Desactivar();
            }
        }
    }

    public void DesactivarApps()
    {
        for (int i = 0; i < listaObj.Length; i++)
        {
            if (listaObj[i].CompareTag("App"))
            {
                listaObj[i].GetComponent<ObjetoLetrero>().Desactivar();
            }
        }
    }
    public void AsignarTablero()
    {
        for (int i = 0; i < listaObj.Length; i++)
        {
            if (listaObj[i].CompareTag("Tablero"))
            {
                ManagerLetrero.instanciaCompartida.ObtenerObjeto(listaObj[i]);
            }
        }
    }
}

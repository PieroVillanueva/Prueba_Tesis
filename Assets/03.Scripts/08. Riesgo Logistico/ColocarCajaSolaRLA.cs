using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarCajaSolaRLA : MonoBehaviour
{
    public RLA_Manager manager;
    public bool enEspera;
    public bool soltar;
    public bool anclado;
    public Transform caja;
    public Transform nuevaPosicion;
    public MeshRenderer textura;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gancho"))
        {
            enEspera = true;
            caja = other.GetComponent<Transform>();
            manager.CumplirTarea(8);
            //StartCoroutine(ColocarCaja());

        }
    }
    /*public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gancho"))
        {
            enEspera = false;
            caja = null;
            anclado = false;
            textura.enabled = true;
        }
    }*/
    IEnumerator ColocarCaja()
    {
        if (!anclado)
        {
            while (enEspera && !soltar)
            {
                yield return new WaitForSeconds(0.01f);
            }
            if (enEspera && soltar)
            {
                caja.parent = gameObject.transform;
                caja.position = nuevaPosicion.position;
                textura.enabled = false;
                anclado = true;
                manager.CumplirTarea(8);
            }
        } 
    }
    public void AgarrarCaja()
    {
        soltar = false;
    }

    public void SoltarCaja()
    {
        if (enEspera)
        {
            soltar = true;
        }
    }
}

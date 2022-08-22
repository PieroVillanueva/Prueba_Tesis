using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunOcultarMano : MonoBehaviour
{
    public FunFuncionalidadesRCP funciones;
    public GameObject manoDerecha;
    public GameObject manoIzquierda;
    public GameObject der;
    public GameObject iz;
    //SkinnedMeshRenderer
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(aaa());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator aaa()
    {
        yield return new WaitForSecondsRealtime(1.00f);
        der = manoDerecha.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
        iz = manoIzquierda.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Right hand")
        {
            //funciones.ocultarManoDerecha(true);
            der.SetActive(false);
        }
        else if (other.name == "Left hand")
        {
            //funciones.ocultarManoIzquierdo(true);
            iz.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Right hand")
        {
            der.SetActive(true);
            //funciones.ocultarManoDerecha(false);
        }
        else if (other.name == "Left hand")
        {
            //funciones.ocultarManoIzquierdo(false);
            iz.SetActive(true);
        }
    }
}

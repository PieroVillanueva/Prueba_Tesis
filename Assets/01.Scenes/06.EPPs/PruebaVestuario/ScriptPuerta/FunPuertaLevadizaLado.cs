using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPuertaLevadizaLado : FunPuertaLevadiza
{
    public GameObject izquierdo;
    public GameObject derecha;
    public float distanciaLado = 1.0f;
    public bool abrirPrimera;
    public bool cerrarPrimera;
    void Start()
    {
    }

    void Update()
    {
       
    }
    public override void LlamarSubida()
    {
        if (!abrirPrimera) { 
            StartCoroutine(abrir());
            abrirPrimera = true;
        }
    }
    public override void LlamarBajada()
    {
        if (!cerrarPrimera)
        {
            StartCoroutine(cerrar());
            cerrarPrimera = true;
        }
    }

    IEnumerator abrir() // Abre las dos partes de las puertas hacia los lados
    {
        yield return new WaitForSecondsRealtime(3.00f);
        Vector3 posicionFinal = new Vector3(izquierdo.transform.localPosition.x, izquierdo.transform.localPosition.y, izquierdo.transform.localPosition.z - distanciaLado);
        Vector3 posicionFinal2 = new Vector3(derecha.transform.localPosition.x, derecha.transform.localPosition.y, derecha.transform.localPosition.z + distanciaLado);

        while (Vector3.Distance(izquierdo.transform.localPosition, posicionFinal) != 0)
        {
            yield return new WaitForFixedUpdate();
            izquierdo.transform.localPosition = Vector3.MoveTowards(izquierdo.transform.localPosition, posicionFinal, Time.deltaTime * velocidadPuerta);
            derecha.transform.localPosition = Vector3.MoveTowards(derecha.transform.localPosition, posicionFinal2, Time.deltaTime * velocidadPuerta);
            Debug.Log("abriendo");
        }
        Debug.Log("puertas abiertas");
    }
    IEnumerator cerrar()// Cierra las dos partes de las puertas hacia los lados
    {
        Vector3 posicionFinal = new Vector3(izquierdo.transform.localPosition.x , izquierdo.transform.localPosition.y, izquierdo.transform.localPosition.z + distanciaLado);
        Vector3 posicionFinal2 = new Vector3(derecha.transform.localPosition.x, derecha.transform.localPosition.y, derecha.transform.localPosition.z - distanciaLado);

        while (Vector3.Distance(izquierdo.transform.localPosition, posicionFinal) != 0)
        {
            yield return new WaitForFixedUpdate();            
            izquierdo.transform.localPosition = Vector3.MoveTowards(izquierdo.transform.localPosition, posicionFinal, Time.deltaTime * velocidadPuerta);
            derecha.transform.localPosition = Vector3.MoveTowards(derecha.transform.localPosition, posicionFinal2, Time.deltaTime * velocidadPuerta);
            Debug.Log("cerrando");
        }
        Debug.Log("puertas cerradas");
    }
}

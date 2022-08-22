using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentoSO : ObstaculoSO
{
    public EliminarDocumentos_SO eliminar;
    public Material defectuoso;
    private Material materialInicial;
    private Vector3 posicionInicial;
    private Vector3 rotacionInicial;
    private bool enMano = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tarjeta") && enUso)
        {
            StartCoroutine(EliminarObstaculo());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tarjeta") && enUso)
        {
            StopCoroutine(EliminarObstaculo());
        }
    }

    public void DocumentoEnMano(bool estado)
    {
        enMano = estado;
    }

    IEnumerator EliminarObstaculo()
    {
        while (enMano)
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        manager.obstaculosActual--;
        gameObject.SetActive(false);
        enUso = false;
        eliminar.ColocarDocumento();
        Debug.Log("Eliminado");
    }

    public override void ObtenerPosicionInicial()
    {
        //base.ObtenerPosicionInicial();
        ObtenerPosicion();
    }

    public override void ReiniciarObstaculo()
    {
        //base.ReiniciarPosicion();
        Reiniciar();
    }

    public override void InvocarObstaculo()
    {
        //base.InvocarObstaculo();
        CambiarADefectuoso();
    }

    public override void EstadoFresnel(int indice)
    {
        //base.ColocarFresnel();
        ActivarFresnel(indice);
    }

    private void CambiarADefectuoso()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material = defectuoso;
    }

    private void ObtenerPosicion()
    {
        posicionInicial = transform.localPosition;
        rotacionInicial = transform.localEulerAngles;
        materialInicial = transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    private void Reiniciar()
    {
        transform.localPosition = posicionInicial;
        transform.localEulerAngles = rotacionInicial;
        transform.GetChild(0).GetComponent<MeshRenderer>().material = materialInicial;
        gameObject.SetActive(true);
    }

    private void ActivarFresnel(int indice)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", indice);
    }
}

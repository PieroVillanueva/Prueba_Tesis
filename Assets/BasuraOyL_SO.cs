using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraOyL_SO : ObstaculoSO
{
    private Vector3 posicionInicial;
    private Vector3 rotacionInicial;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bloqueo"))
        {
            StartCoroutine(EliminarObstaculo());
        }
    }

    IEnumerator EliminarObstaculo()
    {
        yield return new WaitForSeconds(1f);
        manager.obstaculosActual--;
        gameObject.SetActive(false);
        enUso = false;
        Debug.Log("Eliminado");
    }

    public override void InvocarObstaculo()
    {
        //base.InvocarObstaculo();
        Invocar();
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

    public override void EstadoFresnel(int indice)
    {
        //base.ColocarFresnel();
        ActivarFresnel(indice);
    }

    private void Invocar()
    {
        gameObject.SetActive(true);
    }

    private void ObtenerPosicion()
    {
        posicionInicial = transform.localPosition;
        rotacionInicial = transform.localEulerAngles;
    }

    private void Reiniciar()
    {
        transform.localPosition = posicionInicial;
        transform.localEulerAngles = rotacionInicial;
        gameObject.SetActive(false);
    }

    private void ActivarFresnel(int indice)
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", indice);
    }
}

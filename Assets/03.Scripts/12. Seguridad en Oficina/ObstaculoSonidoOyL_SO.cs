using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSonidoOyL_SO : ObstaculoSO
{

    public AudioClip sonido;
    public AudioSource audio;
    public GameObject hoja;
    private Vector3 posicionInicial;
    private Vector3 rotacionInicial;
    public GameObject hojaImpresora;
    public GameObject panel;
    private bool mostrarObligado = false;
    
    private void ObstaculoSonido()
    {
        gameObject.GetComponent<ObstaculoSonidoOyL_SO>().audio.enabled = true;
        hoja.SetActive(true);
        audio.clip = sonido;
        audio.Play();
    }

    /*public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tablero"))
        {
            if (gameObject.GetComponent<ObstaculoSO>().enUso)
            {
                audio.Stop();
                manager.obstaculosActual--;
                gameObject.GetComponent<ObstaculoSO>().enUso = false;
                panel.SetActive(false);
            }
        }
    }*/

    public void ApagarImpresora()
    {
        if (enUso)
        {
            audio.Stop();
            manager.obstaculosActual--;
            gameObject.GetComponent<ObstaculoSO>().enUso = false;
            panel.SetActive(false);
        }
    }

    public void MostrarPanel(bool estado)
    {
        if (enUso && !mostrarObligado)
        {
            panel.SetActive(estado);
        }
    }

    public override void ColocarPanel(bool estado)
    {
        //base.ColocarPanel();
        panel.SetActive(estado);
        mostrarObligado = estado;
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
        ObstaculoSonido();
    }

    public override void EstadoFresnel(int indice)
    {
        //base.ColocarFresnel();
        ActivarFresnel(indice);
    }

    private void ObtenerPosicion()
    {
        posicionInicial = hojaImpresora.transform.localPosition;
        rotacionInicial = hojaImpresora.transform.localEulerAngles;
    }

    private void Reiniciar()
    {
        audio.enabled = false;
        hojaImpresora.transform.localPosition = posicionInicial;
        hojaImpresora.transform.localEulerAngles = rotacionInicial;
        hojaImpresora.SetActive(false);
    }

    private void ActivarFresnel(int indice)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", indice);
    }
}

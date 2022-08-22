using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersianaOyL_SO : ObstaculoSO
{
    public Transform[] modelos;
    public MeshRenderer mangoPersiana;
    public GameObject panel;

    public GameObject bloque_Luz;

    private bool mostrarObligado = false;
    // Start is called before the first frame update
    void Start()
    {
        modelos = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CerrarPersiana()
    {
        Vector3 rotacion;
        for (int i = 1; i < modelos.Length; i++)
        {
            rotacion = modelos[i].localEulerAngles;
            rotacion.z = -90;
            modelos[i].localEulerAngles = rotacion;
        }
        bloque_Luz.SetActive(true);
    }

    public void AbrirPersiana()
    {
        Vector3 rotacion;
        for (int i = 1; i < modelos.Length; i++)
        {
            rotacion = modelos[i].localEulerAngles;
            rotacion.z = -40;
            modelos[i].localEulerAngles = rotacion;
        }
        bloque_Luz.SetActive(false);
    }

    public void MostrarPanel(bool estado)
    {
        if (enUso && !mostrarObligado)
        {
            panel.SetActive(estado);
        }
    }

    public void Persiana()
    {
        if (enUso)
        {
            manager.obstaculosActual--;
            enUso = false;
            panel.SetActive(false);
        }
    }

    public override void ColocarPanel(bool estado)
    {
        //base.ColocarPanel();
        panel.SetActive(estado);
        mostrarObligado = estado;
    }

    public override void InvocarObstaculo()
    {
        //base.InvocarObstaculo();
        CerrarPersiana();
    }

    public override void ObtenerPosicionInicial()
    {
        base.ObtenerPosicionInicial();
    }

    public override void ReiniciarObstaculo()
    {
        //base.ReiniciarObstaculo();
        AbrirPersiana();
    }

    public override void EstadoFresnel(int indice)
    {
        //base.ColocarFresnel();
        ActivarFresnel(indice);
    }

    private void ActivarFresnel(int indice)
    {
        mangoPersiana.material.SetFloat("_EMISSION", indice);
    }

}

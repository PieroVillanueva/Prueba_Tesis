using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaArchivadorSO : Obstaculo_RC_SO
{
    public GameObject accidente;
    public SpawnerSO spawner;
    public Transform caja;
    public bool cerrado = true;
    public bool primera;
    public float max, min;
    private Vector3 auxiliar;
    public float distancia;
    public Vector3 auxiliarCaja;
    // Start is called before the first frame update
    void Start()
    {
        ObtenerPosicionInicial();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InvocarObstaculo()
    {
        //base.InvocarObstaculo();
        MoverCaja();
    }

    public override void ResetObstaculo()
    {
        //base.ResetObstaculo();
        ResetCajas();
    }
    public void ResetCajas()
    {
        caja.localPosition = auxiliarCaja;
    }

    public void ObtenerPosicionInicial()
    {
        auxiliarCaja = caja.localPosition;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sensor"))
        {
            if (!cerrado)
            {
                cerrado = true;
                //spawner.cajasAbiertas--;
                //caja.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", 0);
                //caja.GetChild(1).GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", 0);
                Debug.Log("caja cerrada");
            }
            
        }
    }

    public void PosicionCaja()
    {
        if ((caja.localPosition.z >= min || caja.localPosition.z <= max) && !cerrado)
        {
            cerrado = true;
            //spawner.cajasAbiertas--;
            //accidente.SetActive(false);
            Debug.Log("caja cerrada");
        }
    }

    public void MoverCaja()
    {
        auxiliar = caja.localPosition;
        auxiliar.z = distancia;
        caja.localPosition = auxiliar;
        //caja.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", 1);
        //caja.GetChild(1).GetComponent<MeshRenderer>().material.SetFloat("_EMISSION", 1);
        cerrado = false;
        //accidente.SetActive(true);
    }
}

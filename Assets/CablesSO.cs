using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablesSO : Obstaculo_RC_SO
{
    private GameObject cable;
    private GameObject canaletaSuperior;
    // Start is called before the first frame update
    void Start()
    {
        cable = transform.Find("CableOndulado").gameObject;
        canaletaSuperior = transform.Find("CanaletaSuperior").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InvocarObstaculo()
    {
        //base.InvocarObstaculo();
        AparecerCable();
    }

    public override void ResetObstaculo()
    {
        //base.ResetObstaculo();
        DesaparecerCable();
    }

    public void AparecerCable()
    {
        cable.SetActive(true);
        canaletaSuperior.SetActive(false);
        enUso = true;
    }

    public void DesaparecerCable()
    {
        cable.SetActive(false);
        canaletaSuperior.SetActive(true);
        enUso = false;
    }
}

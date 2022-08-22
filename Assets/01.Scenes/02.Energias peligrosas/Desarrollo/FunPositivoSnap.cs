using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPositivoSnap : MonoBehaviour
{
    public PanelFun panel;
    public FunMedidor textoDeMedicion;
    public int posicion;
    void Start()
    {
        panel = GameObject.Find("Panelito").GetComponent<PanelFun>();
        textoDeMedicion = GameObject.Find("Medicion").GetComponent<FunMedidor>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("PoloPositivo"))//En caso se acerque el medidor se activa el polo
        {
            panel.ActivarPolo(posicion);
        }
    }
    
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("PoloPositivo"))//En caso se saque el medidor, se cambia el texto medido
        {
            textoDeMedicion.CambiarTexto("0");
        }
    }
    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("PoloPositivo"))//En caso se mantenga el medidor se estará actualizando el valor medido dependiendo del voltaje obtenido del panel
        {
           textoDeMedicion.CambiarTexto(panel.voltaje.ToString());
        }
    }
}

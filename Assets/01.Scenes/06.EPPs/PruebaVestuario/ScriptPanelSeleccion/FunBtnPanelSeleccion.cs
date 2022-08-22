using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBtnPanelSeleccion : MonoBehaviour
{
    public FunPanelSeleccion panelSeleccion;
    public int numeroBoton;
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            panelSeleccion.SeleccionarBoton(numeroBoton);
        }
    }
}

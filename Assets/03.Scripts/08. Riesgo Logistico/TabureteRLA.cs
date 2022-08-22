using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabureteRLA : MonoBehaviour
{
    public GameObject copia;
    public Transform snap;
    public Transform nuevaPosicion;
    public RiesgoSobrecargarManualRLA[] riesgo;
    public void ApoyoColocado()
    {
        for (int i = 0; i < riesgo.Length; i++)
        {
            riesgo[i].colocado = true;
        }
        
    }

    public void ActivarCopia()
    {
        copia.SetActive(true);
        snap.position = nuevaPosicion.position;
        snap.GetComponent<MeshRenderer>().enabled = false;
    }

}

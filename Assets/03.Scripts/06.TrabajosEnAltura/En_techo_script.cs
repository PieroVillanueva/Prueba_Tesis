using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_techo_script : MonoBehaviour
{
    public GanchoPrueba gp;
    public GameObject seguro_indi;
    public GameObject seguro_indi2;

    private void OnTriggerEnter(Collider other)
    {
        if (gp.mta.actualTarea == 6) { 
            if(other.name=="VR Rig")
        {
            gp.en_techo = true;
            seguro_indi.SetActive(true);
            //yield return new WaitForSecondsRealtime(2f);
            gp.mta.CumplirTarea(6);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gp.mta.actualTarea >= 7)
        {
            if (other.name == "VR Rig")
            {
                seguro_indi2.SetActive(true);
            }
        }
    }
}

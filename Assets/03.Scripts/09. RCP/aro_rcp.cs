using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aro_rcp : MonoBehaviour
{
    public RCP_Manager rm;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name =="VR Rig")
        {
            rm.CumplirTarea(1);
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aro_desactivar_collider : MonoBehaviour
{
    private void Update()
    {
        if (G_Manager.gm.tarea >= 4)
        {
            this.gameObject.SetActive(false);
        }
        if (G_Manager.gm.go_operario == true)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="VR Rig")
        {
            this.gameObject.SetActive(false);
        }
    }

}

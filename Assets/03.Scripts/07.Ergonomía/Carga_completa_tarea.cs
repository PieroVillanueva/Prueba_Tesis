using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga_completa_tarea : MonoBehaviour
{
    public GameObject carga_mesh;

    public void OnTriggerEnter(Collider other)
    {
        if (GManagerErgo.ge.actualTarea == 21)
        {
            if (other.name == "mesa_carga")
            {
                GManagerErgo.ge.me.CumplirTarea(21);
                carga_mesh.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}

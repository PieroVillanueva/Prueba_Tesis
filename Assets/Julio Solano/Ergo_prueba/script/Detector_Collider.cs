using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Collider : MonoBehaviour
{
    public GameObject limitador;
    public string namecol;
    public bool contact = false;
    public int tarea_a_Completar;
    public int n_ejercicio_lim;
    void start(){
        GManagerErgo.ge.ya_lim = false;
        namecol = this.gameObject.name;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (contact != true)
        {
            if (other.CompareTag("Detect"))
            {
                Debug.Log("contacto hecho " + n_ejercicio_lim);
                contact = true;
                GManagerErgo.ge.limites(n_ejercicio_lim);
                GManagerErgo.ge.completar_tarea_panel(tarea_a_Completar);
                GManagerErgo.ge.ya_lim = true;
                switch (n_ejercicio_lim)
                {
                    case 1: GManagerErgo.ge.check_obj(0); break;
                    case 2: GManagerErgo.ge.check_obj(1); GManagerErgo.ge.col2_dis();GManagerErgo.ge.panelesParte1[1].SetActive(false); break;
                    //case 3: GManagerErgo.ge.check_obj(2); GManagerErgo.ge.panelesParte1[2].SetActive(false); break;
                    case 4: GManagerErgo.ge.check_obj(3);
                        GManagerErgo.ge.panelesParte1[3].SetActive(false);
                        GManagerErgo.ge.E1_T4_obj_in.SetActive(false);
                        GManagerErgo.ge.E1_T4_obj_mesh.SetActive(true);
                        this.gameObject.SetActive(false); ; break;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (contact != true) {
            if (other.CompareTag("Detect"))
            {
                GManagerErgo.ge.limites(n_ejercicio_lim);
                GManagerErgo.ge.completar_tarea_panel(tarea_a_Completar);
                contact = true;
                GManagerErgo.ge.ya_lim = true;
            }
        }
        
    }
}

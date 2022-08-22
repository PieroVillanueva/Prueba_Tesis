using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teclado_mouse_t3 : MonoBehaviour
{
    public int obj;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (GManagerErgo.ge.me.actualTarea == 4)
        {
            if (other.tag == "Detect")
            {
                GManagerErgo.ge.E1_T3_contador++;
                GManagerErgo.ge.E1_T3_obj_in[obj].SetActive(false);
                GManagerErgo.ge.E1_T3_obj_mesh[obj].SetActive(true);
                GManagerErgo.ge.E1_T3_verificador();
                this.gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wt_indi_desactivar : MonoBehaviour
{
    public GameObject wt_indi;
    private void OnTriggerStay(Collider other)
    {
        if (CompareTag("Player"))
        {
            wt_indi.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {if(G_Manager.gm.tarea >=12&& G_Manager.gm.tarea < 14)
        {
            if (CompareTag("Player"))
            {
                wt_indi.SetActive(false);
            }
        }
    }
}

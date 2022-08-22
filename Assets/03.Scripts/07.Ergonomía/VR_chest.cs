using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "carga_Cube")
        {
            GManagerErgo.ge.E5_cargar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "carga_Cube")
        {
            GManagerErgo.ge.E5_cargar = false;
        }
    }
}

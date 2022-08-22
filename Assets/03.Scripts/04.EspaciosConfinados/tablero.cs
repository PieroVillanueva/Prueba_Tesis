using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablero : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        
    }
    public void ToggleCasco_Changed(bool newValue)
    {
        if (newValue)
        {
            Debug.Log("Se activo el casco");
        }
        if(!newValue)
        {
            Debug.Log("Se desactivo el casco");
        }
        
    }

    public void ToggleChaleco_Changed(bool newValue)
    {
        if (newValue)
        {
            Debug.Log("Se activo el chaleco");
        }
        if(!newValue)
        {
            Debug.Log("Se desactivo el chaleco");
        }
    }
}

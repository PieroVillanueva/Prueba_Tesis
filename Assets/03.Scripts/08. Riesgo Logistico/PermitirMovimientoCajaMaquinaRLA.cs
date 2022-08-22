using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermitirMovimientoCajaMaquinaRLA : MonoBehaviour
{
    public bool enPosicion;
    public Transform hijo;
    public AnclajetTraspaletaRLA anclaje;
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
        if (other.CompareTag("PoloPositivo"))
        {
            enPosicion = true;
            hijo = other.transform.parent;
            anclaje.hijo = hijo;
            anclaje.cuerpos = hijo.GetComponent<Rigidbody>();

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PoloPositivo"))
        {
            enPosicion = false;
            hijo = null;
        }
    }
    
}

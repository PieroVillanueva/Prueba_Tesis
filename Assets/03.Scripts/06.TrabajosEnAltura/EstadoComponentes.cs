using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoComponentes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gancho;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivarComponentes()
    {
        gancho.GetComponent<SeguroArnes>().enabled = false;
        gancho.GetComponent<BoxCollider>().enabled = false;
    }

    public void ActivarComponentes()
    {
        gancho.GetComponent<SeguroArnes>().enabled = true;
        gancho.GetComponent<BoxCollider>().enabled = true;
    }
}

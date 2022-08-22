using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaFresnel : MonoBehaviour
{
    // Start is called before the first frame update

    public MeshRenderer gancho;
    public bool defectuoso;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            gancho = other.gameObject.GetComponent<MeshRenderer>();
            gancho.material.SetFloat("_EMISSION", 1);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            gancho.material.SetFloat("_EMISSION", 0);
        }
        
    }
}

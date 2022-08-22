using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoSubida : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rig;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mono"))
        {
            rig.transform.parent = gameObject.transform;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mono"))
        {
            rig.transform.parent = null;
        }
    }
}

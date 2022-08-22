using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiesgoSobrecargarManualRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public bool colocado;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (colocado)
            {
                Debug.Log("Terminar tarea");
            }
            else
            {
                Debug.Log("ACCIDENTE");
            }
        }
    }
}

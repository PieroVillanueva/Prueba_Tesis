using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunMentonColocado : MonoBehaviour
{
    // Start is called before the first frame update
    public Manager_RCP rcp;
    public bool primeraVez;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            if (!primeraVez)
            {
                Debug.Log("MENTON COLOCADO, ACTIVAR ANIMACION");
                rcp.CumplirTarea(4);
                primeraVez = true;
            }
        }
    }
}

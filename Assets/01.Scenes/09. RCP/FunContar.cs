using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunContar : MonoBehaviour
{
    public FunManosJuntas pecho;
    public bool primeraVez;
    public Manager_RCP rcp;
    public Animator animator;
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
        if (other.CompareTag("Detect"))
        {
            if (!primeraVez && pecho.contable)
            {
                animator.SetTrigger("compre");
                pecho.contador++;
                pecho.contable = false;

                if (pecho.contador == 30)
                {
                    rcp.CumplirTarea(rcp.actualTarea);
                    primeraVez = true;
                }
                
            }
            
        }

    }
}

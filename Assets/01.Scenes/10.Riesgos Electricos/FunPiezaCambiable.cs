using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPiezaCambiable : MonoBehaviour
{
    // Start is called before the first frame update 
    public Funcio2RiesgoElectrico funcio2;
    public Lvl_Manager manager;
    public int tareaACompletar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destornillador"))
        {
            manager.CumplirTarea(tareaACompletar);
            funcio2.enviarAlInfinito(gameObject);
        }
    }
}

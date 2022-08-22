using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPoloPanelPrincipal : MonoBehaviour
{
    public int numeroPolo;
    public bool primeraVez;
    public FuncionalidadesRiesgoESupervi funcionalidades;
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
        if (other.CompareTag("PoloPositivo"))
        {
            if (!primeraVez)
            {
                primeraVez = true;
                funcionalidades.medirUnPolo(numeroPolo);
            }
        }
    }
}

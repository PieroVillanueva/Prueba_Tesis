using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaSO : Obstaculo_RC_SO
{
    // Start is called before the first frame update
    private bool limpiando = false;
    private int pasada = 0;
    public List<ColliderDinamico> collidersList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InvocarObstaculo()
    {
        //base.InvocarObstaculo();
        AparecerAgua();
    }

    public override void ResetObstaculo()
    {
        //base.ResetObstaculo();
        DesaparecerAgua();
    }

    public void AparecerAgua()
    {
        gameObject.SetActive(true);
        enUso = true;
    }

    public void DesaparecerAgua()
    {
        gameObject.SetActive(false);
        enUso = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gas_ducto"))
        {
            limpiando = true;
            StartCoroutine(LimpiarAgua());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("gas_ducto"))
        {
            limpiando = false;
            ReiniciarColliders();
            pasada = 0;
        }
    }
 
    public bool VerificarColliders()
    {
        int contador = 0;
        foreach (ColliderDinamico aux in collidersList)
        {
            if (aux.primeraVez)
            {
                contador++;
            }
            if (contador == 2)
            {
                return true;
            }
        }
        return false;
    }

    public void ReiniciarColliders()
    {
        foreach (ColliderDinamico aux in collidersList)
        {
            aux.primeraVez = false;
        }
    }

    IEnumerator LimpiarAgua()
    {
        while (limpiando)
        {
            if (VerificarColliders())
            {
                pasada++;
                ReiniciarColliders();
                Debug.Log("Pasada: " + pasada);
            }
            if (pasada == 2)
            {
                Debug.Log("Se limpió el agua");
                DesaparecerAgua();
                ReiniciarColliders();
                limpiando = false;
                pasada = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

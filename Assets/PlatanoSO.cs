using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatanoSO : Obstaculo_RC_SO
{
    public SpawnerSO spawner;
    public bool esPlatano;
    // Start is called before the first frame update
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
        AparecerPlatano();
    }

    public override void ResetObstaculo()
    {
        //base.ResetObstaculo();
        DesaparecerPlatano();
    }

    public void AparecerPlatano()
    {
        gameObject.SetActive(true);
        AsignarPosicion();
        enUso = true;
    }

    public void DesaparecerPlatano()
    {
        gameObject.SetActive(false);
    }

    public void enManoEstado()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void AsignarPosicion()
    {
        int nPosicion = Random.Range(0, spawner.posicionesPlatano.Count);
        if (!spawner.ValidarPosicion(spawner.posicionesPlatano[nPosicion]))
        {
            spawner.AgregarPosicionesAuxiliar(spawner.posicionesPlatano[nPosicion]);
            transform.position = spawner.posicionesPlatano[nPosicion].position;
            transform.eulerAngles = spawner.posicionesPlatano[nPosicion].eulerAngles;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gancho") && esPlatano)
        {
            StartCoroutine(EliminarCascara());
        }
    }

    IEnumerator EliminarCascara()
    {
        yield return new WaitForSeconds(1f);
        DesaparecerPlatano();
        spawner.obstaculosActual--;
    }
}

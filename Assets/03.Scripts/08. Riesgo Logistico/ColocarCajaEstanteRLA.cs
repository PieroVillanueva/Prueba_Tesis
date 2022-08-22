using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarCajaEstanteRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public RLA_Manager manager;
    public ColocarLLavaCarroRLA llave;
    public bool enEspera;
    public AnclajetTraspaletaRLA anclaje;
    public Transform nuevaPosicion;
    public Transform caja;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TogglePlan"))
        {
            
            enEspera = true;
            caja = other.GetComponent<Transform>();
            StartCoroutine(ColocarCaja());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TogglePlan"))
        {
            enEspera = false;
            caja = null;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    IEnumerator ColocarCaja()
    {
        while (enEspera && anclaje.anclado)
        {
            yield return new WaitForSeconds(0.01f);
        }
        if (enEspera && !anclaje.anclado)
        {
            manager.CumplirTarea(17);
            llave.tareaCumplida = true;
            caja.position = nuevaPosicion.position;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

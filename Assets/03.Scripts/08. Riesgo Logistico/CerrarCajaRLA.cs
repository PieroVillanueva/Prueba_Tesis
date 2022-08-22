using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarCajaRLA : MonoBehaviour
{
    public Vector3 rotacion;
    public Vector3 rotacion1;
    public Transform[] tapas;
    public float velocidad;
    public float max;
    public bool completo;
    public GameObject codigoBarras;
    public GameObject nuevaCaja;
    public Transform antiguaCaja;
    public Transform nuevaPosicion;


    public RLA_Manager manager;
    void Start()
    {
        rotacion = tapas[0].localEulerAngles;
        rotacion1 = tapas[1].localEulerAngles;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("se da");
            if (completo)
            {
                StartCoroutine(MovimientoTapas());
            }
            
        }
    }

    IEnumerator MovimientoTapas()
    {
        while (rotacion.x <= max && rotacion1.x <= max)
        {        
            rotacion.x += velocidad * Time.deltaTime;
            tapas[0].localEulerAngles = rotacion;
            rotacion1.x += velocidad * Time.deltaTime; ;
            tapas[1].localEulerAngles = rotacion1;

            yield return new WaitForFixedUpdate();
        }
        //codigoBarras.SetActive(true);
        nuevaCaja.SetActive(true);
        antiguaCaja.position = nuevaPosicion.position;
        manager.CumplirTarea(31);
    }

}

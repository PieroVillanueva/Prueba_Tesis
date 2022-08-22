using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuertasRLA : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 rotacion;
    private Vector3 rotacion1;
    public Transform[] puertas;
    public float velocidad;
    public float max;
    public GameObject[] implementos;
    public RLA_Manager manager;
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
            if (TodosLosImplementos())
            {
                Debug.Log("Entro");
                StartCoroutine(MovimientoPuertas());
                manager.CumplirTarea(1);
            }
            
        }
    }
    IEnumerator MovimientoPuertas()
    {
        while (rotacion.y >= -max && rotacion1.y <= max)
        {
            rotacion.x = puertas[0].localEulerAngles.x;
            rotacion.z = puertas[0].localEulerAngles.z;
            rotacion.y -= velocidad * Time.deltaTime; ;
            puertas[0].localEulerAngles = rotacion;
            rotacion1.x = puertas[1].localEulerAngles.x;
            rotacion1.z = puertas[1].localEulerAngles.z;
            rotacion1.y += velocidad * Time.deltaTime; ;
            puertas[1].localEulerAngles = rotacion1;

            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }

    public bool TodosLosImplementos()
    {
        for (int i = 0; i < implementos.Length; i++)
        {
            if (implementos[i].activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}

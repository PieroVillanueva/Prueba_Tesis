using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioPoolVestuario : MonoBehaviour
{
  
    public GameObject[] objetos;

    void Start()
    {
        StartCoroutine(activar());
    }
    IEnumerator activar()
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].GetComponent<ObjetoFuncion>().noVolverAsignar = false;
            //PoolManagerFun.instanciaCompartida.ObtenerObjeto(objetos[i]);
        }
        Debug.Log("Asignados");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // PoolManagerFun.instanciaCompartida.ObtenerObjeto(objeto2);
            Debug.Log("MEEEEE");
        }
    }
}

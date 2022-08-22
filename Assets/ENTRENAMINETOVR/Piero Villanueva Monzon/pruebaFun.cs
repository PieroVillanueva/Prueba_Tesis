using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaFun : MonoBehaviour
{

    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public List<GameObject> objetos;

    void Start()
    {
        PoolManagerFun.instanciaCompartida.ObtenerObjeto(objeto1);
        PoolManagerFun.instanciaCompartida.ObtenerObjeto(objeto2);
        PoolManagerFun.instanciaCompartida.ObtenerObjeto(objeto3);
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

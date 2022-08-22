using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerFun : MonoBehaviour
{
    public GameObject objPrefabricado;

    public int poolSize;
    public Queue<GameObject> objPool;

    public static PoolManagerFun instanciaCompartida;

    private void Awake()
    {
        if (instanciaCompartida == null)
        {
            instanciaCompartida = this;
            objPool = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject nuevoObjeto = Instantiate(objPrefabricado);

                objPool.Enqueue(nuevoObjeto);
                nuevoObjeto.SetActive(false);
                Debug.Log("Se creo");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    public GameObject ObtenerObjeto(GameObject objetivo)
    {
        GameObject nuevoObjeto = objPool.Dequeue();
        nuevoObjeto.SetActive(true);
        nuevoObjeto.GetComponent<LetreroDePoolFun>().SetObjetoSeguido(objetivo);

        return nuevoObjeto;
    }
    public void AgregarObjetoACola(GameObject go)
    {
        go.SetActive(false);
        go.GetComponent<LetreroDePoolFun>().EliminarSeguimiento();
        objPool.Enqueue(go);
        
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLetrero : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objPrefabricado;
    public int poolSize;
    public Queue<GameObject> objPool;
    public static ManagerLetrero instanciaCompartida;
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
        nuevoObjeto.GetComponent<ManagerLetreroPool>().SetObjetoSeguido(objetivo);

        return nuevoObjeto;
    }
    public void AgregarObjetoACola(GameObject go)
    {
        Debug.Log("ANTES" + objPool.Count);
        go.SetActive(false);
        go.GetComponent<ManagerLetreroPool>().EliminarSeguimiento();
        objPool.Enqueue(go);
        Debug.Log("DESPUES" + objPool.Count);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

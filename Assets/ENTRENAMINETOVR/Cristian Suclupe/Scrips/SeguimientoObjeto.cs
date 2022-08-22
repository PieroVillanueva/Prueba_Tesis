using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objetoSeguir;
    public Vector3 offset;
    public Camera mainCamera;
    public float velocidad;
    public float distancia;
    public GameObject obj;
    public Queue<GameObject> Pool;
    public static SeguimientoObjeto instanciaCompartida;
    void Start()
    {
        mainCamera = Camera.main;
        if (instanciaCompartida == null)
        {
            instanciaCompartida = this;
            Pool = new Queue<GameObject>();
            for (int i = 0; i < objetoSeguir.Count; i++)
            {
                GameObject nuevoObjeto = Instantiate(obj);

                Pool.Enqueue(nuevoObjeto);
                nuevoObjeto.SetActive(false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objetoSeguir[0].transform.position + offset + new Vector3(0, Mathf.PingPong(Time.time * velocidad, distancia), 0);
        transform.LookAt(mainCamera.transform.position);
    }

    public void Visualizar()
    {
        gameObject.SetActive(true);
    }

    public void NoVisualizar()
    {
        gameObject.SetActive(false);
    }
}

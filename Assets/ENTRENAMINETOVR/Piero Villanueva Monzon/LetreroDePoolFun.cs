using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetreroDePoolFun : MonoBehaviour
{
    public GameObject ObjetoSeguido;
    public Vector3 offset;
    public Camera cameraMain;

    public float velocidad;
    public float distancia;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjetoSeguido != null) {
            transform.position = ObjetoSeguido.transform.position + offset + new Vector3(0, Mathf.PingPong(Time.time * velocidad, distancia), 0);
            transform.LookAt(cameraMain.transform.position);
            if (ObjetoSeguido.GetComponent<ObjetoFuncion>().agarrado||ObjetoSeguido.GetComponent<ObjetoFuncion>().noVolverAsignar)
            {
                PoolManagerFun.instanciaCompartida.AgregarObjetoACola(gameObject);
            }
        }
    }
    public virtual void SetObjetoSeguido(GameObject seguido)
    {
        ObjetoSeguido = seguido;
    }
    public virtual void EliminarSeguimiento()
    {
        ObjetoSeguido = null;
    }

}

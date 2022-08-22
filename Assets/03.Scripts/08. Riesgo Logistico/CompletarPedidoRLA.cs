using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletarPedidoRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public RLA_Manager manager;
    public int cantidad;
    public int maximo;
    public CodigoBarrasRLA codigo;
    public CerrarCajaRLA caja;
    public GameObject[] objetos;
    [Header("Caja para terminar pedido")]
    public GameObject nuevaCaja;

    [Header("Caja para colocar pedido")]
    public GameObject cajaPedido;

    public Transform nuevaPosicion;
    public GameObject snapZone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColocarCajaSnapZone()
    {
        snapZone.transform.position = nuevaPosicion.position;
        gameObject.transform.position = nuevaPosicion.position;
        cajaPedido.SetActive(true);
    }

    public void CantidadElementos()
    {
        if (cantidad < maximo)
        {
            cantidad++;
        }
        if (cantidad == maximo)
        {
            cajaPedido.transform.localPosition = nuevaPosicion.localPosition;
            nuevaCaja.SetActive(true);
            //codigo.colocar = true;
            caja.completo = true;
            //manager.CumplirTarea(31);
            //DesaparecerObjetos();
        }
    }

    public void DesaparecerObjetos()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

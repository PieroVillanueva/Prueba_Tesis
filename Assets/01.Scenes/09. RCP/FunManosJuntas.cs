using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunManosJuntas : MonoBehaviour
{
    public Transform manoDerecha;
    private Vector3 positionOffset;
    public bool agarradoDerecha;
    public bool agarradoIzquierda;

    public int contador;
    public bool contable;
    public Text cantPulsaciones;
    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position - manoDerecha.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agarradoIzquierda && agarradoDerecha)
        {
            transform.position = manoDerecha.position + positionOffset;
            cantPulsaciones.text = ""+contador;
        }


    }
    public void agarrarDerecha(bool agarrado)
    {
        agarradoDerecha = agarrado;
    }
    public void agarrarIzquierda(bool agarrado)
    {
        agarradoIzquierda = agarrado;
    }

}

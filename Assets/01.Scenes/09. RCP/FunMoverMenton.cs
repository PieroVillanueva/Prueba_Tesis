using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunMoverMenton : MonoBehaviour
{
    public Transform manoDerecha;
    private Vector3 positionOffset;
    public bool agarradoDerecha;
    public bool agarradoIzquierda;

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

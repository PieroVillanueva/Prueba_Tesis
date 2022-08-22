using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarLineaTA : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform nuevoPadre;
    Vector3 oPos;
    Vector3 oRot;
    public MeshRenderer fresnel;
    public CaidaTecho caida;
    public JugadorSeguimiento seguimiento;
    public GanchoPrueba deslizador;
    public Transform padreOriginal;
    public FuncionGanchoTecho fun;
    public EngancheArnes enganche;

    void Start()
    {
        oPos = transform.localPosition;
        oRot = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            nuevoPadre = other.transform;
            fun = nuevoPadre.GetComponent<FuncionGanchoTecho>();
            seguimiento = fun.seguimiento;
            fresnel.material.SetFloat("_EMISSION", 1);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Candado"))
        {  
            nuevoPadre = null;
            fresnel.material.SetFloat("_EMISSION", 0);
        }
    }

    public void Gancho()
    {
        if (nuevoPadre != null)
        {
            transform.parent = nuevoPadre;
            transform.localPosition = fun.pos;
            transform.localEulerAngles = fun.rot;
            caida.enganchado = true;
            enganche.enganchado = true;
            if (deslizador != null)
            {
                deslizador.engancheTecho = true;
            }
            if (seguimiento != null)
            {
                seguimiento.enganchado = true;
                Debug.Log("Se activó seguimiento");
            }
            return;
        }
        transform.parent = padreOriginal;
        transform.localPosition = oPos;
        transform.localEulerAngles = oRot;
        caida.enganchado = false;
        enganche.enganchado = false;
        fun = null;
        if (deslizador != null)
        {
            deslizador.engancheTecho = false;
        }
        if (seguimiento != null)
        {
            seguimiento.enganchado = false;
        }
    }

}

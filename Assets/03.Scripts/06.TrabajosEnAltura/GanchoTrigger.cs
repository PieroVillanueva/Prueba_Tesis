using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanchoTrigger : MonoBehaviour
{
    public GanchoPrueba gp;
    public ManagerTA mta;
    public Transform originalPadre;
    Vector3 oPos;
    Vector3 oRot;
    public Transform nuevoPadre;
    public Vector3 posicionGancho;
    public Vector3 rotacionGancho;
    public GameObject posicion;
    public CaidaTecho caida;
    public JugadorSeguimiento seguimiento;
    public GameObject inicio;
    public GanchoPrueba deslizador;
    public MeshRenderer fresnel;
    public EngancheArnes enganche;
    public FuncionGanchoTecho fun;


    //public ActivarLineaTA mosqueton;
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos la posicion inicial del objeto
        oPos = transform.localPosition;
        oRot = transform.localEulerAngles;
    }
    private void Update()
    {
        /*if (inicio != null)
        {
            oPos = inicio.transform.localPosition;
        }*/
    }
    // Update is called once per frame
    public void AccionSoltar()
    {
        if (nuevoPadre != null) //Si tiene un nuevo padre se va a emparentar al objeto con el nuevo padre
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
            if (enganche != null)
            {
                enganche.enganchado = true;
            }
            if (gp.en_techo == true) { mta.CumplirTarea(7); }
            
            return;
        }
        
        transform.parent = originalPadre;
        transform.localPosition = oPos;
        transform.localEulerAngles = oRot;
        caida.enganchado = false;
        
        if (deslizador != null)
        {
            deslizador.engancheTecho = false;
        }
        if (seguimiento != null)
        {
            seguimiento.enganchado = false;
            seguimiento.PosicionInicio();
        }
        if (enganche != null)
        {
            enganche.enganchado = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            nuevoPadre = other.transform;
            fun = nuevoPadre.GetComponent<FuncionGanchoTecho>();
            enganche = nuevoPadre.gameObject.GetComponent<EngancheArnes>();
            fresnel = gameObject.GetComponent<MeshRenderer>();
            fresnel.material.SetFloat("_EMISSION", 1);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            nuevoPadre = other.transform;
            fun = nuevoPadre.GetComponent<FuncionGanchoTecho>();
            enganche = nuevoPadre.gameObject.GetComponent<EngancheArnes>();
            fresnel = gameObject.GetComponent<MeshRenderer>();
            fresnel.material.SetFloat("_EMISSION", 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            nuevoPadre = null;
            fresnel.material.SetFloat("_EMISSION", 0);
        }
    }

    public void Seguir(bool seguir)
    {
        seguimiento.enganchado = seguir;
    }

    
}

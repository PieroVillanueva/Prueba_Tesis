using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunCargarOxicorte : MonoBehaviour
{
    [SerializeField] private string targetTag;
    public FunManagerOxicorte_Trabajo managerNivel;
    public int porcentaje;
    public bool seguirContando;
    public GameObject siguienteCorte;
    public int limitePorcentaje;

    [Header("Accidente No EPP")]
    public bool puedeGenerarAccidente;
    public bool provocoAccidente;
    public FunValidacionesTrabajosEnCaliente validaciones;

    [Header("Cambio Material Corte")]
    public GameObject parteIzquierda;
    public GameObject parteDerecha;

    public Material m_izquierdo;
    public Material m_derecho;
    public int valorInicial;

    public GameObject parteDesplegable;


    public UnityEvent terminarCorte = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        seguirContando = true;
        m_izquierdo = parteIzquierda.GetComponent<MeshRenderer>().material;
        m_derecho = parteDerecha.GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        float contarAuxiliar;
        if (other.CompareTag(targetTag))
        {
            if (seguirContando)
            {
                porcentaje += 1;
                contarAuxiliar = valorInicial + porcentaje / 4.0f;
                m_izquierdo.SetFloat("indicadorLleno", contarAuxiliar);
                m_derecho.SetFloat("indicadorLleno", contarAuxiliar);
                if (porcentaje == limitePorcentaje)//LLEGÓ A LÍMITE 
                {
                    seguirContando = false;//DEJA DE CONTAR
                    if (!puedeGenerarAccidente)//SI NO GENERA ACCIDENTE
                    {
                        siguienteCortee();
                    }
                    else
                    {
                        if (validaciones.todosEPPColocados)//SI TIENE TODOS LOS EPP
                        {
                            siguienteCortee();
                        }
                        else // NO TIENE EPP
                        {
                            provocoAccidente = true; //PROBOCA ACCIDENTE
                            Debug.Log("Accidentado por no EPP.");
                            managerNivel.accidentePorEpp();

                        }
                    }
                }
            }
        }
    }
    private void siguienteCortee()
    {       
        if (siguienteCorte != null)
        {
            siguienteCorte.SetActive(true);//ACTIVA SIGUIENTE CORTE
            gameObject.SetActive(false);
        }
        else
        {
            parteDesplegable.layer = 0;
            parteDesplegable.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Se terminó");
            terminarCorte?.Invoke();
            gameObject.SetActive(false);
        }
    }

}

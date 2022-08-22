using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunCargarArenero : MonoBehaviour
{
    [SerializeField] private string targetTag;

    public int porcentaje;
    public bool seguirContando;
    public GameObject siguienteCorte;
    public int limitePorcentaje;

    [Header("Accidente No EPP")]
    public bool puedeGenerarAccidente;
    public bool provocoAccidente;
    public FunValidacionesArenado validaciones;
    // Start is called before the first frame update
    void Start()
    {
        seguirContando = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (seguirContando)
            {
                porcentaje += 1;
                if (porcentaje == limitePorcentaje)
                {
                    if (!puedeGenerarAccidente)
                    {
                        seguirContando = false;
                        if (siguienteCorte != null)
                        {
                            siguienteCorte.SetActive(true);
                        }
                    }
                    else
                    {
                        if (validaciones.limpiezaRealizada)
                        {
                            if (validaciones.todosEPPColocados)
                            {
                                seguirContando = false;
                                Debug.Log("Accion Realizada");
                                if (siguienteCorte != null)
                                {
                                    siguienteCorte.SetActive(true);
                                }
                            }
                            /*
                            else
                            {
                                seguirContando = false;
                                provocoAccidente = true;
                                Debug.Log("Accidentado por no EPP.");
                            }*/
                        }
                        else
                        {
                            seguirContando = false;
                            provocoAccidente = true;
                            Debug.Log("Accidentado por no limpieza.");
                        }
                        
                    }
                }
            }
        }
    }
}

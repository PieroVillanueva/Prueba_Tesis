using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunBoca : MonoBehaviour
{
    public bool valido;
    public bool narizApretada;
    public float tiempoTranscurrido;

    public float tiempoOirRespirar;
    public bool validoOir;

    public Text texContRespirador;
    public Text texContOido;

    public bool imposibleOir;
    public bool imposibleDarAire;
    public int cantidadAiradas;

    public bool midiendoPulso;

    public Manager_RCP rcp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    IEnumerator contarRespiracion()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            tiempoTranscurrido += 0.05f;
            texContRespirador.text = ""+tiempoTranscurrido.ToString("0.0") + "″";
            if (!narizApretada)
            {
                valido = false;
            }

            if (!valido)
            {
                if (narizApretada)
                {
                    if (tiempoTranscurrido >= 1.00f&& tiempoTranscurrido <= 1.50f)
                    {
                        Debug.Log("RESPIRACION " + tiempoTranscurrido + " SEGUNDOS CORRECTA");
                        if (!imposibleDarAire)
                        {
                            cantidadAiradas++;
                            if (cantidadAiradas==2)
                            {
                                rcp.CumplirTarea(rcp.actualTarea);
                                imposibleDarAire = true;
                                cantidadAiradas = 0;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("RESPIRACION " + tiempoTranscurrido + " SEGUNDOS");
                    }
                }
                else
                {
                    Debug.Log("RESPIRACION "+tiempoTranscurrido +" SEGUNDOS FALTA NARIZ");
                }
                yield break;
            }
        }
    }
    IEnumerator contarOirRespiracion()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            tiempoOirRespirar += 0.05f;
            texContOido.text = "" + tiempoOirRespirar.ToString("0.0") + "″";
            if (!midiendoPulso)
            {
                validoOir = false;
            }
            if (!validoOir)
            {
                if (midiendoPulso)
                {
                    if (tiempoOirRespirar >= 5.00f && tiempoOirRespirar <= 10.00f)
                    {
                        Debug.Log("OIR RESPIRACION " + tiempoOirRespirar + " SEGUNDOS CORRECTA");
                        if (!imposibleOir)
                        {
                            rcp.CumplirTarea(rcp.actualTarea);
                            imposibleOir = true;
                        }
                    }
                    else
                    {
                        Debug.Log("OIR RESPIRACION " + tiempoOirRespirar + " SEGUNDOS TIEMPO INCORRECTO");
                    }
                }
                else
                {
                    Debug.Log("OIR RESPIRACION " + tiempoOirRespirar + " SEGUNDOS FALTA PULSO");
                }
               
                yield break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boquilla"))
        {
            valido = true;
            tiempoTranscurrido = 0;
            StartCoroutine(contarRespiracion());
            Debug.Log("ENTRO BOCA");
        }
        if (other.CompareTag("warning"))
        {
            validoOir = true;
            tiempoOirRespirar = 0;
            StartCoroutine(contarOirRespiracion());
            Debug.Log("ENTRO OIDO");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("boquilla"))
        {
            valido = false;
            Debug.Log("SALIO BOCA");
        }
        if (other.CompareTag("warning"))
        {
            validoOir = false;
            Debug.Log("SALIO OIDO");
        }
    }
    public void apretarNariz(bool apretar)
    {
        narizApretada = apretar;
    }
    public void medirPulso(bool midiendo)
    {
        midiendoPulso = midiendo;
    }

}

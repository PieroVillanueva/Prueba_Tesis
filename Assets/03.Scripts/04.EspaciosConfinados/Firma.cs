using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Firma : MonoBehaviour
{
    // Start is called before the first frame update
    public bool primera = false;
    public AudioSource audioManager;
    public AudioClip sonido;
    public bool activarFirma = false;
    public Manager_Planeamiento1 controlador;
    public Manager_Preparacion preparacion;
    public int escenario;
    public GameObject firma;
    public Text nombre;
    public Text fecha;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (escenario == 1)
        {
            if (activarFirma)
            {
                if (other.CompareTag("Lapicero"))
                {
                    if (!primera)
                    {
                        firma.SetActive(true);
                        nombre.text = "Cristian Suclupe Llontop";
                        fecha.text = DateTime.Now.ToString("dd-MM-yyyy");
                        audioManager.PlayOneShot(sonido);
                        primera = true;
                        controlador.CumplirTarea(1);
                       
                    }
                    

                }
            }
        }
        if (escenario == 2)
        {
            /*if (activarFirma)
            {
                if (other.CompareTag("Lapicero"))
                {
                    image.enabled = true;
                    audioManager.PlayOneShot(sonido);
                    primera = true;
                    controlador.CumplirTarea(1);

                }
            }*/
            if (other.CompareTag("Lapicero"))
            {
                if (!primera)
                {
                    firma.SetActive(true);
                    audioManager.PlayOneShot(sonido);
                    primera = true;
                    G_Manager.gm.ya_firma = true;
                    //controlador.CumplirTarea(1);
                }
            }
        }
    }

    public void ValidarTomaDeLosObjetos(bool activado)
    {
        activarFirma = activado;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletarListaApps : MonoBehaviour
{
    // Start is called before the first frame update
    public bool primera = false;
    public AudioSource audioManager;
    public bool activado = false;
    public Manager_Preparacion controlador;
    public AudioClip sonido;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lapicero"))
        {
            if (activado)
            {
                if (!primera)
                {
                    audioManager.PlayOneShot(sonido);
                    controlador.CumplirTarea(1);
                    primera = true;                    
                }
            }
        }
    }
    public void ActivarBoton(bool activar)
    {
        activado = activar;
    }
}

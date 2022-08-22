using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colision : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public GameObject obj;
    public GameObject obj2;
    public AudioClip sonido;
    public AudioClip colocar;
    public bool primera = false;
    public AudioSource audioManager;
    public bool activado = false;
    public Manager_Preparacion controlador;

    void Start()
    {
        toggle = GetComponent<Toggle>();
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
                    G_Manager.gm.apps++;
                    toggle.isOn = true;
                    audioManager.PlayOneShot(sonido);
                    if (toggle.isOn && toggle.CompareTag("Objeto"))
                    {
                        obj.SetActive(false);
                        obj2.SetActive(true);
                        //obj.GetComponent<ObjetoLetrero>().Desactivar();
                        audioManager.PlayOneShot(colocar);
                    }
                    if (toggle.isOn && toggle.CompareTag("TogglePlan"))
                    {
                        controlador.CumplirTarea(2);
                    }
                    primera = true;
                }
            }

        }
    }

    public void ActivarToggle(bool activar)
    {
        activado = activar;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaApps : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle checks;
    public AudioSource audioManager;
    public AudioClip sonido;
    public bool activado;
    void Start()
    {
        checks = GetComponent<Toggle>();
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
                checks.isOn = !checks.isOn;
                audioManager.PlayOneShot(sonido);
            }

        }
    }

    public void ActivarToggles(bool activar)
    {
        activado = activar;
    }
}

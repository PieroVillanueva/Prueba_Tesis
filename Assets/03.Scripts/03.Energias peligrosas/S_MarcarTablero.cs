using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_MarcarTablero : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    
    public AudioClip sonido;
    
    public bool primera = false;
    public AudioSource audioManager;
    public bool activado = false;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lapicero"))
        {
            if (activado)
            {
                if (!primera)
                {
                    toggle.isOn = true;
                    audioManager.PlayOneShot(sonido);                    
                    primera = true;
                }
            }
        }
    }

    // Update is called once per frame
    public void ActivarToggle(bool activar)
    {
        activado = activar;
    }
}

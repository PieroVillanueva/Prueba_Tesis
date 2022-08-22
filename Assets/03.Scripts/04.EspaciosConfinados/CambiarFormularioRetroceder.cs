﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarFormularioRetroceder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject avanzar;
    public AudioClip sonido;
    public AudioSource audioManager;
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
            avanzar.GetComponent<CambiarFormulario>().Retroceder();
            audioManager.PlayOneShot(sonido);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RegistrarSalida : MonoBehaviour
{
    // Start is called before the first frame update
    public DateTime fecha;
    public Text horaS;
    public bool primera;
    public AudioSource audioManager;
    public AudioClip sonido;
    public GameObject ho;
    void Update()
    {
        if (!primera)
        {
            fecha = DateTime.Now;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Lapicero"){
            if (!primera)
            {
                //fecha = DateTime.Now;
                horaS.text = fecha.ToString("hh:mm");
                audioManager.PlayOneShot(sonido);
                primera = true;
                ho.SetActive(true);
                G_Manager.gm.ya_salida = true;
            }
        }
        
    }
}

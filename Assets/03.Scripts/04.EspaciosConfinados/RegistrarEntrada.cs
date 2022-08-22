using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RegistrarEntrada : MonoBehaviour
{
    // Start is called before the first frame update
    public DateTime fecha;
    public Text nombre;
    public GameObject nom;
    public GameObject fe;
    public GameObject ho;
    public Text fecha1;
    public Text horaE;
    public AudioSource audioManager;
    public AudioClip sonido;
    public bool primera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lapicero")
        {
            if (!primera)
            {
                nom.SetActive(true);
                fe.SetActive(true);
                ho.SetActive(true);
                fecha = DateTime.Now;
                nombre.text = "Cristian Suclupe Llontop";
                fecha1.text = fecha.ToString("dd-MM-yyyy");
                horaE.text = fecha.ToString("hh:mm");
                audioManager.PlayOneShot(sonido);
                primera = true;
            }
        }
        

    }
}

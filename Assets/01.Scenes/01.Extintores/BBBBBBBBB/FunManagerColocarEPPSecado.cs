﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunManagerColocarEPPSecado : MonoBehaviour
{
    public int escenaSiguiente;
    public bool reproduciendoAudio;
    public bool espacioActivado;
    public GameObject letreroEscenario;

    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip[] audiosSecuencia;

    public AudioClip[] audiosEPPs;

    [Header("Validacion Epps")]
    public bool[] eppsColocados;
    public bool todosEPPColocados;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(inicio());
        espacioActivado = true; //PARA QUE NO PUEDAS colocarte ninguno
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reproduciendoAudio = reproductor.isPlaying;
    }
    private bool validarArreglo(bool[] arreglo)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (!arreglo[i])
            {
                return false;
            }
        }
        return true;
    }
    public void colocarseEpp(int pos) //Al colocarse EPP
    {
        if (!eppsColocados[pos])
        {
            eppsColocados[pos] = true;

            reproductor.clip = audiosEPPs[pos];
            reproductor.Play();

            if (validarArreglo(eppsColocados))
            {
                todosEPPColocados = true;

                StartCoroutine(final());
            }
        }
    }

    IEnumerator inicio()
    {
        yield return new WaitForSeconds(3.00f);
        reproductor.clip = audiosSecuencia[0];
        reproductor.Play();
        yield return new WaitForSeconds(10.40f);
        letreroEscenario.SetActive(true);
        reproductor.clip = audiosSecuencia[1];
        reproductor.Play();
        yield return new WaitForSeconds(15.0f);
        reproductor.clip = audiosSecuencia[2];
        reproductor.Play();
        yield return new WaitForSeconds(12.4f);
        espacioActivado = false; //ya se pueden colocar
    }

    IEnumerator final()
    {
        while (reproduciendoAudio)
        {
            yield return new WaitForSeconds(0.01f);
        }
        reproductor.clip = audiosSecuencia[3];
        reproductor.Play();
        //MANDAR A OTRA ESCENA
        //SceneManager.LoadScene(escenaSiguiente);
    }

    public void llamarActivarEspacioMomentaneo(GameObject espacio)
    {
        StartCoroutine("activarEspacioMomentaneo", espacio);
    }
    IEnumerator activarEspacioMomentaneo(GameObject espacio)
    {
        if (!reproduciendoAudio && !espacioActivado)
        {
            espacioActivado = true;
            yield return new WaitForSeconds(0.01f);
            espacio.SetActive(true);
            yield return new WaitForSeconds(2f);
            espacio.SetActive(false);
            espacioActivado = false;
        }
       
    }
}

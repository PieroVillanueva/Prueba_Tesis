﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class FunManagerEsmerilado_Correccin : MonoBehaviour
{
    public PlayableDirector director;
    public TimelineAsset correctos;
    public GameObject panelSiguienteEscenario;
    public GameObject reintentar;
    public AudioSource reproductor;
    public AudioClip[] locuciones;
    public AudioClip audioAccidente;
    [Header("Verificables")]
    public FunValidacionesEsmerilado valida;
    public GameObject pisoInflamable;
    void Start()
    {
        reproductor.PlayOneShot(locuciones[0]);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void siguienteEscenario()
    {
        SceneManager.LoadScene(8);
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(7);
    }
    public void empezarAccionar()
    {
        StartCoroutine(esperaAnimacion());
    }
    IEnumerator esperaAnimacion()
    {
        if (!pisoInflamable.activeInHierarchy && valida.todosEPPColocados)//todo bien
        {
            director.playableAsset = correctos;
        }
        director.Play();


        yield return new WaitForSeconds(4.80f);
        if (!pisoInflamable.activeInHierarchy && valida.todosEPPColocados)//todo bien
        {
            yield return new WaitForSeconds(5.00f);
            reproductor.PlayOneShot(locuciones[1]);
            yield return new WaitForSeconds(9.50f);
            panelSiguienteEscenario.SetActive(true);
        }
        else
        { //accidente
            reproductor.PlayOneShot(audioAccidente);
            yield return new WaitForSeconds(3.00f);

            reproductor.PlayOneShot(locuciones[2]);
            yield return new WaitForSeconds(12.00f);
            reintentar.SetActive(true);
        }
    }
}

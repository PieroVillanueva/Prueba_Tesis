using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunManagerIntroExtintores : MonoBehaviour
{
    [Header("Audios")]
    public AudioSource reproductorAudios;
    public AudioClip[] listaAudios;

    [Header("Imagenes y Videos")]
    public GameObject[] imagenes;
    public GameObject[] videos;

    [Header("Colliders Extintores")]
    public BoxCollider[] collidersExtintores;
    public GameObject[] letrerosExtintores;

    [Header("Validacion Extintores")]
    public bool[] extintoresTocados;
    public bool todosLosExtintoresTocados;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(inicial());
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void tocarExtintor(int pos)
    {
        extintoresTocados[pos] = true;
        if (validarArreglo(extintoresTocados))
        {
            todosLosExtintoresTocados = true;
            StartCoroutine(final());
        }
    }

    IEnumerator final()
    {
        yield return new WaitForSeconds(3.00f);
        reproducirAudio(7);
        yield return new WaitForSeconds(10.00f);
        //MANDAR A VOLAR
        Debug.Log("MANDALO AL LOBBY");
    }

    IEnumerator inicial()
    {
        yield return new WaitForSeconds(3.00f);
        reproducirAudio(0);
        yield return new WaitForSeconds(16.00f);

        //MOSTRAR IMAGEN DE CHICA CON EXTINTOR
        reproducirAudio(1);
        yield return new WaitForSeconds(3.50f);
        imagenes[0].SetActive(true);
        reproducirAudio(2);
        yield return new WaitForSeconds(19.20f);
        imagenes[0].SetActive(false);

        //MOSTRAR VIDEO DE QUE ES UN EXTINTOR
        reproducirAudio(3);
        yield return new WaitForSeconds(5.70f);
        videos[0].SetActive(true);
        yield return new WaitForSeconds(18.00f);
        videos[0].SetActive(false);

        //MOSTRAR VIDEO COMO USAR EXTINTOR
        reproducirAudio(4);
        yield return new WaitForSeconds(5.70f);
        videos[1].SetActive(true);
        yield return new WaitForSeconds(63.00f);
        videos[1].SetActive(false);

        //MOSTRAR VIDEO TIPOS DE FUEGO
        reproducirAudio(5);
        yield return new WaitForSeconds(12.50f);
        videos[2].SetActive(true);
        yield return new WaitForSeconds(8.50f);             //FALTA DEFINIR TIEMPO
        videos[2].SetActive(false);

        //MANDAR CON LOS EXTINTORES
        reproducirAudio(6);

        activarOpcionExtintor(0);
    }
    public void activarOpcionExtintor(int numero) => StartCoroutine(activarExtintor(numero));

    IEnumerator activarExtintor(int numero)
    {
        switch (numero)
        {
            case 0:
                yield return new WaitForSeconds(3.0f);
                break;
            case 1:
                yield return new WaitForSeconds(15.00f);
                break;
            case 2:
                yield return new WaitForSeconds(18.00f);
                break;
        }
        collidersExtintores[numero].enabled = true;
        letrerosExtintores[numero].SetActive(true);

    }


    public void reproducirAudio(int pos)
    {        
        reproductorAudios.clip = listaAudios[pos];
        reproductorAudios.Play();
    }
    public void reproducirVideo(int pos)
    {
        reproductorAudios.clip = listaAudios[pos];
        reproductorAudios.Play();
    }

}

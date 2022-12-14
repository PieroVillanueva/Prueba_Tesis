using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FunManagerIntroExtintores : MonoBehaviour
{
    public Movement usuario;
    public int siguienteEscenario;
    [Header("Indicadores")]
    public GameObject l_agarraExtitor;
    public GameObject l_agarraSiguiente1;
    public GameObject l_agarraSiguiente2;
    [Header("NPC")]
    public AgentNavMesh agente;
    public Transform destino;

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
        mover();
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
        yield return new WaitForSeconds(17.50f);
        videos[5].SetActive(false);
        reproducirAudio(7);
        yield return new WaitForSeconds(10.00f);
        //MANDAR A VOLAR
        Debug.Log("MANDALO AL LOBBY");
        usuario.llamarTransitionIn();
        yield return new WaitForSeconds(2.00f);
        SceneManager.LoadScene(siguienteEscenario);
        
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
        yield return new WaitForSeconds(15.30f);
        videos[0].SetActive(false);

        //MOSTRAR VIDEO COMO USAR EXTINTOR
        reproducirAudio(4);
        yield return new WaitForSeconds(5.70f);
        videos[1].SetActive(true);
        yield return new WaitForSeconds(59.50f);
        videos[1].SetActive(false);

        //MOSTRAR VIDEO TIPOS DE FUEGO
        reproducirAudio(5);
        yield return new WaitForSeconds(12.50f);
        videos[2].SetActive(true);
        yield return new WaitForSeconds(110.50f);           
        videos[2].SetActive(false);

        //MANDAR CON LOS EXTINTORES
        reproducirAudio(6);
        l_agarraExtitor.SetActive(true);
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
                yield return new WaitForSeconds(12.50f);
                videos[3].SetActive(false);
                l_agarraSiguiente1.SetActive(true);
                break;
            case 2:
                l_agarraSiguiente1.SetActive(false);
                yield return new WaitForSeconds(15.50f);
                videos[4].SetActive(false);
                l_agarraSiguiente2.SetActive(true);
                break;
        }
        collidersExtintores[numero].enabled = true;
        letrerosExtintores[numero].SetActive(true);

    }

    public void reproducirAudio(int pos)
    {        
        reproductorAudios.clip = listaAudios[pos];
        reproductorAudios.Play();
        agente.UseLipsync();
    }

    public void mover()
    {
        if (destino != null) { 
            agente.agent.destination=destino.position;
        }
    }

    public void reproducirVideo(int pos)
    {
        reproductorAudios.clip = listaAudios[pos];
        reproductorAudios.Play();
    }

}

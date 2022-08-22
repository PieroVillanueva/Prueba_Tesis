using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunFuncionesTra_Caliente : FunMultifunciones
{
    public bool mecheroEnciende;
    public GameObject flama;
    public GameObject gas;

    [Header("Basura")]
    public bool existeBasura;
    public int contador;

    [Header("FinalOxicorte")]
    public XRSocketInteractorTag espacioSoplete;
    public GameObject cerrarOxigeno;
    public GameObject cerrarPropano;

    [Header("Esmeril")]
    public SkinnedMeshRenderer derecha;
    public SkinnedMeshRenderer izquierda;
    public Material materialEsmeril;

    [Header("Parpadeo")]
    public Movement personaje;
    public GameObject personajeABotar;

    [Header("ParpadeoSegundaFirma")]
    public GameObject segunda;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void llamarBotarColado()
    {
        StartCoroutine(animacionParpadeo());
    }
    IEnumerator animacionParpadeo()
    {
        personaje.llamarTransitionIn();
        yield return new WaitForSeconds(1.00f);
        personajeABotar.SetActive(false);
        yield return new WaitForSeconds(1.00f);
        personaje.llamarTransitionOut();
    }

    public void llamarSegundaFirma()
    {
        StartCoroutine(animacionSegundaFirma());
    }
    IEnumerator animacionSegundaFirma()
    {
        personaje.llamarTransitionIn();
        yield return new WaitForSeconds(1.00f);
        segunda.SetActive(true);
        yield return new WaitForSeconds(1.00f);
        personaje.llamarTransitionOut();
    }



    public void mecheroPuedeEncender(bool puedeEncender)
    {
        mecheroEnciende = puedeEncender;
    }

    public void encenderFlama()
    {
        if (mecheroEnciende)
        {
            flama.SetActive(true);
            gas.SetActive(false);
        }
    }

    public void aumentarBasura()
    {
        contador++;
        if (contador != 0)
        {
            existeBasura = true;
        }
    }
    public void quitarBasura()
    {
        contador--;
        if (contador == 0)
        {
            existeBasura = false;
        }
    }
    public void tocarLLama()
    {
        Debug.Log("Te quemaste");

    }

    public void girarAguja(GameObject objeto) {
        objeto.transform.Rotate(0, 0, 70);
    }

    public void terminarOxicorte()
    {
        espacioSoplete.socketActive = true;
        cerrarOxigeno.SetActive(true);
        cerrarPropano.SetActive(true);
       
    }
    public void ocultarManoDerechaConManga(bool ocultar)
    {
        ManoDerecha.SetActive(!ocultar);
        parteBrazoDerecha.SetActive(!ocultar);
    }
    public void ocultarManoIzquierdaConManga(bool ocultar)
    {
        ManoIzquierda.SetActive(!ocultar);
        parteBrazoIzquierda.SetActive(!ocultar);
    }
    public void cambiarColorGuanteEsmeril()
    {
        derecha.material = materialEsmeril;
        izquierda.material = materialEsmeril;
    }

}

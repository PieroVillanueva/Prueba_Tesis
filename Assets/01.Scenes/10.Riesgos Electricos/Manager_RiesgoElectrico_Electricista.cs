using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_RiesgoElectrico_Electricista : Lvl_Manager
{
    public Movement movimientoPersonaje;
    public Vector3 nuevaPosPersonaje;
    public Vector3 nuevaPosPersonaje2;
    public AudioSource reproductor;
    public AudioClip clipSegundaMuerte;
    public GameObject[] espaciosEPP;
    public GameObject[] epps;
    public GameObject letrero6Checks;
    public Funcio2RiesgoElectrico funcio2;
    public GameObject coliderElectrico;
    public GameObject[] otrosColliderElectrico;
    public GameObject candadoBloqueo;
    public GameObject snapCandadoCajaMultiple;
    public GameObject espacioBloqueo;
    public GameObject piezaCambiable;
    [Header("Objetos Iluminables")]
    public GameObject switchPanel;
    public GameObject parteGiraPanel;
    public GameObject switchParaCambio;
    [Header("Animaciones")]
    public GameObject timeLapsoParo;
    public GameObject timeLapsoParoParte;
    public GameObject timeLapsoAccidente;
    public GameObject timeLapseElectrocutado;
    [Header("Activables")]
    public GameObject polos;
    public GameObject snapGancho;
    [Header("Audios Extras")]
    public AudioClip audioMuerteExtra;
    public override void Start()
    {
        base.Start();
        StartCoroutine(Tareas(actualTarea));
       
    }

    public override void CumplirTarea(int indexTarea)
    {
        base.CumplirTarea(indexTarea);
        StartCoroutine(Tareas(actualTarea));
    }


    /// <summary>
    /// Corrutina que activa los elemento a utilizar durante la tarea a realizar.
    /// </summary>
    /// <param name="tarea">Index de la tarea a realizar</param>
    /// <returns></returns>
    IEnumerator Tareas(int tarea)
    {
        switch (tarea)
        {
            case 0://Esperar cinematica
                /*
                yield return new WaitForSeconds(2f);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }*/
                // CumplirTarea(0);
                break;
            case 1:// Colocate EPP
                yield return new WaitForSeconds(0.1f);
                espaciosEPP[0].SetActive(true);
                espaciosEPP[1].SetActive(true);
                espaciosEPP[2].SetActive(true);
                //espaciosEPP[3].SetActive(true);//Guantes

                epps[0].SetActive(true);
                epps[1].SetActive(true);
                epps[2].SetActive(true);
                epps[3].SetActive(true);

                break;
            case 2:// Abrir motor 1 y bajar switch
                funcio2.resaltarObjeto(switchPanel);
                funcio2.posibleAbrirPrincipal = true;
                coliderElectrico.SetActive(false);
                otrosColliderElectrico[0].SetActive(false);
                otrosColliderElectrico[1].SetActive(false);
                yield return new WaitForSeconds(0.1f);
                espaciosEPP[0].SetActive(false);
                espaciosEPP[1].SetActive(false);
                espaciosEPP[2].SetActive(false);
                espaciosEPP[3].SetActive(false);
                //espaciosEPP[3].SetActive(true);//Guantes
                break;
            case 3:// Tocar 6 botones
                parteGiraPanel.transform.Rotate(45, 0, 0);
                funcio2.quitarResaltarObjeto(switchPanel);
                yield return new WaitForSeconds(0.1f);
                letrero6Checks.SetActive(true);

                break;

            case 4:// Colocar candado en caja bloqueo multiple
                yield return new WaitForSeconds(0.1f);
                funcio2.enviarAlInfinito(letrero6Checks);
                snapCandadoCajaMultiple.SetActive(true);

                break;
            case 5:// Realizar bloqueo panel motor
                yield return new WaitForSeconds(0.1f);
                candadoBloqueo.SetActive(true);
                espacioBloqueo.SetActive(true);

                break;
            case 6: //Medir tension
                yield return new WaitForSeconds(0.1f);
                polos.SetActive(true);
                break;
            case 7: //Gancho corto
                polos.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                snapGancho.SetActive(true);
                break;
            case 8:// Relizar cambio de pieza
                piezaCambiable.SetActive(true);
                funcio2.resaltarObjeto(switchParaCambio);
                break;
            case 9:// Ver Animaciones
                funcio2.quitarResaltarObjeto(switchParaCambio);

                yield return new WaitForSeconds(20.0f);
                movimientoPersonaje.llamarTransitionIn();
                yield return new WaitForSeconds(1);
                movimientoPersonaje.transform.position = nuevaPosPersonaje;
                movimientoPersonaje.llamarTransitionOut();
                timeLapsoParoParte.SetActive(true);
                yield return new WaitForSeconds(12.0f);


                movimientoPersonaje.llamarTransitionIn();
                yield return new WaitForSeconds(1);
                timeLapsoParo.SetActive(false);
                movimientoPersonaje.transform.position = nuevaPosPersonaje;
                movimientoPersonaje.llamarTransitionOut();
                timeLapsoAccidente.SetActive(true);
                yield return new WaitForSeconds(12.0f);

                movimientoPersonaje.llamarTransitionIn();
                yield return new WaitForSeconds(1);
                reproductor.PlayOneShot(audioMuerteExtra);
                timeLapsoAccidente.SetActive(false);
                movimientoPersonaje.transform.position = nuevaPosPersonaje2;
                movimientoPersonaje.transform.Rotate(0, 90, 0);
                movimientoPersonaje.llamarTransitionOut();
                timeLapseElectrocutado.SetActive(true);
                yield return new WaitForSeconds(7.0f);


                this.CumplirTarea(9);
                break;
            case 10:// FINALIZAR

                break;


        }
    }
}

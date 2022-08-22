using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class RLA_Manager : Lvl_Manager
{

    public AgentNavMesh agente;

    Movement player;

    [Header("Animaciones")]
    public TL_Secuencias secuencia;

    [Header("Movimientos del agente")]
    public Transform[] movimientos;

    [Header("Indicadores de posición para el usuario")]
    public GameObject[] aros;

    public PlayableDirector inocencioDirector;
    public bool IsUsed;

    [Header("Inicio")]
    public GameObject letreroInicio;

    [Header("Tarea leer aviso")]
    public GameObject botonAviso;
    public GameObject seguirSecuencia;

    [Header("Tarea accidente riesgo manual")]
    public GameObject inocencio;
    public GameObject snapCaja;

    [Header("Tarea Riesgo mecanico")]
    public GameObject snapCaja2;

    [Header("Tarea ordenar almacen")]
    public Transform nuevaPosicionMontacarga;
    public GameObject panelLimpieza;

    [Header("Tarea preguntas de Riesgo de atropellos")]
    public GameObject trabajador;
    public GameObject panelPreguntas;
    public GameObject montacargas;

    [Header("Tarea preguntas de Riesgo Derrumbes")]
    public GameObject panelPreguntasE;
    public GameObject panelRespuestas;
    public GameObject montacargas2;
    public Sprite spriteCorrecto;
    public Sprite spriteIncorrecto;
    public GameObject vallasSeguridad;
    public Toggle[] toggles;
    public RewindRLA rewind;
    public RespuestaRiesgoDerrumbeRLA respuestas;

    [Header("Tarea llenar pedido")]
    public GameObject snapZone;
    public GameObject cajaPlumones;
    public GameObject[] cajas;

    [Header("Tarea colocar código de barras")]
    public GameObject posicionCodigo;

    [Header("Tarea ir a la zona de capacitación")]
    public Transform puerta;
    public Transform nuevaPosicion;

    [Header("Tarea cuestionario capacitación")]
    public PreguntasBuenasPracticasRLA buenasPracticas;
    public GameObject panelPreguntasCapacitacion;
    public GameObject panelRespuestasCapacitacion;
    public GameObject panelResultados;
    public Toggle[] togglesCapacitacion;
    public BoxCollider boton1;
    public BoxCollider boton2;
    public int indice;

    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 

        //Corrutina que llama a las tareas a realizar, se ejecuta al inicio
        StartCoroutine(Tareas(actualTarea));
        player = GameObject.Find("VR Rig").GetComponent<Movement>();
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
        yield return new WaitForSeconds(2);
        switch (tarea)
        {
            case 0:
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                agente.MoveTo(movimientos[13]);
                yield return new WaitForSeconds(2.2f);
                letreroInicio.SetActive(true);
                break;
            case 1:
                aros[6].SetActive(true);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                
                break;
            case 2:
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                agente.MoveTo(movimientos[0]);
                aros[0].SetActive(true);
                break;
            case 3:
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                agente.MoveTo(movimientos[1]);
                aros[1].SetActive(true);
                break;
            case 4:
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(4f);
                botonAviso.SetActive(true);
                break;
            case 5:
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                seguirSecuencia.SetActive(true);
                break;
            case 6:
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 7:

                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[7].SetActive(true);
                break;
            case 8://Tarea accidente de caja riesgo manual
                agente.MoveTo(movimientos[2]);
                AccidenteCargaManual();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                snapCaja.SetActive(true);
                break;
            case 9: //Tarea colocar caja en estante manual
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                snapCaja.SetActive(false);
                aros[2].SetActive(true);
                break;
            case 10: //Tarea capacitacion traspaletado
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                agente.MoveTo(movimientos[3]);
                aros[3].SetActive(true);
                break;
            case 11: //Tarea inspeccion fisica de la carretilla elevadora
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //CumplirTarea(11);
                break;
            case 12: //Utilizar llave
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 13: //Tarea prueba de uso de la carretilla elevadora
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 14: //Tarea elevar y bajar plataforma de la carretilla elevadora
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 15: //Tarea avanzar hacia el lugar de carga
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(15);
                break;
            case 16://Ingresar horquillas
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;

            case 17://Tarea cuando ya se tiene la carga
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                snapCaja2.SetActive(true);
                aros[4].SetActive(true);
                break;
            case 18://Tarea colocar correctamente la carga
                agente.MoveTo(movimientos[4]);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 19://Tarea retir llave y pasar a la siguiente zona

                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[5].SetActive(true);
                break;
            case 20://Tarea aviso por falta de orden
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(2f);
                CumplirTarea(20);
                montacargas.transform.position = nuevaPosicionMontacarga.position;
                break;
            case 21://Tarea limpiar almacen
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelLimpieza.SetActive(true);
                break;
            case 22://Tarea continuar a siguiente zona
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[8].SetActive(true);
                agente.MoveTo(movimientos[5]);
                break;
            case 23://Tarea identificar riesgos
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelPreguntas.SetActive(true);
                break;
            case 24://Tarea tomar acciones correctivas y seguir recorrido
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelPreguntas.SetActive(false);
                aros[9].SetActive(true);
                agente.MoveTo(movimientos[6]);
                break;
            case 25://Tarea observar el accidente de los estantes
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                AccidenteEstantes();
                break;
            case 26://Tarea identificar acciones preventivas para el accidente de los estantes (Por implementar)
                agente.MoveTo(movimientos[7]);
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelPreguntasE.SetActive(true);
                break;
            case 27://Se terminó la tarea de riesgo de derrumbes
                mostrarRespuestaRiesgoDerrumbe();
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                rewind.ActivarRewind();
                panelPreguntasE.SetActive(false);
                panelRespuestas.SetActive(false);
                yield return new WaitForSeconds(2f);
                CumplirTarea(27);
                break;
            case 28://Tarea ir a la zona para preparar el pedido
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[10].SetActive(true);
                agente.MoveTo(movimientos[8]);
                break;
            case 29://Tarea dirigirse al pasillo 5
                for (int i = 0; i < cajas.Length; i++)
                {
                    cajas[i].SetActive(false);
                }
                cajaPlumones.SetActive(true);
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[11].SetActive(true);
                agente.MoveTo(movimientos[9]);
                break;
            case 30://Tarea buscar anaquel A1
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[12].SetActive(true);
                agente.MoveTo(movimientos[10]);
                break;
            case 31://Tarea seleccionar cajas
                agente.UseLipsync();
                snapZone.SetActive(true);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 32://Tarea llevar el pedido a la mesa para completar ejercicio
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[13].SetActive(true);
                agente.MoveTo(movimientos[11]);
                break;
            case 33://Tarea colocar codigo de barras
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                posicionCodigo.SetActive(true);
                break;
            case 34://Tarea tomar scaner de codigo de barras
                puerta.position = nuevaPosicion.position;
                puerta.eulerAngles = nuevaPosicion.eulerAngles;
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 35://Tarea dirigirse a zona de capacitacion
                agente.UseLipsync();
                puerta.position = nuevaPosicion.position;
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[14].SetActive(true);
                agente.MoveTo(movimientos[12]);
                break;
            case 36://ComenzarPreguntas
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelPreguntasCapacitacion.SetActive(true);
                //video.IniciarTransicion();          
                CumplirTarea(36);
                break;
            case 37:// pregunta 1: Una buena practica de almacenamiento es
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelRespuestasCapacitacion.SetActive(true);
                break;
            case 38://Respuesta a la primera pregunta
                //boton1.enabled = false;
                //boton2.enabled = false;
                indice++;
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = false;
                //video.CerrarTransicion();
                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = false;
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                buenasPracticas.PasarPregunta(1);
                yield return new WaitForSeconds(1.5f);
                CumplirTarea(38);
                break;
            case 39://Pregunta 2: Es necesario utilizar los equipo como: 
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = true;
                //video.IniciarTransicion();
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = true;
                boton1.enabled = true;
                boton2.enabled = true;
                break;
            case 40://Respuesta pregunta 2
                //boton1.enabled = false;
                //boton2.enabled = false;
                indice++;
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = false;
                //video.CerrarTransicion();
                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = false;
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                buenasPracticas.PasarPregunta(2);
                yield return new WaitForSeconds(1.5f);
                CumplirTarea(40);
                break;
            case 41://Pregunta 3: primera señal que simboliza
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = true;
                //video.IniciarTransicion();
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }

                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = true;
                boton1.enabled = true;
                boton2.enabled = true;
                break;
            case 42://Respuesta a la pregunta 3
                //boton1.enabled = false;
                //boton2.enabled = false;
                indice++;
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = false;
                //video.CerrarTransicion();
                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = false;
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                buenasPracticas.PasarPregunta(3);
                yield return new WaitForSeconds(1.5f);
                CumplirTarea(42);
                break;
            case 43://Pregunta 4: Siguiente señal
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = true;
                //video.IniciarTransicion();
                agente.UseLipsync();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }

                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = true;
                boton1.enabled = true;
                boton2.enabled = true;
                break;
            case 44://Respuesta pregunta 4 y muestra resultados
                //boton1.enabled = false;
                //boton2.enabled = false;
                indice++;
                panelPreguntasCapacitacion.GetComponent<Canvas>().enabled = false;
                //video.CerrarTransicion();
                panelRespuestasCapacitacion.GetComponent<Canvas>().enabled = false;
                agente.UseLipsync();
                mostrarRespuestasCapacitacion();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelResultados.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                CumplirTarea(44);
                break;
            case 45://Fin del curso
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;


        }
    }

    public void CompletarTareaTableroPedido()
    {
        CumplirTarea(28);
    }

    public void AccidenteAtropello()
    {
        StartCoroutine(TransicionAccidenteAtropello());
    }

    public void AccidenteEstantes()
    {
        StartCoroutine(TransicionAccidenteEstantes());
    }

    public void AccidenteCargaManual()
    {
        if (IsUsed == false)
        {
            StartCoroutine(TransicionAccidenteCargaManual());
        }
    }
    IEnumerator TransicionAccidenteAtropello()
    {
        player.speed = 0f;
        yield return new WaitForSecondsRealtime(1.1f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.1f);
        trabajador.SetActive(true);
        montacargas.SetActive(true);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        secuencia.reproducirCinematica(0);
        yield return new WaitForSeconds(24f);
        player.speed = 1.5f;
        CumplirTarea(22);
    }

    IEnumerator TransicionAccidenteEstantes()
    {
        player.speed = 0f;
        yield return new WaitForSecondsRealtime(1.1f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.1f);
        montacargas.SetActive(false);
        trabajador.SetActive(false);
        montacargas2.SetActive(true);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        secuencia.reproducirCinematica(1);
        yield return new WaitForSeconds(5f);
        player.speed = 1.5f;
        CumplirTarea(25);
    }

    IEnumerator TransicionAccidenteCargaManual()
    {
        IsUsed = true;
        player.speed = 0f;
        yield return new WaitForSecondsRealtime(1.1f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(0.8f);
        inocencio.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        player.StartCoroutine("TransitionLvlOut");
        inocencioDirector.Play();
        //yield return new WaitForSeconds(1f);
        
        yield return new WaitForSeconds(14f);
        yield return new WaitForSecondsRealtime(1.1f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.1f);
        inocencio.SetActive(false);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        player.speed = 1.5f;
    }

    public void mostrarRespuestaRiesgoDerrumbe()
    {
        for (int i = 0; i < respuestas.preguntas.Length; i++)
        {
            toggles[i].isOn = true;
            if (respuestas.preguntas[i].rptaCorrecta)
            {
                toggles[i].graphic.GetComponent<Image>().sprite = spriteCorrecto;
            }
            else
            {
                toggles[i].graphic.GetComponent<Image>().sprite = spriteIncorrecto;
            }
        }
        panelRespuestas.SetActive(true);
    }

    public void mostrarRespuestasCapacitacion()
    {
        for (int i = 0; i < buenasPracticas.preguntas.Length; i++)
        {
            togglesCapacitacion[i].isOn = true;
            if (buenasPracticas.preguntas[i].rptaCorrecta)
            {
                togglesCapacitacion[i].graphic.GetComponent<Image>().sprite = spriteCorrecto;
            }
            else
            {
                togglesCapacitacion[i].graphic.GetComponent<Image>().sprite = spriteIncorrecto;
            }
        }
    }
}
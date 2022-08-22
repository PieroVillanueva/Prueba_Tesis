using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerEscenarioSO : Lvl_Manager
{
    public SpawnerSO spawner;
    public PuntajeManagerSO puntaje;
    public TimerSO timer;
    public ElevadorSO elevador;
    [Header("Paneles")]
    public GameObject panelIniciar;
    public Text textoPanelIniciar;
    public GameObject panelSaltarPreparacion;
    public GameObject panelLobby;
    [Header("Botones")]
    public ColliderDinamico boton1;
    public ColliderDinamico boton2;
    [Header("Dificultad")]
    public float tiempoMedio;
    public float tiempoFinal;
    [Header("Tiempo Extra")]
    public bool tiempoExtra;
    public enum EstadosDeJuego { tutorial, invocacion, preparacion, ejecucion, finalizacion }
    [Header("Fases")]
    public EstadosDeJuego fasesDeJuego;
    public bool terminar;
    private bool tutorial;

    public int rondas;
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 

        //Corrutina que llama a las tareas a realizar, se ejecuta al inicio
        StartCoroutine(Tareas(actualTarea));
        //player = GameObject.Find("VR Rig").GetComponent<Movement>();
        IniciarTutorial();
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
        yield return new WaitForSeconds(1f);
        switch (tarea)
        {
            case 0:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 1:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
        }
    }

    void Update()
    { 
        //TiempoExtra();
        TerminarJuego();
    }

    public void AumentarDificultad()
    {
        /*if (timer.timers[0].tiempoXSegundo <= tiempoMedio && timer.timers[0].tiempoXSegundo > tiempoFinal)
        {
            spawner.maxColaboradores = 2;
            spawner.maximoCajasAbiertas = 2;
            spawner.maxCables = 2;
            //spawner.maxObstaculosAgua = 2;
            timer.timers[1].tiempoXSegundo -= 5;
        }
        else if (timer.timers[0].tiempoXSegundo <= tiempoFinal)
        {
            spawner.maxColaboradores = 3;
            spawner.maximoCajasAbiertas = 3;
            timer.timers[1].tiempoXSegundo -= 5;
        }*/
        if (rondas == 3)
        {
            spawner.maxColaboradores = 2;
            spawner.maxObstaculos = 4;
            timer.timers[1].tiempoXSegundo += 5;
        }
        else if (rondas == 6)
        {
            spawner.maxColaboradores = 3;
            spawner.maxObstaculos = 5;
            //spawner.maximoCajasAbiertas = 3;
            timer.timers[1].tiempoXSegundo += 5;
        }
        else if (rondas == 8)
        {
            //spawner.maximoCajasAbiertas = 5;
            spawner.maxObstaculos = 6;
            timer.timers[1].tiempoXSegundo += 5;
        }
        timer.timers[1].tiempoXSegundo = Mathf.Clamp(timer.timers[1].tiempoXSegundo, 20, 60);
    }

    public void TerminarJuego()
    {
        /*if (timer.timers[0].tiempoXSegundo == 0)
        {
            terminar = true;
            tutorial = false;
            ResetEscenario();

        }*/
        if (rondas == 10)
        {
            CumplirTarea(0);
            terminar = true;
            tutorial = false;
            ResetEscenario();
            panelLobby.SetActive(true);
        }
    }

    public void IniciarTutorial() => StartCoroutine(Iniciar());

    public void IniciarPartida() => StartCoroutine(IniciarJuego());

    public void TerminarPreparacion() => StartCoroutine(FinalizarPreparacion());

    public void TiempoExtra()
    {
        if (!tiempoExtra)
        {
            if (timer.timers[0].tiempoXSegundo == 0 && timer.timers[2].tiempoXSegundo != 0)
            {
                Debug.Log("Tiempo extra");
                timer.timers[0].tiempoXSegundo = timer.timers[2].tiempoXSegundo;
                timer.timers[2].tiempoXSegundo = 0;
                tiempoExtra = true;
            }
        }
    }

    public void FasesDeJuego() => StartCoroutine(Fases());

    public void ResetEscenario() => StartCoroutine(ResetAll());

    IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(14f);
        fasesDeJuego = EstadosDeJuego.tutorial;
        yield return new WaitForSeconds(1f);
        FasesDeJuego();
        yield return new WaitForSeconds(5f);
        panelIniciar.SetActive(true);
    }

    IEnumerator IniciarJuego()
    {
        panelSaltarPreparacion.SetActive(false);
        terminar = false;
        if (tutorial)
        {
            ResetEscenario();           
        }
        fasesDeJuego = EstadosDeJuego.invocacion;
        panelIniciar.SetActive(false);
        puntaje.ReiniciarPuntaje();
        yield return new WaitForSeconds(1f);
        boton1.primeraVez = false;
        FasesDeJuego();     
    }

    IEnumerator FinalizarPreparacion()
    {
        timer.timers[1].tiempoXSegundo = 1;
        timer.timers[1].textoTimer.text = "01";
        panelSaltarPreparacion.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        boton2.primeraVez = false;
    }

    IEnumerator ResetAll()
    {
        puntaje.ColocarPuntaje();
        panelIniciar.SetActive(false);
        panelSaltarPreparacion.SetActive(false);
        timer.EstadoTimer(false);
        timer.ReiniciarTiempo();
        yield return new WaitForSeconds(1f);
        spawner.DetenerColaboradores();
        yield return new WaitForSeconds(1f);
        spawner.ReiniciarColaboradores();
        spawner.ResetObstaculos();
        yield return new WaitForSeconds(0.1f);
        spawner.ReiniciarContadores();
        rondas = 0;
        Debug.Log("Se reinició el escenario");
        yield return new WaitForSeconds(6f);
        if (!tutorial)
        {
            elevador.abrir = false;
            elevador.iniciar = false;
            panelIniciar.SetActive(true);
            StopAllCoroutines();
        }
    }

    IEnumerator Fases()
    {
        if (!terminar)
        {
            switch (fasesDeJuego)
            {
                case EstadosDeJuego.tutorial:
                    StartCoroutine(faseTutorial());
                    break;
                case EstadosDeJuego.invocacion:
                    StartCoroutine(FaseInvocacion());
                    break;
                case EstadosDeJuego.preparacion:
                    StartCoroutine(FasePreparacion());
                    break;
                case EstadosDeJuego.ejecucion:
                    StartCoroutine(FaseEjecucion());
                    break;
                case EstadosDeJuego.finalizacion:
                    StartCoroutine(FaseFinalizacion());
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator faseTutorial()
    {
        Debug.Log("Iniciar tutorial");
        tutorial = true;
        spawner.SpawnerTutorial();
        yield return new WaitForSeconds(2f);
    }

    /*public void InvocarObstaculos()
    { 
        int probabilidad = Random.Range(0, 10);
        Debug.Log("Probabilidad de aguas: " + probabilidad);
        if (probabilidad <= probabilidadAgua)
        {
            spawner.ColocarObstaculoAgua();
        }
        probabilidad = Random.Range(0, 10);
        Debug.Log("Probabilidad de platanos: " + probabilidad);
        if (probabilidad <= probabilidadPlatano)
        {
            spawner.ColocarCascarasPlatano();
        }
    }*/

    IEnumerator FaseInvocacion()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSecondsRealtime(2f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Entró a la invocación");
        yield return new WaitForSeconds(2f);
        /*if(!timer.timers[0].activar){
            timer.EstadoTimer(true);
            timer.ComenzarTimer(timer.timers[0], 0);
        }*/
        timer.timers[1].ObtenerTiempo();
        spawner.AsignarOperario();
        spawner.Invocar();
        Debug.Log("Se Invocaron a los elementos");
        yield return new WaitForSeconds(0.2f);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(3f);
        if (!terminar)
        {
            fasesDeJuego = EstadosDeJuego.preparacion;
            FasesDeJuego();
            yield return new WaitForSeconds(6f);
            panelSaltarPreparacion.SetActive(true);
        }
    }

    IEnumerator FasePreparacion()
    {
        Debug.Log("Entró a la preparación");
        timer.timers[1].ReiniciarTiempo();
        timer.EstadoTimer(true);
        timer.ComenzarTimer(timer.timers[1], 1);
        Debug.Log("Preparate");
        while (timer.timers[1].tiempoXSegundo != 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
        panelSaltarPreparacion.SetActive(false);
        yield return new WaitForSeconds(1f);
        if (!terminar)
        {
            fasesDeJuego = EstadosDeJuego.ejecucion;
            FasesDeJuego();
        }
    }

    IEnumerator FaseEjecucion()
    {
        Debug.Log("Entró a la ejecución");
        elevador.ValidarPosicion();
        yield return new WaitForSeconds(1f);
        if (!terminar)
        {
            spawner.AvanceOperario();
        }
        Debug.Log("Start");
        yield return new WaitForSeconds(1f);
        while (spawner.HayOperariosEnEscena())
        {
            yield return new WaitForSeconds(1f);
        }
        timer.timers[1].ReiniciarTiempo();
        Debug.Log("Finalizó la ejecución");
        if (!terminar)
        {
            fasesDeJuego = EstadosDeJuego.finalizacion;
            FasesDeJuego();
        }
    }

    IEnumerator FaseFinalizacion()
    {
        Debug.Log("Finalizó");
        rondas++;
        spawner.ResetObstaculos();
        AumentarDificultad();
        yield return new WaitForSeconds(1f);
        if (!terminar)
        {
            fasesDeJuego = EstadosDeJuego.invocacion;
            FasesDeJuego();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerOyL_SO : Lvl_Manager
{
    public string textoPanel;
    public Text textoTimer;
    public Text texto;
    [Header("Timer")]
    public TimerOyL_SO timer;
    [Header("Obstaculos")]
    public List<ObstaculoSO> obstaculos;
    private List<ObstaculoSO> obstaculosList =  new List<ObstaculoSO>();
    public EliminarDocumentos_SO eliminar;
    public int maxObstaculos;
    public int obstaculosActual;
    [Header("Paneles")]
    public GameObject panelPuntaje;
    public GameObject panelIniciar;
    public GameObject panelLobby;
    private bool primerIntento;

    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 

        //Corrutina que llama a las tareas a realizar, se ejecuta al inicio
        StartCoroutine(Tareas(actualTarea));
        //player = GameObject.Find("VR Rig").GetComponent<Movement>();
        PosicionesInicialesObstaculos();
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
                yield return new WaitForSeconds(2f);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelIniciar.SetActive(true);
                break;
            case 1:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 2:
                yield return new WaitForSeconds(2f);
                while (audioController.audioSource.isPlaying == true)
                {
                    Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(2);
                break;
            case 3:
                
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                panelLobby.SetActive(true);
                break;

        }
    }

    public void PosicionesInicialesObstaculos()
    {
        foreach (ObstaculoSO aux in obstaculos)
        {
            aux.ObtenerPosicionInicial();
        }
    }

    private void ColocarObstaculos()
    {
        timer.activar = true;
        timer.IniciarTimer();
        panelIniciar.SetActive(false);
        panelLobby.SetActive(false);
        int posicion = 0;
        while (obstaculosActual < maxObstaculos)
        {
            posicion = Random.Range(0, obstaculos.Count);
            if (!obstaculos[posicion].enUso)
            {
                obstaculos[posicion].InvocarObstaculo();
                obstaculos[posicion].enUso = true;
                obstaculosList.Add(obstaculos[posicion]);
                obstaculosActual++;
            }
        }
    }

    public void FinalizarEscena()
    {
        CumplirTarea(1);
        foreach (ObstaculoSO aux in obstaculosList)
        {
            if (aux.enUso)
            {
                aux.EstadoFresnel(1);
            }
        }
        panelPuntaje.SetActive(true);
        panelIniciar.SetActive(true);
        timer.activar = false;
        texto.text += " " + (maxObstaculos - obstaculosActual) + "/" + maxObstaculos;
        primerIntento = true;
        timer.activar = false;
        timer.EstadoPanelesPorTiempo(false);
    }

    public void ReiniciarMateriales()
    {
        foreach (ObstaculoSO aux in obstaculosList)
        {
            aux.EstadoFresnel(0);
        }
        obstaculosList.Clear();
    }

    public void ReiniciarObstaculo()
    {
        foreach (ObstaculoSO aux in obstaculos)
        {
            aux.ReiniciarObstaculo();
            aux.enUso = false;    
        }
        
    }


    IEnumerator ReiniciarEscena()
    {
        obstaculosActual = 0;
        textoTimer.text = "00:00";
        
        ReiniciarMateriales();
        ReiniciarObstaculo();
        eliminar.ReiniciarDocumentos();
        yield return new WaitForSeconds(2f);
        //StopAllCoroutines();
    }

    public void Iniciar()
    {
        texto.text = textoPanel;
        StartCoroutine(ReiniciarEscena());
        CumplirTarea(0);
        ColocarObstaculos();
        
    }

}

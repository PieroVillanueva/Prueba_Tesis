using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Planeamiento1 : Lvl_Manager
{
    //Colocar valirables a utilizar
    //Un ejemplo lo encontramos en 03.Scripts > 05.Presentacion > Manager_Presentacion
    public FunAroPresentacionEC aro;
    public Firma activarFirma;
    public GameObject asignar;
    public FunCheckList listaTarea;
    public GameObject salida;
    public LetreroFuncion indicador;
    // Start is called before the first frame update
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 
        listaTarea.gameObject.SetActive(false);
        //Corrutina que llama a las tareas a realizar, se ejecuta al inicio
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
        yield return new WaitForSeconds(3);
        switch (tarea)
        {
            case 0:
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aro.gameObject.SetActive(true);
                break;
            case 1:
                //Copiar el formato y llamar a la siguienta tareas.. case 2,3,4,5....
                listaTarea.activarCheck(0);
                activarFirma.gameObject.SetActive(true);
                activarFirma.ValidarTomaDeLosObjetos(true);
                break;
            case 2:
                //asignar.Asignar();
                listaTarea.gameObject.SetActive(true);
                indicador.Terminar(true);
                listaTarea.activarCheck(1);
                salida.SetActive(true);
                asignar.SetActive(false);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Ejemplo : Lvl_Manager
{
    //Colocar valirables a utilizar
    //Un ejemplo lo encontramos en 03.Scripts > 05.Presentacion > Manager_Presentacion
    public FuncionAro aro;
    public Firma activarFirma;
    public AsigarObjetos asignar;
    public FunCheckList listaTarea;
    public GameObject salida;
    public ListaApps[] toggles;
    public bool ass;
    // Start is called before the first frame update
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 

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
                activarFirma.ValidarTomaDeLosObjetos(true);
                asignar.DesactivarLetrerosNoFirma();
                for (int i = 0; i < toggles.Length; i++ )
                {
                    toggles[i].ActivarToggles(true);
                }
                break;
            case 2:
                //asignar.Asignar();
                listaTarea.activarCheck(1);
                salida.SetActive(true);
                asignar.DesactivarLetreros();
                break;
        }
    }

    
}

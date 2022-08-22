using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Planeamiento : Lvl_Manager
{
    //Colocar valirables a utilizar
    //Un ejemplo lo encontramos en 03.Scripts > 05.Presentacion > Manager_Presentacion
    public FunAroLuz aro;
    public FunCheckList checkList;
    public FunLlamadoPool llamadoPool;
    public GameObject Salida;
    public GameObject Actividades;
    // Start is called before the first frame update
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 
        aro.gameObject.SetActive(false);
        Salida = GameObject.Find("Salida");
        Salida.SetActive(false);
        Actividades.SetActive(false);
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
        
        switch (tarea)
        {
            case 0:
                yield return new WaitForSeconds(3);

                while (audioController.audioSource.isPlaying == true)
                {
                    yield return new WaitForFixedUpdate();
                }
                Debug.Log("se termino el audio");
                
                aro.gameObject.SetActive(true);
                break;
            case 1:
                checkList.activarCheck(tarea-1);
                llamadoPool.mostrarEPP();
                break;
            case 2:
                checkList.activarCheck(tarea-1);
                Debug.Log("se ejecuta la tarea 2");
                llamadoPool.ocultarEPP();
                Salida.SetActive(true);
                Actividades.SetActive(true);
                /*
                aro.gameObject.transform.position = new Vector3(6.83f, 0.55f, 15.21f);
                aro.gameObject.GetComponent<FunAroLuz>().tareaACumplir = 2;
                aro.gameObject.SetActive(true); */


                break;
        }
    }

}

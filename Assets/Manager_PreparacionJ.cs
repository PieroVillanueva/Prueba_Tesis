using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager_PreparacionJ : Lvl_Manager
{
    // Start is called before the first frame update

    public static Manager_PreparacionJ mp;
    //public FunCheckList listaTarea;
    public GameObject salida;
    public bool si_anotado_1 = false;
 
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
        yield return new WaitForSeconds(1);
        switch (tarea)
        {
            case 0://v3-1
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(1);
                //CumplirTarea(0);

                break;
            case 1://v3-2

                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //if (G_Manager.gm.si_detecto == true) { CumplirTarea(1); }
                yield return new WaitForSeconds(1);
                Debug.Log("Se cumplio tarea 1");

                break;
            case 2://v3-4
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //if(si_anotado_1 == true) { si_anotado_1 = false;
                // CumplirTarea(1); 
                //}
                yield return new WaitForSeconds(1);
                break;
            case 3://v3-3
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 4://v3-4
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 5://v3-5
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 6://v3-6
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
              case 7://v3-7
                    while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 8://v3-8
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;

        }
    }
    private void Update()
    {
        if (G_Manager.gm.ya_limpio == true)
        {
            CumplirTarea(5);
            G_Manager.gm.ya_limpio = false;
        }
        if (G_Manager.gm.tapa_open==true)
        {
            CumplirTarea(0);
            G_Manager.gm.tapa_open = false;
        }
        if (G_Manager.gm.si_detecto == true)
        {
            if (G_Manager.gm.n_etapa == 1)
            {//si_anotado_1 = false;
                CumplirTarea(1);
            }
            
            if (G_Manager.gm.n_etapa == 2)
            {//si_anotado_1 = false;
                CumplirTarea(3);
            }
        }
       if (G_Manager.gm.anotado_T1==true)
        {
            CumplirTarea(2);
            G_Manager.gm.anotado_T1 = false;
        }
        if (G_Manager.gm.anotado_T2 == true)
        {
            CumplirTarea(4);
            G_Manager.gm.anotado_T2 = false;
        }
        if (G_Manager.gm.ya_medido_despues_limpieza == true)
        {
            CumplirTarea(6);
            G_Manager.gm.ya_medido_despues_limpieza = false;
        }
        if (G_Manager.gm.anotado_T3 == true)
        {
            CumplirTarea(7);
            G_Manager.gm.anotado_T3 = false;
        }
        if (G_Manager.gm.ya_permiso == true)
        {
            CumplirTarea(8);
            G_Manager.gm.ya_permiso = false;
            G_Manager.gm.n_etapa++;
        }
    }
}

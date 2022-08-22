using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_EP_Preparacion : Lvl_Manager
{
    public S_LlamadoPool_preparacion objectsPool;

    public S_bodyApps APPColocados;    
    public GameObject[] Apps;

    public S_listaObjetos ObjAuxiliares;
    public GameObject[] auxiliares;

    public FunCheckList listaChecks;
    public GameObject salida;

    public S_MarcarTablero[] tableros;
    public GameObject botonConfirmar;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        listaChecks.gameObject.SetActive(false);
        salida.gameObject.SetActive(false);
        StartCoroutine(Tareas(actualTarea));
    }

    // Update is called once per frame
    void ActivarTableros()
    {
        foreach(S_MarcarTablero toggle in tableros)
        {
            toggle.ActivarToggle(true);
        }
    }

    

    public override void CumplirTarea(int indexTarea)
    {
        listaChecks.activarCheck(indexTarea);
        base.CumplirTarea(indexTarea);

        StartCoroutine(Tareas(actualTarea));
    }

    
    IEnumerator Tareas(int tarea)
    {
        
        yield return new WaitForSeconds(3);        
        switch (tarea)
        {
            case 0:
                //Objetos de proteccion
                objectsPool.objetivos = Apps;
                while (audioController.audioSource.isPlaying == true)
                {
                    //esperando que termine el audio actual
                    yield return new WaitForFixedUpdate();
                }
                objectsPool.activar();
                Debug.Log("Activar obj proteccion");

                while (APPColocados.comprobarCantidadApp(Apps.Length)== false) 
                {
                    //esperando que tome todo los objetos de proteccion
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(1f);
                objectsPool.desactivar();
                Debug.Log("Desactivar obj proteccion");
                CumplirTarea(0);
                //objectsPool.objetivos = auxiliares;
                break;
            case 1:                
                //Objetos auxiliares
                objectsPool.objetivos = auxiliares;
                while (audioController.audioSource.isPlaying == true)
                {
                    //esperando que termine el audio actual
                    yield return new WaitForFixedUpdate();
                }
                objectsPool.activar();
                Debug.Log("Activar obj proteccion");
                while (ObjAuxiliares.comprobarLista(auxiliares.Length) == false)
                {
                    //esperando que tome todos lo objetos auxiliares
                    yield return new WaitForFixedUpdate();
                }

                yield return new WaitForSeconds(1f);
                objectsPool.desactivar();

                CumplirTarea(1);
                //Debug.Log("termino audio tarea 1");
                break;
            case 2:
                ActivarTableros();
                botonConfirmar.SetActive(true);
                Debug.Log("No hay caso especial");
                break;
            case 3:
                listaChecks.gameObject.SetActive(true);
                salida.gameObject.SetActive(true);
                break;

        }
    }

}

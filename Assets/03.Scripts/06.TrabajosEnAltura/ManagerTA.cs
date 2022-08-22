using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTA : Lvl_Manager
{
    public GameObject tablero_indi;
    public GameObject[] aros;
    public FunCheckList checkList;
    public MeshRenderer fresnelDestornillador;
    public int vidas, vidasMax;
    public override void Start()
    {
        fresnelDestornillador.material.SetFloat("_EMISSION", 1);
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
        switch (tarea)
        {
            case 0://revisar apps
                //Tarea inicial, se ejecuta al iniciar el proyecto
                //yield return new WaitForSeconds(2f);
                while (audioController.audioSource.isPlaying == true)
                {
                    Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();

                }
                aros[0].SetActive(true);

                break;
            case 1:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                checkList.activarCheck(0);
                break;
            case 2:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                checkList.activarCheck(1);
                aros[1].SetActive(true);
                tablero_indi.SetActive(true);
                break;
            case 3:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                checkList.activarCheck(2);
                break;
            case 4:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros[2].SetActive(true);
                break;
            case 5:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                
                break;
            case 6:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                checkList.activarCheck(3);
                break;
            case 7:
                yield return new WaitForSeconds(2f);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                checkList.activarCheck(4);
                fresnelDestornillador.material.SetFloat("_EMISSION", 1);
                break;
            case 8:
                aros[3].SetActive(true);
                yield return new WaitForSeconds(2f);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 9:
                
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                
                break;
            case 10:
                
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }

                break;
            case 11:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }

                break;
            case 12:
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }

                break;
        }
    }
}

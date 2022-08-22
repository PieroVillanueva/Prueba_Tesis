using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager_Ergo : Lvl_Manager
{
    bool Completa_tarea = false;
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
        if (tarea > GManagerErgo.ge.actualTarea)
        {
            GManagerErgo.ge.actualTarea = tarea;
        }
        yield return new WaitForSeconds(2);
        switch (tarea)
        {
            case 0://presentacion
                //Tarea inicial, se ejecuta al iniciar el proyecto
                GManagerErgo.ge.aros_ubic(tarea);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                Completa_tarea = true;
                //GManagerErgo.ge.aros_ubic(tarea);Se Completa en el aro0

                break;
            case 1://dirigir al ejer1
                GManagerErgo.ge.aros_ubic(1);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.panelesParte1[0].gameObject.SetActive(true);
                //GManagerErgo.ge.aros_ubic(tarea);Se Completa en panel0
                break;
            case 2://a pedir colocar cabeza
                GManagerErgo.ge.E1_cabeza_grab.SetActive(true);                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //Se Completa en E1_posC
                break;
            case 3://ir al siguiente trabajador pantalla y corregirlo
                GManagerErgo.ge.aros_ubic(2);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.panelesParte1[1].gameObject.SetActive(true);
                //GManagerErgo.ge.aros_ubic(tarea);Se Completa en E2_posM
                break;
            case 4://ir al siguiente trabajador teclado y corregirlo
                GManagerErgo.ge.panelesParte1[1].gameObject.SetActive(false);
                GManagerErgo.ge.aros_ubic(3);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.panelesParte1[2].gameObject.SetActive(true);

                //GManagerErgo.ge.aros_ubic(tarea);Se Completa en E3_posT
                break;
            case 5://ir al siguiente trabajador reposapies y corregirlo
                GManagerErgo.ge.panelesParte1[2].gameObject.SetActive(false);
                GManagerErgo.ge.aros_ubic(4);
                //Se Completa en E4_posR
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.panelesParte1[3].gameObject.SetActive(true);
                break;
            case 6://palabras de bien hecho
                GManagerErgo.ge.panelesParte1[3].gameObject.SetActive(false);
                //GManagerErgo.ge.aros_ubic(5);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(6);//Se Completa aqui;
                break;
            case 7://siguiente ala
                
                GManagerErgo.ge.aros_ubic(5);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }

                //Se Completa enen el aro6
                break;
            case 8://decir tarea parte2
                GManagerErgo.ge.tp_repos(90, 1);
                GManagerErgo.ge.aros_ubic(6);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                
                //Se Completa en panel5
                break;
            case 9://ver panel de despejar escritorio
                //GManagerErgo.ge.aros_ubic(6);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.panelesParte1[4].gameObject.SetActive(true);
                break;
            case 10://despejar escritorio
                GManagerErgo.ge.activar_items_desk();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //Se Completa en GManagerErgo.Ya_Total_Items();
                break;
            case 11://ir a iluminar habitacion
                //GManagerErgo.ge.aros_ubic(6);
                GManagerErgo.ge.aros_ubic(7);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.panelesParte1[5].gameObject.SetActive(true);
                //Se Completa en panel 5;
                break;
            case 12://iluminar habitacion
                //GManagerErgo.ge.aros_ubic(6);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                GManagerErgo.ge.E3_Lamp_ind.SetActive(true);
                //Se Completa en GManagerErgo.eventos_iluminacion();
                break;
            case 13://hacia la siguiente area de desarrollo
                GManagerErgo.ge.E3_Lamp_ind.SetActive(false);
                GManagerErgo.ge.aros_ubic(8);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //cumple en el aro8;
                break;
            case 14://audio E14 antes de finalizar
                GManagerErgo.ge.tp_repos(0, 2);
                //GManagerErgo.ge.aros_ubic(8);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(14);
                break;
            case 15://ver animacion y responder panel
                
                GManagerErgo.ge.aros_ubic(9);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                
                //se cumple en el panel6
                break;
            case 16://sele indica al usuario hacer el ejercicio
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(16);
                break;
            case 17://sele indica al usuario ir a ala carga
                GManagerErgo.ge.aros_ubic(10);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //secumple en el aro10
                break;
            case 18://sele indica al usuario que debe agacharse con la espalda recta
                //GManagerErgo.ge.aros_ubic(8);
                GManagerErgo.ge.panelesParte1[7].gameObject.SetActive(true);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //se cumple al agacharse de forma recta
                break;
            case 19://sele indica al usuario coger la carga y pegarla al cuerpo
                //GManagerErgo.ge.aros_ubic(8);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //se cumple al pegar la caja al pecho 
                break;
            case 20://sele indica al usuario ponerse de pie
                //GManagerErgo.ge.aros_ubic(8);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //se cumple al ponerse de pie con la cargar
                break;
            case 21://lleva carga hasta la mesa
                //GManagerErgo.ge.aros_ubic(8);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //se cumple al agacharse de forma recta
               
                break;
            case 22://audio de postura aprendida
                //GManagerErgo.ge.aros_ubic(8);
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //se cumple al agacharse de forma recta
                CumplirTarea(22);
                break;
            case 23://palabras de despedidas
                //GManagerErgo.ge.aros_ubic(8);
                GManagerErgo.ge.panelesParte1[8].SetActive(true);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //se cumple al agacharse de forma recta
                //CumplirTarea(22);
                break;
        }
    }
    private void Update()
    {

    }
}
   

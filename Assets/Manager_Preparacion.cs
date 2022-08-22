using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager_Preparacion : Lvl_Manager
{
    // Start is called before the first frame update
    public Permiso_ope anim_ope;
    public FuncionAro aro;
    public AsigarObjetos asignar;
    public FunCheckList listaTarea;
    public GameObject salida;
    public Toggle[] toggles;
    public ObjetoLetrero indicador;
    public CompletarListaApps completar;
    public BoxCollider[] botones;
    public bool si_anotado_1 = false;
    public bool ope1 = false;
    public bool ope2 = false;
    public GameObject aros2;
    
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
        if (tarea > G_Manager.gm.tarea)
        {
            G_Manager.gm.tarea = tarea;
        }
        yield return new WaitForSeconds(3);
        switch (tarea)
        {
            case 0://revisar apps
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aro.gameObject.SetActive(true);
                break;
            case 1://verifica apps
                //Copiar el formato y llamar a la siguienta tareas.. case 2,3,4,5....
                
                for (int i = 0; i < toggles.Length; i++)
                {
                    if (i < 10)
                    {
                        toggles[i].GetComponent<colision>().ActivarToggle(true);
                    }

                }
                
                completar.ActivarBoton(true);
                listaTarea.activarCheck(0);
                indicador.CumplirTarea(true);
                asignar.DesactivarApps();
                asignar.AsignarTableroApps();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //yield return new WaitForSeconds(2);
                //CumplirTarea(1);
                Debug.Log("Se cumplio tarea 1");

                break;
            case 2://poner en tablero
                G_Manager.gm.va.v_apps();
                for (int i = 0; i < toggles.Length; i++)
                {
                    if (i >= 10)
                    {
                        toggles[i].GetComponent<colision>().ActivarToggle(true);
                    }

                }
                //asignar.Asignar();
                listaTarea.activarCheck(1);
                //salida.SetActive(true);
                //asignar.DesactivarLetreros();
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //yield return new WaitForSeconds(2);
                //CumplirTarea(2);
                Debug.Log("Se cumplio tarea 2");
                break;
            case 3://v3-1
                //Tarea inicial, se ejecuta al iniciar el proyecto
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                aros2.SetActive(true);
                listaTarea.activarCheck(2);
                yield return new WaitForSeconds(1);
                //CumplirTarea(0);
                
                break;
            case 4://v3-2
               // G_Manager.gm.detector_indicador.SetActive(true);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                
                yield return new WaitForSeconds(1);
                Debug.Log("Se cumplio tarea 1");
                listaTarea.activarCheck(3);
                break;
            case 5://v3-4
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                yield return new WaitForSeconds(1);
                break;
            case 6://v3-3
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                    listaTarea.activarCheck(5);
                }
                break;
            case 7://v3-4
                listaTarea.activarCheck(6);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 8://v3-5
                listaTarea.activarCheck(7);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                    
                }
                break;
            case 9://v3-7 usar cuerda , medicion anotacion
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                    listaTarea.activarCheck(8);
                }
                break;
            case 10://v3-8 autorizar
                listaTarea.activarCheck(9);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                    
                }
                break;
            case 11://v3-9 firmar permiso
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                //aqui
                botones[0].enabled = true;
                botones[1].enabled = true;
                listaTarea.activarCheck(10);
                break;
            case 12://V3-9agarrar wt
                listaTarea.activarCheck(11);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                G_Manager.gm.wt_indicador.SetActive(true);
                
                break;
            case 13://v3-10 espera respuesta
                listaTarea.activarCheck(12);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                    G_Manager.gm.wt_indicador.SetActive(true);
                }
                Debug.Log("seagarro wt");
                ope1 = true;
                break;
            case 14://v3-11 salida de operario
                listaTarea.activarCheck(13);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                Debug.Log("hablo op1");
                ope2 = true;
                break;
            case 15://v3-12 firma final
                anim_ope.StartCoroutine("s_o");
                listaTarea.activarCheck(14);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                botones[2].enabled = true;
                Debug.Log("hablo op2");
                
                break;
            case 16://v3-13salida

                listaTarea.activarCheck(15);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                salida.SetActive(true);
                break;
  

        }
    }
    private void Update()
    {
        if (G_Manager.gm.si_accidente == false) {
            if (G_Manager.gm.tapa_open == true)
            {
                CumplirTarea(3);
                G_Manager.gm.tapa_open = false;
            }
            if (G_Manager.gm.si_detecto == true)
            {
                if (G_Manager.gm.n_etapa == 1 && G_Manager.gm.si_accidente == false)
                {//si_anotado_1 = false;
                    CumplirTarea(4);
                }
            }
            if (G_Manager.gm.n_etapa == 3 && actualTarea == 6)
            {//si_anotado_1 = false;
                CumplirTarea(6);
            }
            if (G_Manager.gm.anotado_T1 == true)
            {
                listaTarea.activarCheck(4);
                CumplirTarea(5);
                G_Manager.gm.anotado_T1 = false;
                //G_Manager.gm.n_etapa++;
            }

            if (G_Manager.gm.ya_limpio == true)
            {
                CumplirTarea(7);
                G_Manager.gm.ducto_limpio = true;
                G_Manager.gm.ya_limpio = false;
            }

            if (G_Manager.gm.anotado_T2 == true)
            {
                CumplirTarea(8);
                G_Manager.gm.anotado_T2 = false;
            }
            if (G_Manager.gm.anotado_T3 == true)
            {
                CumplirTarea(9);
                G_Manager.gm.anotado_T3 = false;
            }
            if (G_Manager.gm.ya_permiso == true && G_Manager.gm.si_accidente == false)
            {
                CumplirTarea(10);
                G_Manager.gm.ya_permiso = false;
                G_Manager.gm.n_etapa++;
            }
            if (G_Manager.gm.ya_firma == true)
            {
                CumplirTarea(11);
                G_Manager.gm.ya_firma = false;
                //listaTarea.activarCheck(10);
            }
            if (G_Manager.gm.yo_contesto == true)
            {
                //listaTarea.activarCheck(11);
                CumplirTarea(12);

                G_Manager.gm.yo_contesto = false;
            }
            if (ope1 == true)
            {
                CumplirTarea(13);
                //listaTarea.activarCheck(12);
                ope1 = false;
            }
            if (ope2 == true)
            {
                CumplirTarea(14);
                //listaTarea.activarCheck(13);
                ope2 = false;
            }
            if (G_Manager.gm.ya_salida == true)
            {
                CumplirTarea(15);
                G_Manager.gm.ya_salida = false;
                //listaTarea.activarCheck(14);
            }
        }

        if (G_Manager.gm.tapa_open == true)
        {
            CumplirTarea(3);
            G_Manager.gm.tapa_open = false;
        }
        if (G_Manager.gm.si_detecto == true)
        {
            if (G_Manager.gm.n_etapa == 1&&G_Manager.gm.si_accidente==false)
            {//si_anotado_1 = false;
                CumplirTarea(4);
            }
        }
        if (G_Manager.gm.n_etapa == 3 &&actualTarea==6)
        {//si_anotado_1 = false;
            CumplirTarea(6);
        }
        if (G_Manager.gm.anotado_T1 == true)
        {
            listaTarea.activarCheck(4);
            CumplirTarea(5);
            G_Manager.gm.anotado_T1 = false;
            //G_Manager.gm.n_etapa++;
        }
        
        if (G_Manager.gm.ya_limpio == true)
        {
            CumplirTarea(7);
            G_Manager.gm.ducto_limpio = true;
            G_Manager.gm.ya_limpio = false;
        }
       
        if (G_Manager.gm.anotado_T2 == true)
        {
            CumplirTarea(8);
            G_Manager.gm.anotado_T2 = false;
        }
        if (G_Manager.gm.anotado_T3 == true)
        {
            CumplirTarea(9);
            G_Manager.gm.anotado_T3 = false;
        }
        if (G_Manager.gm.ya_permiso == true&&G_Manager.gm.si_accidente==false)
        {
            CumplirTarea(10);
            G_Manager.gm.ya_permiso = false;
            G_Manager.gm.n_etapa++;
        }
        if (G_Manager.gm.ya_firma == true)
        {
            CumplirTarea(11);
            G_Manager.gm.ya_firma = false;
            //listaTarea.activarCheck(10);
        }
        if (G_Manager.gm.yo_contesto == true)
        {
            //listaTarea.activarCheck(11);
            CumplirTarea(12);
            
            G_Manager.gm.yo_contesto = false;
        }
        if (ope1 == true)
        {
            CumplirTarea(13);
            //listaTarea.activarCheck(12);
            ope1 = false;
        }
        if (ope2 == true)
        {
            CumplirTarea(14);
            //listaTarea.activarCheck(13);
            ope2 = false;
        }
        if (G_Manager.gm.ya_salida == true)
        {
            CumplirTarea(15);
            G_Manager.gm.ya_salida = false;
            //listaTarea.activarCheck(14);
        }
    }
}

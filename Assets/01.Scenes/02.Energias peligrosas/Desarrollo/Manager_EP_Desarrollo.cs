using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_EP_Desarrollo : Lvl_Manager
{
    //Colocar valirables a utilizar
    //Un ejemplo lo encontramos en 03.Scripts > 05.Presentacion > Manager_Presentacion

    public FunCheckList checkList;
    public FunLlamadoPoolDesarrollo llamadoPool;
    public MeshRenderer m_Motor;
    public MeshRenderer m_Caja;
    public GameObject[] objetosParaTurno;
    public MeshRenderer m_InterruptorPanel1;
    public MeshRenderer m_InterruptorPanel2;
    public GameObject snapGancho;
    public GameObject[] Electrificar;
    public GameObject[] letreros;

    // Start is called before the first frame update
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();
        //Adicionar estado de la variables 
        //Corrutina que llama a las tareas a realizar, se ejecuta al inicio
        StartCoroutine(Tareas(actualTarea));
        letreros[0].SetActive(false);
        letreros[1].SetActive(false);
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
            case 0://ALCANZAR PUERTA
                yield return new WaitForSeconds(3);

                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                Debug.Log("se termino el audio");

                break;
            case 1://APAGAR MAQUINA
                checkList.activarCheck(tarea - 1);
                Debug.Log("Puerta Alcanzada");
                m_Motor.material.SetFloat("_EMISSION", 1);
                objetosParaTurno[0].GetComponent<BotonMaquinaFun>().Turno = 1;
                //Copiar el formato y llamar a la siguienta tareas.. case 2,3,4,5....
                Electrificar[0].SetActive(true);
                Electrificar[1].SetActive(true);
                break;
            case 2://APAGAR INTERRUPTOR
                checkList.activarCheck(tarea - 1);
                Debug.Log("Maquina Apagada");
                m_Motor.material.SetFloat("_EMISSION", 0);
                objetosParaTurno[1].GetComponent<FunBotonLlave>().Turno = 1;
                m_InterruptorPanel1.material.SetFloat("_EMISSION", 1);
                m_InterruptorPanel2.material.SetFloat("_EMISSION", 1);
                break;
            case 3://COLOCAR BLOQUEO
                checkList.activarCheck(tarea - 1);
                Debug.Log("Interruptor Apagado");
                m_InterruptorPanel1.material.SetFloat("_EMISSION", 0);
                m_InterruptorPanel2.material.SetFloat("_EMISSION", 0);
                //llamadoPool.activar(0, 2);
                llamadoPool.activar(0, 1);
                Electrificar[0].SetActive(false);
                Electrificar[1].SetActive(false);
                objetosParaTurno[4].GetComponent<FunMaquina>().Turno = 0;
                break;
            case 4://COLOCAR TARJETA
                checkList.activarCheck(tarea - 1);
                Debug.Log("Bloqueo  Colocado");
                //llamadoPool.desactivar(0, 2);
                llamadoPool.desactivar(0, 1);
                //llamadoPool.activar(2, 3);
                llamadoPool.activar(1, 3);
                break;
            case 5://COLOCAR CANDADO
                checkList.activarCheck(tarea - 1);
                Debug.Log("Tarjeta Colocada");
                //llamadoPool.desactivar(2, 3);
                llamadoPool.desactivar(2, 3);

                break;
            case 6:// AGARRAR MEDIDOR
                checkList.activarCheck(tarea - 1);
                Debug.Log("Candado Colocado");
                llamadoPool.desactivar(1, 2);

                llamadoPool.activar(3, 4);
                objetosParaTurno[2].GetComponent<PanelFun>().TurnoAgarrarPolo = 1;
                break;
            case 7://MEDIR FASES
                checkList.activarCheck(tarea - 1);
                Debug.Log("Medidor agarrado");
                objetosParaTurno[2].GetComponent<PanelFun>().TurnoAgarrarPolo = 0;
                objetosParaTurno[2].GetComponent<PanelFun>().TurnoActivarPolo = 1;
                break;
            case 8:// COLOCAR GANCHO
                checkList.activarCheck(tarea - 1);
                Debug.Log("Fases Medidas");
                llamadoPool.desactivar(3, 4);
                snapGancho.SetActive(true);
                llamadoPool.activar(5, 6);
                objetosParaTurno[2].GetComponent<PanelFun>().TurnoActivarPolo = 0;
                objetosParaTurno[3].GetComponent<FunGanchoSnap>().Turno = 1;
                break;
            case 9://REVISAR MAQUINA
                checkList.activarCheck(tarea - 1);
                Debug.Log("Gancho Colocado");
                llamadoPool.desactivar(5, 6);
                objetosParaTurno[3].GetComponent<FunGanchoSnap>().Turno = 0;
                m_Motor.material.SetFloat("_EMISSION", 1);
                objetosParaTurno[0].GetComponent<BotonMaquinaFun>().Turno = 2;
                break;
            case 10:// REVISAR MAQUINA
                checkList.activarCheck(tarea - 1);
                Debug.Log("Maquina Revisada");
                llamadoPool.activar(6, 7);
                objetosParaTurno[4].GetComponent<FunMaquina>().Turno = 1;
                m_Motor.material.SetFloat("_EMISSION", 0);
                m_Caja.material.SetFloat("_EMISSION", 1);
                break;
            case 11://FINALIZAR
                checkList.activarCheck(tarea - 1);
                Debug.Log("Destornillador Usado");
                llamadoPool.desactivar(6, 7);
                objetosParaTurno[4].GetComponent<FunMaquina>().Turno = 0;
                letreros[0].SetActive(true);
                letreros[1].SetActive(true);
                break;
        }
    }
}
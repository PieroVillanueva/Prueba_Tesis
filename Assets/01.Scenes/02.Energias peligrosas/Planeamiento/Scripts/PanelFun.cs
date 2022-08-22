using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFun : MonoBehaviour
{
    public bool maquinaApagada;
    public bool llaveApagada;

    public bool bloqueoColocado;
    public bool candadoColocado;
    public bool tarjetaColocada;
    public bool tresColocados;//EVALUAR PARA ELIMINAR

    public bool[] activadoPositivos;
 
    public bool PrimeraVezAgarraPolos;
    public GameObject snapBloqueo;
    public GameObject snapCandado;
    public GameObject snapTarjeta;
    public GameObject snapGancho;
    public FunCheckList checkList;
    public bool enganchado;

    public float voltaje;
    public Lvl_Manager lvl_manager;

    public int TurnoAgarrarPolo=0;
    public int TurnoActivarPolo = 0;
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();

    }
    void Start()
    {
        snapBloqueo.SetActive(false);
        snapCandado.SetActive(false);
        snapTarjeta.SetActive(false);

        snapGancho.SetActive(false);
        voltaje = 220.0f;
    } 
    private void ReiniciarPositivos()
    {
        for (int i = 0; i < activadoPositivos.Length; i++)
        {
            activadoPositivos[i] = false;
        }
    }
    public void AgarrarPolo()
    {
        if (TurnoAgarrarPolo==1) {
            if(!PrimeraVezAgarraPolos)
            {
                PrimeraVezAgarraPolos = true;
                lvl_manager.CumplirTarea(6);
            }
        }
    }

    public void ActivarPolo(int posicion)
    {
        if (TurnoActivarPolo == 1) { 
            
                activadoPositivos[posicion] = true;
                if(activadoPositivos[0]&& activadoPositivos[1]&& activadoPositivos[2]&& activadoPositivos[3])
                {
                            Debug.Log("PRIMERA FASE LOGRADADA");
                            //COLOCAR  AUDIO 8
                            lvl_manager.CumplirTarea(7);
                }
            
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        if (maquinaApagada && llaveApagada)
        {
            snapBloqueo.gameObject.SetActive(true);
            if (bloqueoColocado)
            {
                snapTarjeta.SetActive(true);
                if (tarjetaColocada)
                {
                    snapCandado.SetActive(true);
                }
                else
                {
                    snapCandado.SetActive(false);
                }
            }
            else
            {
                snapTarjeta.SetActive(false);
            }
        }

       
    }
    public void IniciarReduccion()
    {
        if (voltaje == 220) {
            StartCoroutine(ReducirCorriente());
        }
    }
    IEnumerator ReducirCorriente()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        voltaje -= 44;
        yield return new WaitForSecondsRealtime(0.4f);
        voltaje -= 44;
        yield return new WaitForSecondsRealtime(0.4f);
        voltaje -= 44;
        yield return new WaitForSecondsRealtime(0.4f);
        voltaje -= 44;
        yield return new WaitForSecondsRealtime(0.4f);
        voltaje -= 44;
        print("Termine");
    }
}

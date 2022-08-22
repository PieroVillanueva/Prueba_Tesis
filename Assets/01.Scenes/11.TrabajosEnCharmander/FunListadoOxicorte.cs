using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunListadoOxicorte : MonoBehaviour
{
    public Toggle[] checks;
    public int posCheck;
    public Color[] coloresNecesarios;
    [Header("Validacion")]
    public bool[] checksListos;
    public bool todosChecksListos;

    [Header("Revision area")]
    public bool sacarPata;  //trabajoEnCaliente
    public bool pisoLimpio; //funciones
    public bool revisionGas;//trabajoEnCaliente
    public FunValidacionesTrabajosEnCaliente trabajoEnCaliente;

    [Header("PorValidar")]
    public bool llenadoTablero;//checkListTablero
    public bool eppColocado;//trabajoEnCaliente
    public bool permisoFirmado;//cuboParaFirmar.activeInHierarchy;
    public bool terminarTrabajo;

    public FunFuncionesTra_Caliente funciones;
    public FunCheckListConColor checkListTablero;
    public GameObject cuboParaFirmar;
    public GameObject firma;

    [Header("AnimacionLetrero")]
    public FunAnimacionUI animacionUI;
    public AudioSource reproductor;
    public AudioClip[] listarAudios;

    void Start()
    {
        checks = GetComponentsInChildren<Toggle>();
        checksListos = new bool[checks.Length];

    }
    // Update is called once per frame
    void Update()
    {
        //inspeccion area
        sacarPata = trabajoEnCaliente.retirarPersonalNoAutorizado;
        pisoLimpio = !funciones.existeBasura;
        revisionGas = trabajoEnCaliente.revisionDeGases;
        //inspeccion equipos
        llenadoTablero = checkListTablero.todosChecksListos;
        //epp
        eppColocado = trabajoEnCaliente.todosEPPColocados;



        if (sacarPata && pisoLimpio && revisionGas)
        {
            activarUnCheck(0);//inspeccion area
            if (llenadoTablero && eppColocado)
            {
                cuboParaFirmar.SetActive(true);
            }
        }
        if (llenadoTablero)
        {
            activarUnCheck(1);//inspección equipos
        }
        if (eppColocado)
        {
            activarUnCheck(2);//epp
        }
        if (trabajoEnCaliente.segundaFirma)
        {
           activarUnCheck(3);//completar permiso
        }

    } 

    public void terminarTrabajoExterno()
    {
        terminarTrabajo = true;
        activarUnCheck(4);//inspeccion ejecucion tarea
    }
    public void colocarSoplete()
    {
        if (terminarTrabajo)
        {
            reproductor.PlayOneShot(listarAudios[5]);
        }
    }

    public void activarUltimoCheck()
    {
        checks[posCheck].isOn = true;
        checks[posCheck].GetComponent<Image>().color = coloresNecesarios[0];
        checkearCheck(posCheck);
        posCheck++;
    }
    public void activarUnCheck(int pos)
    {
        if (!checks[pos].isOn)
        {
            animacionUI.llamarSiguientePanel();
            reproductor.PlayOneShot(listarAudios[pos]);
        }

        checks[pos].isOn = true;
        checks[pos].GetComponent<Image>().color = coloresNecesarios[0];
        checkearCheck(pos);
    }

    public void reiniciar()
    {
        for (int i = 0; i < checks.Length; i++)
        {
            checks[i].isOn = false;
            checks[i].GetComponent<Image>().color = coloresNecesarios[1];
        }
        posCheck = 0;
    }

    private bool validarArreglo(bool[] arreglo)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (!arreglo[i])
            {
                return false;
            }
        }
        return true;
    }
    public void checkearCheck(int pos)
    {
        checksListos[pos] = true;
        if (validarArreglo(checksListos))
        {
            todosChecksListos = true;
        }
    }
}

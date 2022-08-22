using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunControladorRevisarEPP : FunControlador
{
    public EPP_Manager em;
    public bool[] ColocadoCabeza;
    public bool[] ColocadoOjosYCara;
    public bool[] ColocadosOidos;
    public bool[] ColocadoManos;
    public bool[] ColocadoRespiratoria;
    public bool[] ColocadoRopa;
    public bool[] ColocadoZapatos;

    
    public GameObject snapOjos;
    public GameObject snapOidos;
    public GameObject snapManos;
    public GameObject snapRespiratorias;
    public GameObject snapRopaProtectora;
    public GameObject snapZapatosSeguridad;

    public FunPuertaLevadiza[] PuertaLevadizas;
    public Text cartel;

    public AudioSource Reproductor;

    public GameObject letreroFinalizado;

    public GameObject[] letrerosFinal;
    public override void validarColocado(string version, string descripcion, bool[] validar, GameObject snapZone, int nPuerta)
    {
        // Se activan los boleanos dependiendo de la version seleccionada 
        if (version == "A" && !validar[0]) 
        {
            validar[0] = true;
        }
        if (version == "B" && !validar[1])
        {
            validar[1] = true;
        }
        if (version == "C" && !validar[2])
        {
            validar[2] = true;
        }
        if (version == "D" && !validar[3])
        {
            validar[3] = true;
        }
        if (version == "E" && !validar[4])
        {
            validar[4] = true;
        }
        if (validarArreglo(validar)) // En caso se complete todos los epp
        {
            switch (em.actualTarea) // Se cumple la tarea solo cuando se completa el arreglo 
            {
                case 1: 
                    em.CumplirTarea(1);
                    break;
                case 4:
                    em.CumplirTarea(4);
                    break;
                case 7:
                    em.CumplirTarea(7);
                    break;
                case 10:
                    em.CumplirTarea(10);
                    break;
                case 13:
                    em.CumplirTarea(13);
                    break;
                case 16:
                    em.CumplirTarea(16);
                    break;
                case 19:
                    em.CumplirTarea(19);
                    break;
            }
            if (snapZone != null)
            {
                StartCoroutine(ActivarSnapZone(snapZone));//activa snapzone y letrero
                PuertaLevadizas[nPuerta].LlamarSubida();
               
                
            }
            else// En caso se logre llegar al último nivel se activan los letreros
            {
                letrerosFinal[0].SetActive(true);  
                letrerosFinal[1].SetActive(true);
            }
            //COLOCAR AUDIO JULIO
        }
        cartel.text = descripcion;
    }

    public override void EppColocado(FunTipoEPP tipo) // Cuando se conoca los modelos se llama a esta funcion que valida el colocado con los datos necesarios
    {
        Reproductor.PlayOneShot(tipo.audioDescripcion);
        Debug.Log("SONANDO");

        switch (tipo.parteCuerpo.ToString())
        {
            case "Cabeza":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadoCabeza, snapOjos, 0);
                break;

            case "Ojos":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadoOjosYCara, snapOidos, 1);
                break;

            case "Oidos":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadosOidos, snapManos, 2);
                break;

            case "Manos":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadoManos, snapRespiratorias, 3);
                break;

            case "Respiratoria":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadoRespiratoria, snapRopaProtectora, 4);
                break;

            case "Ropa":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadoRopa, snapZapatosSeguridad, 5);
                break;

            case "Pies":
                validarColocado(tipo.version.ToString(), tipo.descripcion, ColocadoZapatos, null, -1);
                break;

        }
    }
    IEnumerator ActivarSnapZone(GameObject snapZone)
    {
        letreroFinalizado.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        snapZone.SetActive(true);
        
    }

}

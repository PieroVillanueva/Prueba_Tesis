using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunNivelVestuarioController : MonoBehaviour
{
    public XrSocketEPPVestuario[] snapZones;
    public string[] VersionEppCorrecto;
   
    public FunCheckVestidor checkVestidor;
    public int correctos;
    public int total;
    public Text resultado;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            RevisarEPPColocados();
        }
    }
    
    private void RevisarEPPColocados()
    {
        for (int i = 0; i < 7; i++)
        {
            if (snapZones[i].eppColocadoFinal != null) {
                string versionColocada = snapZones[i].eppColocadoFinal.GetComponent<FunTipoEPP>().version.ToString();
                if (versionColocada == VersionEppCorrecto[i])
                {
                    //agregar a la lista EN VERDE
                    checkVestidor.asignarToggle(1, snapZones[i].eppColocadoFinal.GetComponent<FunTipoEPP>().nombreTecnico, snapZones[i].parteCuerpo.ToString());
                    correctos++;
                    total++;
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (snapZones[i].eppColocadoFinal != null)
            {
                string versionColocada = snapZones[i].eppColocadoFinal.GetComponent<FunTipoEPP>().version.ToString();
                if (versionColocada != VersionEppCorrecto[i])//INCORRECTO O DE MÁS
                {
                    //agregar a la lista EN ROJO
                    checkVestidor.asignarToggle(2,snapZones[i].eppColocadoFinal.GetComponent<FunTipoEPP>().nombreTecnico, snapZones[i].parteCuerpo.ToString());
                    total++;
                }
            }
            else
            {
                if (VersionEppCorrecto[i] != "")//FALTA EPP
                {
                    //agregar a la lista EN ROJO
                    checkVestidor.asignarToggle(2, "No se colocó EPP necesario", snapZones[i].parteCuerpo.ToString());
                    total++;
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (snapZones[i].eppColocadoFinal == null && VersionEppCorrecto[i]== "")//NO NECESITA EPP
            {
                //agregar a la lista EN PLOMO
                checkVestidor.asignarToggle(3, "", snapZones[i].parteCuerpo.ToString());

            }
        }
        resultado.text = "CORRECTOS:  " + correctos + " / " + total;

    }

}

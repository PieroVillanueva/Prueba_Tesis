using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunGuantesManager : FunManagerMostrarObjetos
{
    public GameObject manos;
    public override void CambiarColor(FunTipoEPP tipo, bool resaltar)
    {

        switch (tipo.version.ToString())
        {
            case "A":
                //resaltado(0, 1, resaltar);
                resaltado2(0, resaltar);
                break;
            case "B":
                //resaltado(1, 2, resaltar);
                resaltado2(1, resaltar);
                break;
            case "C":
                //resaltado(0, 1, resaltar);
                //resaltado(2, 3, resaltar);

                resaltado2(0, resaltar);
                resaltado2(2, resaltar);
                break;
        }
    }
    public override void MostrarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                manos.SetActive(false);
                MostrarColocado(0);
                break;
            case "B":
                manos.SetActive(false);
                MostrarColocado(1);
                break;
            case "C":
                ModelosDefault[3].SetActive(false);
                manos.SetActive(false);
                MostrarColocado(0);
                MostrarColocado(2);
                break;
        }
    }
    public override void OcultarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                manos.SetActive(true);
                OcultarColocado(0);
                break;

            case "B":
                manos.SetActive(true);
                OcultarColocado(1);
                break;

            case "C":
                ModelosDefault[3].SetActive(true);
                manos.SetActive(true);
                OcultarColocado(0);
                OcultarColocado(2);
                break;
        }
    }
}


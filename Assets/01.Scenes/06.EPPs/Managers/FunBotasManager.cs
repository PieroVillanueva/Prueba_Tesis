using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBotasManager : FunManagerMostrarObjetos
{
    public GameObject pies;
    public override void CambiarColor(FunTipoEPP tipo, bool resaltar)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                //resaltado(0,4, resaltar);
                resaltado2(0, resaltar);
                break;
        }
    }
    public override void MostrarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                pies.SetActive(false);
                MostrarColocado(0);
                break;
        }
    }
    public override void OcultarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                pies.SetActive(true);
                OcultarColocado(0);
                break;
        }
    }
}

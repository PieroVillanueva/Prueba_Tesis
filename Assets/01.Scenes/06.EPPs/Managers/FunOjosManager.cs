using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunOjosManager : FunManagerMostrarObjetos
{
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
        }
    }
    public override void MostrarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                MostrarColocado(0);
                break;
            case "B":
                MostrarColocado(1);
                break;
        }
    }
    public override void OcultarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                OcultarColocado(0);
                break;
            case "B":
                OcultarColocado(1);
                break;
        }
    }
}


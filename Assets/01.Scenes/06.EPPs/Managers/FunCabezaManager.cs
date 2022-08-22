using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunCabezaManager : FunManagerMostrarObjetos
{
    public override void CambiarColor(FunTipoEPP tipo, bool resaltar)// cambia el color a azul u original, dependiendo del resaltar
    {
        switch (tipo.version.ToString())
        {
            case "A":
                resaltado2(0, resaltar);
                break;
            case "B":
                resaltado2(1, resaltar);
                break;
            case "C":
                resaltado2(2, resaltar);
                break;
            case "D":
                resaltado2(3, resaltar);
                break;
            case "E":
                resaltado2(4, resaltar);
                break;
        }
    }
    public override void MostrarMostrable(FunTipoEPP tipo)// Activa modelo colocado y oculta original
    {
        switch (tipo.version.ToString())
        {
            case "A":
                MostrarColocado(0);
                break;
            case "B":
                MostrarColocado(1);
                break;
            case "C":
                MostrarColocado(2);
                break;
            case "D":
                MostrarColocado(3);
                break;
            case "E":
                MostrarColocado(4);
                break;
        }
    }
    public override void OcultarMostrable(FunTipoEPP tipo)// Oculta modelo colocado y muestra original
    {
        switch (tipo.version.ToString())
        {
            case "A":
                OcultarColocado(0);
                break;
            case "B":
                OcultarColocado(1);
                break;
            case "C":
                OcultarColocado(2);
                break;
            case "D":
                OcultarColocado(3);
                break;
            case "E":
                OcultarColocado(4);
                break;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunRopaManager : FunManagerMostrarObjetos
{
    public GameObject camisa;
    public GameObject reflejo;
    public GameObject pantalon;
    public override void CambiarColor(FunTipoEPP tipo, bool resaltar)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                //resaltado(0, 1, resaltar);
                resaltado2(0, resaltar);
                break;
        }
    }
    public override void MostrarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                camisa.SetActive(false);
                reflejo.SetActive(false);
                pantalon.SetActive(false);
                MostrarColocado(0);
                break;
        }
    }
    public override void OcultarMostrable(FunTipoEPP tipo)
    {
        switch (tipo.version.ToString())
        {
            case "A":
                camisa.SetActive(true);
                reflejo.SetActive(true);
                pantalon.SetActive(true);
                OcultarColocado(0);
                break;
        }
    }
}

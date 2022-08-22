using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunNombreEPP : LetreroDePoolFun
{
    public Text nombreEPP;
    public override void SetObjetoSeguido(GameObject seguido)
    {
        nombreEPP.text = seguido.GetComponent<FunTipoEPP>().nombreTecnico;
        base.SetObjetoSeguido(seguido);
    }
    public override void EliminarSeguimiento()
    {
        nombreEPP.text = "";
        base.EliminarSeguimiento();
    }
}

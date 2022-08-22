using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunControlador : MonoBehaviour
{
    public enum Version { A, B, C, D, E, F, G, H };
    public enum ParteCuerpo { Cabeza, Ojos, Oidos, Manos, Respiratoria, Ropa, Pies };

    public bool validarArreglo(bool[] arreglo)
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
    public virtual void validarColocado(string version, string descripcion, bool[] validar, GameObject snapZone, int nPuerta)
    {
       
    }
    public virtual void EppColocado(FunTipoEPP tipo)
    {

    }

}

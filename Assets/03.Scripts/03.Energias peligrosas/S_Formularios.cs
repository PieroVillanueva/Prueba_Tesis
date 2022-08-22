using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Formularios : MonoBehaviour
{
    public MeshRenderer tablero;
    public Texture[] formularios;
    public GameObject[] formularioUI;
    public int actualPG;

    
    void Start()
    {
        tablero.material.SetTexture("_MainTex", formularios[0]);
    }

    /// <summary>
    /// Metodo que llama al cambio de pagina del tablero
    /// </summary>
    /// <param name="value">valor para cambiar de pagina debe ser -1 o 1</param>
    public void CambioPagina(int value)
    {
        formularioUI[actualPG].SetActive(false);
        actualPG += value;
        actualPG = Mathf.Clamp(actualPG, 0, formularios.Length - 1);
        RecargarMaterial(actualPG);
    }

    void RecargarMaterial(int value)
    {
        formularioUI[value].SetActive(true);
        tablero.material.SetTexture("_MainTex", formularios[value]);
    }
}

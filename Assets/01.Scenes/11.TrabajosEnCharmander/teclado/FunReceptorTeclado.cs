using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FunReceptorTeclado : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField textoEscrito;
    public string cadena;    
    public List<Clave> claves;
    public GameObject teclado;
    public GameObject entrada;
    
    void Start()
    {
        textoEscrito.text = "Escribir Clave";
        //PlayerPrefs.DeleteKey("Logeado");
        Debug.Log(PlayerPrefs.GetString("Logeado"));
        if (PlayerPrefs.HasKey("Logeado") && validarLimite())
        {
            Debug.Log("CLAVE VÁLIDA HASTA: " + PlayerPrefs.GetString("Logeado"));
            teclado.SetActive(false);
            entrada.SetActive(true);
        }
        else
        {
            teclado.SetActive(true);
            entrada.SetActive(false);
        }
    }

    public void escribirLetra(string letra)
    {
        if (letra != "-")
        {
            if (letra == "+")
            {
                if (validarTodos())
                {
                    Debug.Log("CLAVE CORRECTA");
                    Debug.Log("VÁLIDA HASTA: "+PlayerPrefs.GetString("Logeado"));
                    teclado.SetActive(false);
                    entrada.SetActive(true);
                }
                else
                {
                    Debug.Log("CLAVE INCORRECTA");
                }

            }
            else
            {
                if (cadena.Length <= 7)
                {
                    cadena += letra;
                }
            }
        }
        else
        {
            if (cadena.Length != 0)
            {
                cadena = cadena.Remove(cadena.Length - 1);
            }

        }

        textoEscrito.text = cadena;
    }
    public bool validarTodos()
    {
        foreach (Clave item in claves)
        {
            if (item.valido(cadena))
            {
                return true;
            }
        }
        return false;
    }
    public bool validarLimite()
    {
        DateTime convertida = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
        DateTime fin = Convert.ToDateTime(PlayerPrefs.GetString("Logeado"));
        return convertida < fin;
    }
}
[System.Serializable]
public class Clave
{
    public string nClave;
    public int duracionDias;
    //public string fechaInicio;
    //public string fechaFin;
    /*
    public bool fechaValida(string fecha)
    {
        DateTime convertida= Convert.ToDateTime(fecha);
        DateTime inicio = Convert.ToDateTime(fechaInicio);
        DateTime fin = Convert.ToDateTime(fechaFin);
        Debug.Log("INICIO: "+inicio.ToString("dd/MM/yyyy"));
        Debug.Log("FIN: " + fin.ToString("dd/MM/yyyy"));
        return convertida>=inicio && convertida<=fin;
    }
    */

    /*public bool valido(string claveIngresada)
    {
        Debug.Log("Clave: " + claveIngresada + "  Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        return nClave == claveIngresada && fechaValida(DateTime.Now.ToString("dd/MM/yyyy"));
    }*/
    public bool valido(string claveIngresada)
    {
        Debug.Log("Clave: " + claveIngresada + "  Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        if (nClave == claveIngresada) {

            PlayerPrefs.SetString("Logeado", DateTime.Now.AddDays(duracionDias).ToString("dd/MM/yyyy"));
            Debug.Log("Me loggee");
        }
        return nClave == claveIngresada;
    }
    

};

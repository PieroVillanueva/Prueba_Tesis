using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InicioNivel : MonoBehaviour
{
    [TextArea]
    public string textoInicial;
    public Text T_textoUI;
    public IEnumerator corruntinaAlmacenada;
    public enum efectos {AparecerTexto, CrecerTexto, CrecerTextoX, CrecerTextoY, RotarYCrecerTexto,EscribirTexto }
    public efectos EfectoTextoUI;

    [Header("Tiempos Variables")]
    public float esperaInicio= 2.00f;
    public float esperaFin=4.00f;


    // Start is called before the first frame update
    void Start()
    {
        T_textoUI.text = textoInicial;
        selectorCorrutina();
        
    }

    // Update is called once per frame
    void selectorCorrutina()
    {
        switch (EfectoTextoUI)
        {
            case efectos.AparecerTexto:
                corruntinaAlmacenada = apareceTexto();
                break;
            case efectos.CrecerTexto:
                corruntinaAlmacenada = crecerTexto();
                break;
            case efectos.CrecerTextoX:
                corruntinaAlmacenada = crecerTextoX();
                break;
            case efectos.CrecerTextoY:
                corruntinaAlmacenada = crecerTextoY();
                break;
            case efectos.RotarYCrecerTexto:
                corruntinaAlmacenada = rotarcrecerTexto();
                break;
            case efectos.EscribirTexto:
                corruntinaAlmacenada = escribirTexto();
                break;
        }
        StartCoroutine(corruntinaAlmacenada);
    }
    IEnumerator apareceTexto()
    {
        Color colorInicial = T_textoUI.color;
        colorInicial.a = 0;
        T_textoUI.color = colorInicial;
        yield return new WaitForSeconds(esperaInicio);
        for(float i = 0; i <= 1; i += 0.1f)
        {
            colorInicial.a = i;
            T_textoUI.color = colorInicial;
            yield return new WaitForSeconds(0.02f);
        }
        colorInicial.a = 1;
        T_textoUI.color = colorInicial;

        yield return new WaitForSeconds(esperaFin);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            colorInicial.a = 1-i;
            T_textoUI.color = colorInicial;
            yield return new WaitForSeconds(0.02f);
        }
        colorInicial.a = 0;
        T_textoUI.color = colorInicial;
        gameObject.SetActive(false);
    }

    IEnumerator crecerTexto()
    {
        Vector3 escalaInicial = T_textoUI.transform.localScale;
        escalaInicial.y = escalaInicial.x = 0;
        T_textoUI.transform.localScale = escalaInicial;
        yield return new WaitForSeconds(esperaInicio);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.y = escalaInicial.x = i;
            T_textoUI.transform.localScale = escalaInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.y = escalaInicial.x = 1; 
        T_textoUI.transform.localScale = escalaInicial;

        yield return new WaitForSeconds(esperaFin);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.y = escalaInicial.x = 1 - i;
            T_textoUI.transform.localScale = escalaInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.y = escalaInicial.x = 0;
        T_textoUI.transform.localScale = escalaInicial;
        gameObject.SetActive(false);
    }

    IEnumerator crecerTextoX()
    {
        Vector3 escalaInicial = T_textoUI.transform.localScale;
        escalaInicial.x = 0;
        T_textoUI.transform.localScale = escalaInicial;
        yield return new WaitForSeconds(esperaInicio);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.x = i;
            T_textoUI.transform.localScale = escalaInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.x = 1;
        T_textoUI.transform.localScale = escalaInicial;

        yield return new WaitForSeconds(esperaFin);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.x = 1 - i;
            T_textoUI.transform.localScale = escalaInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.x = 0;
        T_textoUI.transform.localScale = escalaInicial;
        gameObject.SetActive(false);
    }

    IEnumerator crecerTextoY()
    {
        Vector3 escalaInicial = T_textoUI.transform.localScale;
        escalaInicial.y = 0;
        T_textoUI.transform.localScale = escalaInicial;
        yield return new WaitForSeconds(esperaInicio);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.y = i;
            T_textoUI.transform.localScale = escalaInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.y = 1;
        T_textoUI.transform.localScale = escalaInicial;

        yield return new WaitForSeconds(esperaFin);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.y = 1 - i;
            T_textoUI.transform.localScale = escalaInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.y = 0;
        T_textoUI.transform.localScale = escalaInicial;
        gameObject.SetActive(false);
    }

    IEnumerator rotarcrecerTexto()
    {
        Vector3 escalaInicial = T_textoUI.transform.localScale;
        Vector3 rotacionInicial = T_textoUI.transform.localEulerAngles;
        escalaInicial.y = escalaInicial.x = 0;
        T_textoUI.transform.localScale = escalaInicial;
        yield return new WaitForSeconds(esperaInicio);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            escalaInicial.y = escalaInicial.x = i;
            rotacionInicial.z = 360 * i;
            T_textoUI.transform.localScale = escalaInicial;
            T_textoUI.transform.localEulerAngles = rotacionInicial;
            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.y = escalaInicial.x = 1;
        rotacionInicial.z = 360;
        T_textoUI.transform.localScale = escalaInicial;
        T_textoUI.transform.localEulerAngles = rotacionInicial;

        yield return new WaitForSeconds(esperaFin);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            float value = 1 - i;
            escalaInicial.y = escalaInicial.x = value;
            rotacionInicial.z = 360 * value;
            T_textoUI.transform.localScale = escalaInicial;
            T_textoUI.transform.localEulerAngles = rotacionInicial;

            yield return new WaitForSeconds(0.02f);
        }
        escalaInicial.y = escalaInicial.x = 0;
        rotacionInicial.z = 0;
        T_textoUI.transform.localScale = escalaInicial;
        T_textoUI.transform.localEulerAngles = rotacionInicial;

        gameObject.SetActive(false);
    }

    IEnumerator escribirTexto()
    {        
        T_textoUI.text = "";
        yield return new WaitForSeconds(esperaInicio);
        foreach (char c in textoInicial)
        {
            T_textoUI.text += c;
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(esperaFin);
        for (int i = 0; i <= textoInicial.Length-1; i++)
        {
            T_textoUI.text = T_textoUI.text.Remove(T_textoUI.text.Length - 1);
            yield return new WaitForSeconds(0.04f);
        }

        gameObject.SetActive(false);
    }
}

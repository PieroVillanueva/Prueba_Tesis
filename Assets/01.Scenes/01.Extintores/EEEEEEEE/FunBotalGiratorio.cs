using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBotalGiratorio : MonoBehaviour
{
    [Header("Sonido")]
    public AudioSource reproductor;



    [Header("Todo Giro")]
    public bool girando;
    public float anguloActual;
    public float anguloFINAL; //DEBE SER PAR
    public GameObject colisionadorAccidente;

    [Header("Puerta")]
    public GameObject puerta;
    public float actualXPuerta;
    public float minimoX = 0.0f;
    public float limiteX = -1.2f;

    [Header("Escalera")]
    public GameObject escalera;
    public float actualZEscalera;
    public float minimoZ = 1.15f;
    public float limiteZ = 0;


    //[Header("Velocidad")]
    private float tiempo;
    private float angAuxiliar;
    // Start is called before the first frame update


    [Header("Prueba")]
    public int vez;


    void Start()
    {
        tiempo = 0.01f;
        actualXPuerta = puerta.transform.position.x;
        //empezarGirar();
        //StartCoroutine(es());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void llamarAbrirPuerta() => StartCoroutine(moverPuerta(true));
    public void llamarCerrarPuerta() => StartCoroutine(moverPuerta(false));
    IEnumerator moverPuerta(bool abrir)
    {
        if (abrir)
        {
            while (actualXPuerta != limiteX)
            {
                yield return new WaitForSeconds(0.01f);
                actualXPuerta = Mathf.Clamp(actualXPuerta - 0.03f, limiteX, minimoX);
                puerta.transform.localPosition = new Vector3(actualXPuerta, 0, 0);
            }
        }
        else
        {
            while (actualXPuerta != minimoX)
            {
                yield return new WaitForSeconds(0.01f);
                actualXPuerta = Mathf.Clamp(actualXPuerta + 0.03f, limiteX, minimoX);
                puerta.transform.localPosition = new Vector3(actualXPuerta, 0, 0);
            }
        }
       
    }

    public void llamarMoverEscaleraAdelante() => StartCoroutine(moverEscalera(true));
    public void llamarMoverEscaleraAtras() => StartCoroutine(moverEscalera(false));
    IEnumerator moverEscalera(bool paraAdelante)
    {
        
        if (paraAdelante)
        {
            while (actualZEscalera != limiteZ)
            {
                yield return new WaitForSeconds(0.01f);
                actualZEscalera = Mathf.Clamp(actualZEscalera - 0.04f, limiteZ, minimoZ);
                escalera.transform.localPosition = new Vector3(escalera.transform.localPosition.x, escalera.transform.localPosition.y,actualZEscalera);
            }
        }
        else
        {
            while (actualZEscalera != minimoZ)
            {
                yield return new WaitForSeconds(0.01f);
                actualZEscalera = Mathf.Clamp(actualZEscalera + 0.04f, limiteZ, minimoZ);
                escalera.transform.localPosition = new Vector3(escalera.transform.localPosition.x, escalera.transform.localPosition.y, actualZEscalera);
            }
        }

    }




    public void empezarGirar()
    {
        girando = true;
        StartCoroutine(girar());
    }
    public void dejarGirar()
    {
        girando = false;
    }
    IEnumerator es() //testeo
    {
        yield return new WaitForSeconds(10.0f);
        empezarGirar();
    }

    
    IEnumerator girar()
    {
        angAuxiliar = 0;
        llamarCerrarPuerta();
        llamarMoverEscaleraAtras();
        yield return new WaitForSeconds(1.2f);
        colisionadorAccidente.SetActive(true);
        reproductor.Play();
        while (girando)
        {
            yield return new WaitForSeconds(tiempo);

            es298Correcto();

            if (angAuxiliar == 360)
            {
                angAuxiliar = 2.000000f;
            }
            else
            {
                angAuxiliar += 2.000000f;
            }
            transform.localEulerAngles = new Vector3(angAuxiliar,0, 0 );

            anguloActual = transform.localEulerAngles.x;
        }
        //while (anguloActual <= anguloFINAL || anguloFINAL + 2<anguloActual )
        while (!es298Correcto())        
        {
            yield return new WaitForSeconds(tiempo);
            if (angAuxiliar == 360)
            {
                angAuxiliar = 2.000000f;
            }
            else
            {
                angAuxiliar += 2.000000f;
            }
            transform.localEulerAngles = new Vector3(angAuxiliar, 0, 0);

            anguloActual = transform.localEulerAngles.x;
        }
        colisionadorAccidente.SetActive(false);
        reproductor.Pause();
        //Se abre puerta
        yield return new WaitForSeconds(0.3f);
        llamarAbrirPuerta();
        llamarMoverEscaleraAdelante();
    }
    public bool es298Correcto()
    {
        if (anguloActual == 298)
        {
            vez++;
            if (vez == 1)
            {
                return true;
            }
            if (vez == 2)
            {
                vez = 0;
            }
        }
        return false;
    }

}

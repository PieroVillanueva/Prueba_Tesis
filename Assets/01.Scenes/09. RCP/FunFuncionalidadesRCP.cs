using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FunFuncionalidadesRCP : MonoBehaviour
{
    public bool primeraHombros;
    public bool primeraAyuda;
    public bool primeraEmergencia;
    public bool primeraMoverACamilla;
    public bool posibleLlamada;


    public AudioSource reproductor;
    public AudioClip sonidoAyuda;
    public AudioClip sonidoEmergencia;

    public GameObject manoDerecha;
    public GameObject manoIzquierda;
    private GameObject der;
    private GameObject iz;

    public GameObject colliderHombro;

    public GameObject[] espaciosRespiracion;

    public GameObject[] espacioManosCompresion;

    public Manager_RCP manejoRCP;
    public GameObject nariz;
    public GameObject cuello;

    public int presionesRespirador;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(obtenerModeloMano());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void presionarRespirador()
    {
        presionesRespirador++;
        Debug.Log("Presiones"+presionesRespirador);
    }

    IEnumerator obtenerModeloMano()
    {
        yield return new WaitForSecondsRealtime(1.00f);
        der = manoDerecha.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
        iz = manoIzquierda.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
    }
    //===============================================================
    public void activarMoverHombros()
    {
        if (!primeraHombros)
        {
            manejoRCP.CumplirTarea(1);
            primeraHombros = true;
        }
    }
    public void activarHombros(bool activar)
    {
        if (manejoRCP.actualTarea == 2 && !activar)
        {
            colliderHombro.transform.position += new Vector3(0, 10, 0);
            colliderHombro.SetActive(false);
        }
    }

    public void moverACamilla()
    {
        if (!primeraMoverACamilla)
        {
            manejoRCP.CumplirTarea(0);
            primeraMoverACamilla = true;
        }
    }
    public void solicitarEmergencia()
    {
        if (!primeraEmergencia && posibleLlamada)
        {
            reproductor.PlayOneShot(sonidoEmergencia);
            primeraEmergencia = true;
            StartCoroutine(cumplirEmergencia());
        }
    }
    IEnumerator cumplirEmergencia()
    {
        yield return new WaitForSecondsRealtime(9.00f);
        manejoRCP.CumplirTarea(3);
    }


    public void desactivarEspacioCabeza()
    {
        if (manejoRCP.actualTarea >= 5)
        {
            espaciosRespiracion[0].transform.position += new Vector3(0f, 20.0f, 0f);
            StartCoroutine(esperarParaDesactivar(espaciosRespiracion[0]));
        }
    }
    public void desactivarEspacioMenton()
    {
        if (manejoRCP.actualTarea >= 5)
        {
            espaciosRespiracion[1].transform.position += new Vector3(0f, 20.0f, 0f);
            StartCoroutine(esperarParaDesactivar(espaciosRespiracion[1]));

        }
    }

    //===============================================================
    public void pedirAyuda()
    {
        if (!primeraAyuda)
        {
            reproductor.PlayOneShot(sonidoAyuda);
            manejoRCP.CumplirTarea(2);
            primeraAyuda = true;
        }
    }
 
   
    public void ocultarManoDerecha(bool ocultar)
    {
        if (ocultar)
        {
            der.SetActive(false);
        }
        else
        {
            der.SetActive(true);
        }
    }
    public void ocultarManoIzquierda(bool ocultar)
    {
        if (ocultar)
        {
            iz.SetActive(false);
        }
        else
        {
            iz.SetActive(true);
        }
    }
  
    public void activarEspacioIzquierdaCompresion(bool activar)
    {
        if ((manejoRCP.actualTarea == 6|| manejoRCP.actualTarea == 8 || manejoRCP.actualTarea == 10 || manejoRCP.actualTarea == 12 || manejoRCP.actualTarea == 14) && !activar)
        {
            espacioManosCompresion[0].transform.position += new Vector3(0f, 20.0f, 0f);
            StartCoroutine(esperarParaDesactivar(espaciosRespiracion[0]));
        }
        if(activar)
        {
            espacioManosCompresion[0].transform.position += new Vector3(0f, -20.0f, 0f);
            espaciosRespiracion[0].SetActive(true);
        }
    }
    public void activarEspacioDerechaCompresion(bool activar)
    {
        if ((manejoRCP.actualTarea == 6 || manejoRCP.actualTarea == 8 || manejoRCP.actualTarea == 10 || manejoRCP.actualTarea == 12 || manejoRCP.actualTarea == 14) && !activar)
        {
            espacioManosCompresion[1].transform.position += new Vector3(0f, 20.0f, 0f);
            StartCoroutine(esperarParaDesactivar(espaciosRespiracion[1]));
        }
        if (activar)
        {
            espacioManosCompresion[1].transform.position += new Vector3(0f, -20.0f, 0f);
            espaciosRespiracion[1].SetActive(true);
        }
    }
    public void activarNariz(bool activar)
    {
        if ((manejoRCP.actualTarea == 7||manejoRCP.actualTarea == 9 || manejoRCP.actualTarea == 11 || manejoRCP.actualTarea == 13 || manejoRCP.actualTarea == 15) && !activar)
        {
            nariz.transform.position += new Vector3(0f, 20.0f, 0f);
            StartCoroutine(esperarParaDesactivar(nariz));
        }
        if (activar)
        {
            nariz.transform.position += new Vector3(0f, -20.0f, 0f);
            nariz.SetActive(true);
        }
    }
    public void activarCuello(bool activar)
    {
        if ((manejoRCP.actualTarea == 3 || manejoRCP.actualTarea == 16 && !activar))
        {
            cuello.transform.position += new Vector3(0f, 20.0f, 0f);
            StartCoroutine(esperarParaDesactivar(cuello));
        }
        if (activar)
        {
            cuello.transform.position += new Vector3(0f, -20.0f, 0f);
            cuello.SetActive(true);
        }
    }

    IEnumerator esperarParaDesactivar(GameObject desactiva)
    {
        yield return new WaitForSeconds(2.00f);
        desactiva.SetActive(false);
    }

}

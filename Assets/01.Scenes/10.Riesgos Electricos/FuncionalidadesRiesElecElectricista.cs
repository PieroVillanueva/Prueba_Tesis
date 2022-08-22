using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionalidadesRiesElecElectricista : MonoBehaviour
{
    // Start is called before the first frame update
    public Material materialGuantesDielectrico;
    public Material materialManosInicial;
    public HandPresence manoDerecha;
    public HandPresence manoIzquierda;
    public bool posibleAbrirPrincipal;
    public GameObject puerta;
    public GameObject eje;
    public GameObject electrificante;
    void Start()
    {
        StartCoroutine(obtenerModeloMano());
    }
    IEnumerator obtenerModeloMano()
    {
        yield return new WaitForSecondsRealtime(1.00f);
        manoIzquierda = GameObject.Find("Left hand").GetComponentInChildren<HandPresence>();
        manoDerecha = GameObject.Find("Right hand").GetComponentInChildren<HandPresence>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void girarPuertaPanelPrincipal()
    {
        if (posibleAbrirPrincipal)
        {
            posibleAbrirPrincipal = false;
            puerta.transform.RotateAround(eje.transform.position, new Vector3(0, -1, 0), 180);
            electrificante.SetActive(true);
        }
    }
    public void activarGameObject(GameObject objeto)
    {
        StartCoroutine("activarObjeto", objeto);
    }
    IEnumerator activarObjeto(GameObject objeto)
    {
        yield return new WaitForSeconds(0.1f);
        objeto.SetActive(true);
    }
    public void desactivarGameObject(GameObject objeto)
    {
        StartCoroutine("desactivarObjeto", objeto);
    }
    IEnumerator desactivarObjeto(GameObject objeto)
    {
        yield return new WaitForSeconds(1f);
        objeto.SetActive(false);
    }

    public void llamarActivarEspacioGuantes(GameObject espacio)
    {
        StartCoroutine("activarEspacioGuantes", espacio);
    }
    IEnumerator activarEspacioGuantes(GameObject espacio)
    {
        yield return new WaitForSeconds(0.01f);
        espacio.SetActive(true);
        yield return new WaitForSeconds(2f);
        espacio.SetActive(false);
    }
    public void colocarMaterialGuantesManos()
    {
        manoIzquierda.skin.material = materialGuantesDielectrico;
        manoDerecha.skin.material = materialGuantesDielectrico;
        // Debug.Log("GAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
    public void quitarMaterialGuantesManos()
    {
        manoIzquierda.skin.material = materialManosInicial;
        manoDerecha.skin.material = materialManosInicial;
    }

    public void enviarAlInfinito(GameObject objeto)
    {
        objeto.transform.position -= new Vector3(0f, 20.0f, 0f);
        StartCoroutine("desactivarObjeto", objeto);
    }
}

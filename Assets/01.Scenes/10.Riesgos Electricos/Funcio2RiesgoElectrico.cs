using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcio2RiesgoElectrico : MonoBehaviour
{
    public GameObject puerta;
    public GameObject eje;
    public bool posibleAbrirPrincipal;
    public Material materialGuantesDielectrico;
    public Material materialManosInicial;
    public HandPresence manoDerecha;
    public HandPresence manoIzquierda;

    public GameObject electrificante;

    public GameObject parteBrazoIzquierda;
    public GameObject parteBrazoDerecha;
    void Start()
    {
        StartCoroutine(obtenerModeloMano());
    }
    IEnumerator obtenerModeloMano()
    {
        yield return new WaitForSecondsRealtime(1.00f);
        manoIzquierda = GameObject.Find("Left hand").GetComponentInChildren<HandPresence>(); 
        manoDerecha = GameObject.Find("Right hand").GetComponentInChildren<HandPresence>();

        parteBrazoIzquierda = GameObject.Find("ParteBrazoIzquierda");
        parteBrazoDerecha = GameObject.Find("ParteBrazoDerecha");
        

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
        activarPartesManos();
       // Debug.Log("GAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
    public void quitarMaterialGuantesManos()
    {
        desactivarPartesManos();
        manoIzquierda.skin.material = materialManosInicial;
        manoDerecha.skin.material = materialManosInicial;
    }

    public void enviarAlInfinito(GameObject objeto)
    {
        objeto.transform.position -= new Vector3(0f, 20.0f, 0f);
        StartCoroutine("desactivarObjeto", objeto);
    }
    public void activarPartesManos()
    {
        parteBrazoDerecha.GetComponent<MeshRenderer>().enabled = true;
        parteBrazoIzquierda.GetComponent<MeshRenderer>().enabled = true;
    }
    public void desactivarPartesManos()
    {
        parteBrazoDerecha.GetComponent<MeshRenderer>().enabled = false;
        parteBrazoIzquierda.GetComponent<MeshRenderer>().enabled = false;
    }
    public void resaltarObjeto(GameObject objeto)
    {
        if (objeto.GetComponent<MeshRenderer>() != null)
        {
            Material mat = objeto.GetComponent<MeshRenderer>().material;
            if (mat != null)
            {
                //mat.SetFloat("_UseColorMap", 0);
                mat.SetFloat("_EMISSION", 1);
            }
        }
        else
        {
            MeshRenderer[] mesh = objeto.GetComponentsInChildren<MeshRenderer>();
            Material[] materiales = new Material[mesh.Length];
            for (int i = 0; i < mesh.Length; i++)
            {
                materiales[i] = mesh[i].material;
            }
            for (int i = 0; i < materiales.Length; i++)
            {
                //materiales[i].SetFloat("_UseColorMap", 0);
                materiales[i].SetFloat("_EMISSION", 1);
            }
        }
    }
    public void quitarResaltarObjeto(GameObject objeto)
    {
        if (objeto.GetComponent<MeshRenderer>() != null)
        {
            Material mat = objeto.GetComponent<MeshRenderer>().material;
            if (mat != null)
            {
                //mat.SetFloat("_UseColorMap", 1);
                mat.SetFloat("_EMISSION", 0);
            }
        }
        else
        {
            MeshRenderer[] mesh = objeto.GetComponentsInChildren<MeshRenderer>();
            Material[] materiales = new Material[mesh.Length];
            for (int i = 0; i < mesh.Length; i++)
            {
                materiales[i] = mesh[i].material;
            }
            for (int i = 0; i < materiales.Length; i++)
            {
                //materiales[i].SetFloat("_UseColorMap", 1);
                materiales[i].SetFloat("_EMISSION", 0);
            }
        }
    }
}

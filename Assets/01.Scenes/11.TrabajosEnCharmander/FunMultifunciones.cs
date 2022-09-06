using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunMultifunciones : MonoBehaviour
{
    public GameObject ManoDerecha;
    public GameObject ManoIzquierda;
    public HandPresence presenciaDerecha;
    public HandPresence presenciaIzquierda;

    public GameObject parteBrazoIzquierda;
    public GameObject parteBrazoDerecha;

    public Material materialGuantesPuestos;
    public Material materialManosInicial;
    // Start is called before the first frame update
    public virtual void Start()
    {
        StartCoroutine(obtenerModeloMano());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator obtenerModeloMano()
    {
        yield return new WaitForSecondsRealtime(1.00f);
        ManoDerecha = GameObject.Find("Right hand").GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
        ManoIzquierda = GameObject.Find("Left hand").GetComponentInChildren<SkinnedMeshRenderer>().gameObject;

        presenciaIzquierda = GameObject.Find("Left hand").GetComponentInChildren<HandPresence>();
        presenciaDerecha = GameObject.Find("Right hand").GetComponentInChildren<HandPresence>();
        parteBrazoIzquierda = GameObject.Find("ParteBrazoIzquierda");
        parteBrazoDerecha = GameObject.Find("ParteBrazoDerecha");
        //colocarMaterialGuantesManos();
    }
    public void ocultarManoDerecha(bool ocultar)
    {
        ManoDerecha.SetActive(!ocultar);        
    }
    public void ocultarManoIzquierda(bool ocultar)
    {
        ManoIzquierda.SetActive(!ocultar);       
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
    public void llamarActivarEspacioMomentaneo(GameObject espacio)
    {
        StartCoroutine("activarEspacioMomentaneo", espacio);
    }
    IEnumerator activarEspacioMomentaneo(GameObject espacio)
    {
        yield return new WaitForSeconds(0.01f);
        espacio.SetActive(true);
        yield return new WaitForSeconds(2f);
        espacio.SetActive(false);
    }
    public void enviarAlInfinito(GameObject objeto)
    {
        objeto.transform.position -= new Vector3(0f, 20.0f, 0f);
        StartCoroutine("desactivarObjeto", objeto);
    }
    public void resaltarObjeto(GameObject objeto)
    {
        if (objeto.GetComponent<MeshRenderer>() != null)
        {
            Material mat = objeto.GetComponent<MeshRenderer>().material;
            if (mat != null)
            {
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
                materiales[i].SetFloat("_EMISSION", 0);
            }
        }
    }
    public void colocarMaterialGuantesManos()
    {
        presenciaIzquierda.skin.material = materialGuantesPuestos;
        presenciaDerecha.skin.material = materialGuantesPuestos;
        activarPartesManos();
    }
    public void colocarMaterialGuantesManosSinPartes()
    {
        presenciaIzquierda.skin.material = materialGuantesPuestos;
        presenciaDerecha.skin.material = materialGuantesPuestos;
    }
    public void quitarMaterialGuantesManos()
    {
        desactivarPartesManos();
        presenciaIzquierda.skin.material = materialManosInicial;
        presenciaDerecha.skin.material = materialManosInicial;
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



}

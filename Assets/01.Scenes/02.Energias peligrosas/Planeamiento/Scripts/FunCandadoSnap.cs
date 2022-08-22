using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunCandadoSnap : MonoBehaviour
{
    public GameObject panel;
    public GameObject candado;
    public AudioClip clip;
    public bool PrimeraVez;
    public Lvl_Manager lvl_manager;
    // Start is called before the first frame update
    void Start()
    {
        PrimeraVez = true;
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesactivarColision()
    {
        if (gameObject.activeInHierarchy) StartCoroutine(cambioLayer(13));//NO GRAP

    }
    public void ActivarColision()
    {
        if (gameObject.activeInHierarchy) StartCoroutine(cambioLayer(9));// GRAP

    }
    public void Colocado()
    {
        panel.GetComponent<PanelFun>().candadoColocado = true;
        panel.GetComponent<PanelFun>().tresColocados = true;
        GetComponent<AudioSource>().PlayOneShot(clip);
        if (gameObject.activeInHierarchy) StartCoroutine(cambioLayer(15));// GRAP NO SNAP
        if (PrimeraVez)
        {
            PrimeraVez = false;
            lvl_manager.CumplirTarea(5);
        }


    }
    public void Sacar()
    {
        panel.GetComponent<PanelFun>().candadoColocado = false;
        panel.GetComponent<PanelFun>().tresColocados = false;
        //panel.GetComponent<PanelFun>().snapBloqueo.GetComponent<FunBloqueoSnap>().ActivarColision();
        GetComponent<AudioSource>().PlayOneShot(clip);
        if (gameObject.activeInHierarchy) StartCoroutine(cambioLayer(9));// GRAP
       


    }

    IEnumerator cambioLayer(int layer)
    {
        yield return new WaitForSeconds(0.2f);
        candado.layer = layer;
    }
}

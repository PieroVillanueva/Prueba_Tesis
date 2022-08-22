using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBloqueoSnap : MonoBehaviour
{
    public GameObject panel;
    public GameObject bloqueo;
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
        panel.GetComponent<PanelFun>().bloqueoColocado = true;
        GetComponent<AudioSource>().PlayOneShot(clip);
        if (gameObject.activeInHierarchy) StartCoroutine(cambioLayer(15));// GRAP NO SNAP

        if (PrimeraVez)
        {
            PrimeraVez = false;
            lvl_manager.CumplirTarea(3);
        }
    }
    public void Sacar()
    {
        panel.GetComponent<PanelFun>().bloqueoColocado = false;

        GetComponent<AudioSource>().PlayOneShot(clip);
        if (gameObject.activeInHierarchy) StartCoroutine(cambioLayer(9));// GRAP

    }

    IEnumerator cambioLayer(int layer)
    {
        yield return new WaitForSeconds(0.2f);
        bloqueo.layer = layer;        
    }
}

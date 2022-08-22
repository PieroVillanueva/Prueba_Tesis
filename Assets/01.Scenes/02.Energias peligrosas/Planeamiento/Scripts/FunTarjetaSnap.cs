using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunTarjetaSnap : MonoBehaviour
{
    public GameObject panel;
    public GameObject tarjeta;
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
        tarjeta.gameObject.layer = 13;//NO GRAP
    }
    public void ActivarColision()
    {
        tarjeta.gameObject.layer = 9;// GRAP
    }
    public void Colocado()// al colocar la tarjeta ya no se puede agarrrar y cuple la tarea 4 
    {
        panel.GetComponent<PanelFun>().tarjetaColocada = true;
        
        panel.GetComponent<PanelFun>().snapBloqueo.GetComponent<FunBloqueoSnap>().DesactivarColision();
        GetComponent<AudioSource>().PlayOneShot(clip);
        tarjeta.gameObject.layer = 13; //  NO GRAP


        if (PrimeraVez)
        {
            PrimeraVez = false;
            lvl_manager.CumplirTarea(4);
        }
    }
    public void Sacar()
    {
        /* POSIBLE USO PARA JOSUE
        panel.GetComponent<PanelFun>().tarjetaColocada = false;
        panel.GetComponent<PanelFun>().snapCandado.GetComponent<FunCandadoSnap>().ActivarColision();
        GetComponent<AudioSource>().PlayOneShot(clip);
        tarjeta.gameObject.layer = 9;// GRAP*/
    }
}

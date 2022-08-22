using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunGanchoSnap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject cubo;
    public GameObject esfera;
    public bool colocado;
    public AudioClip clip;
    public bool PrimeraVez;
    public Lvl_Manager lvl_manager;
    public int Turno=0;
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();

    }
    void Start()
    {
        cubo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (colocado)
        {
            esfera.gameObject.SetActive(false);
            cubo.gameObject.SetActive(true);

        }
        else
        {
            esfera.gameObject.SetActive(true);
            cubo.gameObject.SetActive(false);
        }
    }
    public void Enganchado()
    {
        colocado = true;
        if (Turno == 1) { // En caso sea turno se activa el modelo correcto y se desativa el incorrecto y se cumple la tarea 8
            panel.GetComponent<PanelFun>().enganchado = true;
            GetComponent<AudioSource>().PlayOneShot(clip);
           
            if (!PrimeraVez)
            {
                PrimeraVez = true;
                lvl_manager.CumplirTarea(8);
            }
        }
    }
    public void DesEnganchado()
    {
        colocado = false;//Se desactiva el modelo colocado y activa el no colocado
        
    } 
    
}

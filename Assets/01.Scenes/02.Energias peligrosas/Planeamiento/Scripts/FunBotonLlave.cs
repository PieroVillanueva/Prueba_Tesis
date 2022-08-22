using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBotonLlave : MonoBehaviour
{
    public GameObject panel;
    public AudioClip clip;
    public bool PrimeraVez;
    public Lvl_Manager lvl_manager;
    public int Turno = 0;
    public GameObject palanca;
    void Start()
    {
        PrimeraVez = true;
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrenderOApagar()
    {
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player")&&Turno==1)//Activa la tarea2 en caso se toque
        {
            panel.GetComponent<PanelFun>().llaveApagada = !panel.GetComponent<PanelFun>().llaveApagada;
            Debug.Log("Llave Cambiada a " + panel.GetComponent<PanelFun>().llaveApagada);
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
            if (panel.GetComponent<PanelFun>().llaveApagada && panel.GetComponent<PanelFun>().maquinaApagada)
            {
                panel.GetComponent<PanelFun>().IniciarReduccion();
               
                lvl_manager.CumplirTarea(2);
            }
            Turno=0;
            palanca.gameObject.transform.Rotate(45,0, 0);
        }
    }
}

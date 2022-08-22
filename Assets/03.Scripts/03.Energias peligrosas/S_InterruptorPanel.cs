using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InterruptorPanel : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip clip;

    public GameObject m_switch;
    public bool switchActivo;

    public GameObject Obj_fases;
    public GameObject Obj_switchs;

    public S_PanelConclusion panelElectrico;

    public MeshRenderer mesh_switch;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && switchActivo==true)
        {
            EncenderMaquina();
        }
    }

    void EncenderMaquina()
    {
        panelElectrico.panelEncendido = !panelElectrico.panelEncendido;
        panelElectrico.EncendidoPanel(panelElectrico.panelEncendido);
        
        electrificarPartes(panelElectrico.panelEncendido);
        int rotacionX = panelElectrico.panelEncendido == true ? -45 : 45;
        mesh_switch.material.SetFloat("_EMISSION", 0);
        m_switch.transform.Rotate(rotacionX, 0, 0);
        
        audiomanager.PlayOneShot(clip);
    }
    public void ActivarSwitch(bool value)
    {
        //bloqueado
        switchActivo = value;
    }

    void electrificarPartes(bool active)
    {
        Obj_fases.SetActive(active);
        Obj_switchs.SetActive(active);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoPanelRLA : MonoBehaviour
{
    public RLA_Manager manager;
    public GameObject boton;
    public GameObject nuevoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AceptarAviso()
    {
        manager.CumplirTarea(4);
        boton.SetActive(false);
        nuevoPanel.SetActive(true);
        gameObject.SetActive(false);
        
    }

  
}

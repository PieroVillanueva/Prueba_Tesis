using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CodigoBarrasRLA : MonoBehaviour
{
    public int numero;
    public RLA_Manager manager;
    [Header("Scaner")]
    public int cantidad;
    public string pais;
    public string hora;
    public string encargado;
    public bool colocar;
    public bool colocado;
    public Text[] text;
    public Image panel;
    public bool primera;
    [Header("-------------------")]
    [Header("Etiquetadora")]
    public MeshRenderer codigoBarras;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (numero)
        {
            case 0:
                if (other.CompareTag("sensor"))
                {
                    if (!primera)
                    {
                        hora = System.DateTime.Now.ToString();
                        text[0].text = "Cantidad: " + cantidad;
                        text[1].text = "País: " + pais;
                        text[2].text = "Hora: " + hora;
                        text[3].text = "Encargado: " + encargado;
                        primera = true;
                        manager.CumplirTarea(34);
                    }      
                }
                break;
            case 1:
                if (other.CompareTag("ToggleLinterna"))
                {
                    manager.CumplirTarea(33);
                    codigoBarras.enabled = true;
                    gameObject.SetActive(false);
                }
                break;
        }
        
    }

    
}

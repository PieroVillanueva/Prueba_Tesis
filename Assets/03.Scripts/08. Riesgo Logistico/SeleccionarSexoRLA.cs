using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarSexoRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hombre;
    public float pesoMaxSoportado;
    public GameObject[] objs;
    public RLA_Manager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscogerGenero(bool valor)
    {
        hombre = valor;
        pesoMaxSoportado = hombre ? 25f : 20f;
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(false);
        }
        manager.CumplirTarea(0);
    }
}

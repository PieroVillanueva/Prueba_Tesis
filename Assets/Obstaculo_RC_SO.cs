using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo_RC_SO : MonoBehaviour
{
    // Start is called before the first frame update\
    public enum TipoDeObstaculos { archivador, cable, agua, cascara }
    [Header("Fases")]
    public TipoDeObstaculos tipoDeObstaculo;
    public bool enUso;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InvocarObstaculo()
    {
        Debug.Log("Invocar obstaculo");
    }

    public virtual void ResetObstaculo()
    {
        Debug.Log("Reset obstaculo");
    }

    public bool ComprobarTipoObstaculo(string tipo) => tipoDeObstaculo.ToString().Equals(tipo);
}

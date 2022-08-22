using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSO : MonoBehaviour
{
    public ManagerOyL_SO manager;
    public enum TipoObstaculo { documento, basura, sonido, luz }
    public TipoObstaculo tipoDeObstaculo;
    public bool enUso;

    // Start is called before the first frame update
    void Start()
    {
        //ObtenerPosicionInicial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ColocarPanel(bool estado)
    {
        Debug.Log("Panel colocado");
    }

    public virtual void InvocarObstaculo()
    {
        Debug.Log("Invocar obstaculo");
    }

    public virtual void ObtenerPosicionInicial()
    {
        Debug.Log("Obtener posicion inicial");
    }

    public virtual void ReiniciarObstaculo()
    {
        Debug.Log("Reiniciar posicion");
    }

    public virtual void EstadoFresnel(int indice)
    {
        Debug.Log("Fresnel colocado");
    }


    public bool ComprobarTipoObstaculo(string tipo) => tipoDeObstaculo.ToString().Equals(tipo);

    

}

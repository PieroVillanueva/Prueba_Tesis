using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetreroFuncion : MonoBehaviour
{
    public GameObject ObjetoSeguido;
    public Vector3 offset;
    public Camera cameraMain;
    public bool usoEspecial;
    public bool terminar;
    public float velocidad;
    public float distancia;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = ObjetoSeguido.transform.position + offset+ new Vector3(0,Mathf.PingPong(Time.time*velocidad,distancia),0);
        transform.LookAt(cameraMain.transform.position);
    }
    public void Mostrar()
    {
        if (usoEspecial)
        {
            gameObject.SetActive(true);
        }
        else
        {
            if (!terminar)
            {
                gameObject.SetActive(true);
            }
        }
        
    }
    public void Ocultar()
    {
        this.gameObject.SetActive(false);
    }

    public void Terminar(bool valor)
    {
        terminar = valor;
    }
}

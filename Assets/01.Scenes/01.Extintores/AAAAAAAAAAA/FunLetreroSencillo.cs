using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunLetreroSencillo : MonoBehaviour
{
    public GameObject ObjetoSeguido;
    public Vector3 offset;
    public Camera cameraMain;

    public float velocidad;
    public float distancia;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObjetoSeguido != null)
        {
            transform.position = ObjetoSeguido.transform.position + offset + new Vector3(0, Mathf.PingPong(Time.time * velocidad, distancia), 0);
            transform.LookAt(cameraMain.transform.position);
        }
    }
    public void cambiarObjetivo(GameObject nuevoSeguido)
    {
        ObjetoSeguido = nuevoSeguido;
    }
}

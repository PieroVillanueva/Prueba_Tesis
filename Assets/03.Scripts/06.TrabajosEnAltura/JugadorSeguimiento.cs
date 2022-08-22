using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorSeguimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public bool enganchado;
    public Transform target;
    public GameObject seguidor;
    public float offset;
    public Vector3 movimiento;
    public Transform deslizador;
    public Transform nuevaPosicion;
    Vector3 posI;
    Vector3 rotI;

    public float Pos_Max, Pos_Min;
    void Start()
    {
        posI = deslizador.localPosition;
        rotI = deslizador.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (enganchado)
        {
            deslizador.position = nuevaPosicion.position;
            deslizador.eulerAngles = nuevaPosicion.eulerAngles;
            movimiento.x = seguidor.transform.position.x;
            movimiento.y = seguidor.transform.position.y;
            movimiento.z = target.transform.position.z + offset;
            seguidor.transform.position = movimiento;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, Pos_Min, Pos_Max));
        }
        
    }

    public void PosicionInicio()
    {
        deslizador.localPosition = posI;
        deslizador.localEulerAngles = rotI;
    }
}

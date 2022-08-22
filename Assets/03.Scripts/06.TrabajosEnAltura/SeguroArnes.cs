using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguroArnes : MonoBehaviour
{
    // Start is called before the first frame update
    //public bool mover = true;
    public GameObject seguro;
    //public GameObject colocarGancho;
    //public GameObject posicionGancho;
    public GameObject copia;
    public GameObject posicion;
    public GameObject mosqueton;
    public GameObject padre;
    public Movement movement;
    public bool defectuoso;
    public Vector3 offset;
    public Vector3 offsetAuxiliar;
    public Vector3 rotacion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            gancho.transform.localPosition = padre.transform.localPosition;
        }*/
    }

    public void NoGravedad()
    {
        movement.Gravedad(0f);
        movement.fallingSpeed = 0;
        Debug.Log(movement.fallingSpeed);

    }

    public void Gravedad()
    {
        movement.Gravedad(-9.81f);
        Debug.Log(movement.fallingSpeed);
    }

    public void NoSpeed()
    {
        movement.Velocidad(0f);
    }

    public void Speed()
    {
        movement.Velocidad(1.5f);
    }
    public void Emparentar()
    {
        seguro.transform.parent = posicion.transform;
        seguro.transform.eulerAngles = posicion.transform.eulerAngles;
        /*offset.y = posicion.transform.position.y;
        offset.x = seguro.transform.position.x;
        offset.z = seguro.transform.position.z;*/
        //snapGancho.transform.parent = seguro.transform;
        offset = posicion.transform.position;
        seguro.transform.position = offset + offsetAuxiliar;
        
        //seguro.transform.LookAt(posicion.transform.position);

    }

    public void Desemparentar()
    {
        seguro.transform.parent = null;
        //snapGancho.transform.parent = null;
        mosqueton.transform.localPosition = posicion.transform.localPosition;
    }

    public void Accidente()
    {
        seguro.transform.parent = null;
        mosqueton.SetActive(false);
        copia.SetActive(true);
        //snapGancho.transform.parent = null;
        //posicionGancho.SetActive(true);
        //listaObjs1[1].transform.parent = seguro.transform;
        //listaObjs1[1].transform.position = posicionGancho.transform.position;
    }

    public void Reset()
    {
        mosqueton.SetActive(true);
        copia.SetActive(false);
    }
    
}

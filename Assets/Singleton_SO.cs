using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_SO : MonoBehaviour
{
    public static Singleton_SO instance;
    private Vector3 posicion;
    private Vector3 rotacion;
    public bool primerInicio;
    public bool otroEjercicio;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignarPosicionPlayer(Transform pos)
    {
        posicion = pos.position;
        rotacion = pos.eulerAngles;
    }

    public void PosicionPlayer(GameObject player)
    {
        player.transform.localPosition = posicion;
        player.transform.localEulerAngles = rotacion;
        otroEjercicio = false;
    }
}

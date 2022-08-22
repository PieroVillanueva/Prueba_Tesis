using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoParaSnapNuevo : MonoBehaviour
{
    public bool agarrado;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Soltar()
    {
        agarrado = false;
    }
    public void Agarrar()
    {
        agarrado = true;
    }

}

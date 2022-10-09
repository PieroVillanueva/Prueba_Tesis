using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBotalGiratorio : MonoBehaviour
{
    [Header("Todo Giro")]
    public bool girando;
    public float anguloActual;
    public float anguloFINAL; //DEBE SER PAR
    public GameObject colisionadorAccidente;

    //[Header("Velocidad")]
    private float tiempo;
    private float angAuxiliar;
    // Start is called before the first frame update


    [Header("Prueba")]
    public int vez;


    void Start()
    {
        tiempo = 0.01f;
        empezarGirar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void empezarGirar() {
        girando = true;
        StartCoroutine(girar());
    }
    public void dejarGirar()
    {
        girando = false;
    }
    //IEnumerator girar()
    //{
    //    colisionadorAccidente.SetActive(true);
    //    while (girando)
    //    {
    //        yield return new WaitForSeconds(tiempo);
    //        if (angAuxiliar == 360)
    //        {
    //            angAuxiliar = 2;
    //        }
    //        else
    //        {
    //            angAuxiliar += 2;
    //        }
    //        transform.localEulerAngles = new Vector3(0, -90, angAuxiliar);

    //        anguloActual = transform.eulerAngles.z;
    //    }
    //    while (anguloActual <= anguloFINAL - 1 || anguloActual >= anguloFINAL + 1)
    //    {
    //        yield return new WaitForSeconds(tiempo);
    //        if (angAuxiliar == 360)
    //        {
    //            angAuxiliar = 2;
    //        }
    //        else
    //        {
    //            angAuxiliar += 2;
    //        }
    //        transform.localEulerAngles = new Vector3(0, -90, angAuxiliar);

    //        anguloActual = transform.eulerAngles.z;
    //    }
    //    colisionadorAccidente.SetActive(false);
    //}
    IEnumerator girar()
    {
        colisionadorAccidente.SetActive(true);
        while (girando)
        {
            yield return new WaitForSeconds(tiempo);

            es298Correcto();

            if (angAuxiliar == 360)
            {
                angAuxiliar = 2.000000f;
            }
            else
            {
                angAuxiliar += 2.000000f;
            }
            transform.localEulerAngles = new Vector3(angAuxiliar,0, 0 );

            anguloActual = transform.localEulerAngles.x;
        }
        //while (anguloActual <= anguloFINAL || anguloFINAL + 2<anguloActual )       
        while (!es298Correcto())        
        {
            yield return new WaitForSeconds(tiempo);
            if (angAuxiliar == 360)
            {
                angAuxiliar = 2.000000f;
            }
            else
            {
                angAuxiliar += 2.000000f;
            }
            transform.localEulerAngles = new Vector3(angAuxiliar, 0, 0);

            anguloActual = transform.eulerAngles.x;
        }
        colisionadorAccidente.SetActive(false);
    }
    public bool es298Correcto()
    {
        if (anguloActual == 298)
        {
            vez++;
            if (vez == 1)
            {
                return true;
            }
            if (vez == 2)
            {
                vez = 0;
            }
        }
        return false;
    }

}

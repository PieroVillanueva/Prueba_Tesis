using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorSO : MonoBehaviour
{
    [Header ("Riesgo de caida")]
    public AudioSource audioS;
    public Transform puerta1;
    public Transform puerta2;
    private Vector3 aux1;
    private Vector3 aux2;
    public float distancia1;
    public float distancia2;
    private float distanciaAux1;
    private float distanciaAux2;
    public bool abrir;
    public bool iniciar;

    [Header("Lobby")]
    private bool cerrado = true;
    private bool enUso = false;
    void Start()
    {
        distanciaAux1 = puerta1.localPosition.x;
        distanciaAux2 = puerta2.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidarPosicion()
    {
        if (abrir)
        {
            iniciar = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            abrir = true;
            StartCoroutine(AbrirAscensor());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            abrir = false;
            StartCoroutine(CerrarAscensor());
        }
    }

    
    IEnumerator AbrirAscensor()
    {
        while (!iniciar)
        {
            yield return new WaitForSeconds(0.01f);
        }

        audioS.Play();
        while (abrir && (puerta1.localPosition.x <= distancia1 && puerta2.localPosition.x >= distancia2))
        {
            aux1 = puerta1.localPosition;
            aux1.x += 1 * Time.deltaTime;
            puerta1.localPosition = aux1;

            aux2 = puerta2.localPosition;
            aux2.x -= 1 * Time.deltaTime;
            puerta2.localPosition = aux2;

            yield return new WaitForSeconds(0.02f);
        }
    }

    public void Cerrar()
    {
        abrir = false;
        StartCoroutine(CerrarAscensor());
    }
    IEnumerator CerrarAscensor()
    {
        while (!abrir && (puerta1.localPosition.x >= distanciaAux1 && puerta2.localPosition.x <= distanciaAux2))
        {
            aux1 = puerta1.localPosition;
            aux1.x -= 1 * Time.deltaTime;
            puerta1.localPosition = aux1;

            aux2 = puerta2.localPosition;
            aux2.x += 1 * Time.deltaTime;
            puerta2.localPosition = aux2;

            yield return new WaitForSeconds(0.02f);
        }
        iniciar = false;
    }

    //Lobby

    public void CambiarEstadoAscensor(bool estado)
    {
        cerrado = estado;
    }

    public void OpenAscensor()
    {
        if (cerrado)
        {
            if (!enUso)
            {
                enUso = true;
                StartCoroutine(AbrirElevador());
                Debug.Log("entro");

            }
        }

    }

    public void CloseAscensor()
    {
        if (!cerrado)
        {
            if (!enUso)
            {
                enUso = true;
                StartCoroutine(CerrarElevador());
                Debug.Log("salio");
            }
        }
    }

    IEnumerator AbrirElevador()
    {
        audioS.Play();
        while (puerta1.localPosition.x <= distancia1 && puerta2.localPosition.x >= distancia2)
        {
            aux1 = puerta1.localPosition;
            aux1.x += 1 * Time.deltaTime;
            puerta1.localPosition = aux1;

            aux2 = puerta2.localPosition;
            aux2.x -= 1 * Time.deltaTime;
            puerta2.localPosition = aux2;

            yield return new WaitForSeconds(0.02f);
        }
        cerrado = false;
        enUso = false;
    }

    IEnumerator CerrarElevador()
    {
        while (puerta1.localPosition.x >= distanciaAux1 && puerta2.localPosition.x <= distanciaAux2)
        {
            aux1 = puerta1.localPosition;
            aux1.x -= 1 * Time.deltaTime;
            puerta1.localPosition = aux1;

            aux2 = puerta2.localPosition;
            aux2.x += 1 * Time.deltaTime;
            puerta2.localPosition = aux2;

            yield return new WaitForSeconds(0.02f);
        }
        cerrado = true;
        enUso = false;
    }

}

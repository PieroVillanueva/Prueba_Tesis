using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunLimpiarAgua : MonoBehaviour
{
    // Start is called before the first frame update
    private bool limpiando = false;
    private int pasada = 0;
    public List<ColliderDinamico> collidersList;

    [SerializeField] private UnityEvent onCompletarLimpieza = new UnityEvent();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DesaparecerAgua()
    {
        onCompletarLimpieza?.Invoke();
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gas_ducto"))
        {
            limpiando = true;
            StartCoroutine(LimpiarAgua());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("gas_ducto"))
        {
            limpiando = false;
            ReiniciarColliders();
            pasada = 0;
        }
    }

    public bool VerificarColliders()
    {
        int contador = 0;
        foreach (ColliderDinamico aux in collidersList)
        {
            if (aux.primeraVez)
            {
                contador++;
            }
            if (contador == 2)
            {
                return true;
            }
        }
        return false;
    }

    public void ReiniciarColliders()
    {
        foreach (ColliderDinamico aux in collidersList)
        {
            aux.primeraVez = false;
        }
    }

    IEnumerator LimpiarAgua()
    {
        while (limpiando)
        {
            if (VerificarColliders())
            {
                pasada++;
                ReiniciarColliders();
                Debug.Log("Pasada: " + pasada);
            }
            if (pasada == 2)
            {
                Debug.Log("Se limpió el agua");
                DesaparecerAgua();
                ReiniciarColliders();
                limpiando = false;
                pasada = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CambioCollider : MonoBehaviour
{
    public S_Formularios formulario;
    public AudioSource audioManager;
    public AudioClip sonido;
    public int valor;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lapicero"))
        {
            formulario.CambioPagina(valor);
            Sonar();
        }
    }

    public void Sonar()
    {
        audioManager.PlayOneShot(sonido);
    }
}

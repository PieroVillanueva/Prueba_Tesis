using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarLLavaCarroRLA : MonoBehaviour
{
    public RLA_Manager manager;
    public TraspaletaElectricaRLA carro;
    public AudioSource audioSource;
    public AudioClip arranque;
    public AudioClip apagado;
    public GameObject usuario;
    public Transform padre;
    public bool encendido;
    public bool tareaCumplida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            padre = other.transform;
            usuario = GameObject.Find("VR Rig");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            padre = null;
            //audioSource.clip = apagado;
            //audioSource.Play();
            audioSource.PlayOneShot(apagado);
        }
    }

    public void EncenderCarro()
    {
        if (padre != null)
        {
            //audioSource.clip = arranque;
            //audioSource.Play();
            audioSource.PlayOneShot(arranque);
            manager.CumplirTarea(12);
            transform.parent = padre;
            //carro.enabled = true;
            usuario.transform.parent = carro.gameObject.transform;
            usuario.GetComponent<Movement>().Velocidad(0f);
            usuario.GetComponent<CharacterController>().skinWidth = 2f;
            encendido = true;
            return;
        }
        if (encendido)
        {    
            transform.parent = null;
            //carro.enabled = false;
            usuario.transform.parent = null;
            usuario.GetComponent<Movement>().Velocidad(1.5f);
            usuario.GetComponent<CharacterController>().skinWidth = 0.08f;
            encendido = false;
            usuario = null;
            if (tareaCumplida)
            {
                manager.CumplirTarea(18);
            }
        }

    }
}

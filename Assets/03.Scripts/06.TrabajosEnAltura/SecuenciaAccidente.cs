using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuenciaAccidente : MonoBehaviour
{
    // Start is called before the first frame update
    public int secuencia;
    public GameObject detectarCaida;
    public GameObject deslizador;
    public SeguroArnes seguro;
    public Climber escalada;
    public GameObject limite;
    public bool defectuoso;
    public bool primera=true;
    public bool enganchado;
    public GanchoPrueba gancho;
    public ManagerTA manager;
    public AudioClip accidente_clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (secuencia)
            {
                case 1:
                    detectarCaida.SetActive(true);
                    
                    break;
                case 2:
                    if (enganchado)
                    {
                        if (primera)
                        {
                            escalada.Escalar(false);
                            if (defectuoso)
                            {
                                manager.audioController.audioSource.clip = accidente_clip;
                                manager.audioController.audioSource.Play();
                                seguro.Accidente();
                                deslizador.SetActive(false);
                                seguro.Gravedad();
                                seguro.Speed();
                                limite.SetActive(false);
                            }
                            else
                            {
                                StartCoroutine(TiempoAccidente());
                                primera = false;
                            }
                        }
                    }
                    else
                    {
                        escalada.Escalar(false);
                        seguro.Gravedad();
                        seguro.Speed();
                    } 
                    break;
            }
        }
        
    }

    public void ObtenerBool(bool defecto)
    {
        defectuoso = defecto;
    }

    public void ObtenerSeguro(SeguroArnes arnes)
    {
        seguro = arnes;
    }

    IEnumerator TiempoAccidente()
    {
        deslizador.SetActive(false);
        seguro.Gravedad();
        Debug.Log("ACCIDENTE////");
        manager.CumplirTarea(5);
        yield return new WaitForSecondsRealtime(0.5f);
        seguro.NoGravedad();
        deslizador.SetActive(true);
        
        escalada.Escalar(true);

    }

}

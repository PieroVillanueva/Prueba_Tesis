using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespuestaRiesgoAtropellosRLA : MonoBehaviour
{
    // Start is called before the first frame update
    private bool primera;
    public VerificarRespuestasRiesgoAtropelloRLA verificar;
    public RLA_Manager manager;
    public Toggle toggle;
    public bool correcta;
    public Sprite spriteCorrecto;
    public Sprite spriteIncorrecto;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
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
            if (!primera)
            {
                toggle.isOn = true;
                if (correcta)
                {
                    audioSource.PlayOneShot(clip2);
                    toggle.graphic.GetComponent<Image>().sprite = spriteCorrecto;
                }
                else
                {
                    audioSource.PlayOneShot(clip);
                    toggle.graphic.GetComponent<Image>().sprite = spriteIncorrecto;
                }
                if (verificar.VerificarRespuestas())
                {
                    manager.CumplirTarea(23);
                }
                primera = true;

            }
        }
    }

    
}

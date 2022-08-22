using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InterruptorBomba : MonoBehaviour
{
    public AudioSource AudioManager;

    [Tooltip("0:encendio, 1:apagado")]
    public AudioClip[] clipInterruptor;
    public bool Encender;
    public bool RecibeEnergia;

    public MeshRenderer interruptor;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void EncenderApagar(bool verificacion)
    {
        #region
        /*if (verificacion == true)
        {
            AudioManager.clip = clipInterruptor[0];            
        }
        else
        {
            AudioManager.clip = clipInterruptor[1];
        }*/
        #endregion
        AudioManager.clip = verificacion == true ? clipInterruptor[0] : clipInterruptor[1];
        interruptor.material.SetFloat("_EMISSION", 0);
        StartCoroutine(SonarAudio());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player") && RecibeEnergia==true )
        {
            Encender = !Encender;
            EncenderApagar(Encender);
        }
    }
    IEnumerator SonarAudio()
    {
        yield return new WaitForSeconds(0.1f);
        AudioManager.Play();
    }
}

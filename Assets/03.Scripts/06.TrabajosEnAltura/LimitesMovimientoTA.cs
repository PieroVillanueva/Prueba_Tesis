using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesMovimientoTA : MonoBehaviour
{
    // Start is called before the first frame update
    public EngancheArnes enganche1;
    public EngancheArnes enganche2;
    public GameObject jugador;
    public Vector3 posicionCheckPoint;
    public AudioSource audioSource;
    public AudioClip clip;
    Movement player;
    public bool regreso;
    void Start()
    {
        player = GameObject.Find("VR Rig").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((!enganche1.enganchado && !enganche2.enganchado))
            {
                player.Warning = true;
                regreso = true;
                player.StartCoroutine("WarningEffect");
                StartCoroutine(PosicionJ());
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            regreso = false;
            player.Warning = false;
        }
    }

    IEnumerator PosicionJ()
    {  
        audioSource.clip = clip;
        audioSource.Play();
        while (audioSource.isPlaying == true)
        {
            yield return new WaitForFixedUpdate();
        }
        if (regreso)
        {
            player.Warning = false;
            yield return new WaitForSecondsRealtime(1.1f);
            player.StartCoroutine("TransitionLvlIn");
            yield return new WaitForSeconds(1.1f);
            jugador.transform.position = posicionCheckPoint;
            player.StartCoroutine("TransitionLvlOut");
            yield return new WaitForSeconds(1f);
        }
        
    }
}

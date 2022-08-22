using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionesUsuario_SO : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject usuario;
    private Singleton_SO singleton;
    private AudioSource audioS;
    public Transform posicionInicial1;
    public Transform posicionInicial2;
    public List<AudioClip> clips;
    void Start()
    {
        usuario = GameObject.Find("VR Rig");
        singleton = GameObject.Find("Singleton").GetComponent<Singleton_SO>();
        audioS = GetComponent<AudioSource>();
        ColocarPosicion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ColocarPosicion()
    {
        if (!singleton.primerInicio)
        {
            usuario.transform.position = posicionInicial1.position;
            usuario.transform.eulerAngles = posicionInicial1.eulerAngles;
            StartCoroutine(Audios());
            singleton.primerInicio = true;
        }
        else
        {
            usuario.transform.position = posicionInicial2.position;
            usuario.transform.eulerAngles = posicionInicial2.eulerAngles;
        }  
    }

    IEnumerator Audios()
    {
        foreach (AudioClip aux in clips)
        {
            audioS.clip = aux;
            audioS.Play();
            while (audioS.isPlaying)
            {
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}

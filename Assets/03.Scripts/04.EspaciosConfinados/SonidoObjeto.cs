using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public AudioSource audioManager;
    public AudioClip sonido;
    void Start()
    {
        obj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sonar()
    {
        audioManager.PlayOneShot(sonido);
    }
}

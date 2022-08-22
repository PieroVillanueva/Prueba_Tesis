using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Lvl_Manager lvlManager;    
    public AudioSource audioSource;
    public AudioClip[] locuciones;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lvlManager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();        
    }

    
    public void CargarClip(int audioIndex)
    {       
        audioSource.clip = locuciones[audioIndex];
        return;        
    }

    public void ReproducirAudio()
    {        
        audioSource.Play();             
    }    
}

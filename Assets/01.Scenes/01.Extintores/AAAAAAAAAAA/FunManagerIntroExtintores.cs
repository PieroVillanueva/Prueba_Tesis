using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunManagerIntroExtintores : MonoBehaviour
{
    [Header("Audios")]
    public AudioSource reproductorAudios;
    public AudioClip[] listaAudios;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reproducirAudio(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator reproducirAudio(int pos)
    {
        reproductorAudios.clip = listaAudios[pos];
        if (pos==0)
        {
            yield return new WaitForSeconds(3.00f);
        }        
        reproductorAudios.Play();
    }

}

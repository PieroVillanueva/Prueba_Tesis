using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TL_Secuencias : MonoBehaviour
{
    PlayableDirector director;
    public PlayableAsset[] cinematicas;

    
    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            reproducirCinematica(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            reproducirCinematica(1);
        }*/
    }
    public void reproducirCinematica(int i)
    {
        director.playableAsset = cinematicas[i];
        director.Play();
    }
}

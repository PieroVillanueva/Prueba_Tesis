using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunElectrificarPanel : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
            Debug.Log("GAME OVER");
        }
    }
}

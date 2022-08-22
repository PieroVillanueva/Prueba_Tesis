using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_TareaCollider : MonoBehaviour
{
    public Lvl_Manager manager;
    public AudioSource audioManager;
    public AudioClip sonido;
    public int tareaCompletar;

    public bool primera;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lapicero"))
        {
            //Debug.Log("toca lapicero");
            
            
            if (!primera)
            {
                Debug.Log("A");
                if (audioManager.isPlaying == false) Sonar();

                manager.CumplirTarea(tareaCompletar);
                primera = true;
                gameObject.SetActive(false);
            }
        }
    }

    public void Sonar()
    {
        audioManager.PlayOneShot(sonido);
    }
}

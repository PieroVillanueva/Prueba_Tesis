using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_anotar : MonoBehaviour
{
    public AudioSource anotar;
    //public static Manager_PreparacionJ mp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (G_Manager.gm.si_anotado == false)
        {
            if (other.tag == "Lapicero")
            {
                anotar.Play();
                Debug.Log("detectado lapicero");
                G_Manager.gm.si_anotado = true;
                //G_Manager.gm.si_siguiente_fase = true;
            }
        }
    }
}

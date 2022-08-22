using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class a_GirarLlantas : MonoBehaviour
{
    public Transform[] llantas;
    public float Actualspeed;    
    
    void Update()
    {
        if (Actualspeed==0) return;

        GirarRuedas(Actualspeed);
    }

    void GirarRuedas(float speed)
    {
        foreach (Transform llanta in llantas)
        {
            llanta.Rotate(new Vector3(-15, 0, 0), 10 * speed * Time.deltaTime);
        }
    }   
}

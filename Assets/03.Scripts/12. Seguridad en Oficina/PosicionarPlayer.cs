using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionarPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Singleton_SO singleton;
    public GameObject player;
    void Start()
    {
        singleton = GameObject.Find("Singleton").GetComponent<Singleton_SO>();
        player = GameObject.Find("VR Rig");
        if (singleton.otroEjercicio)
        {
            singleton.PosicionPlayer(player);   
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}

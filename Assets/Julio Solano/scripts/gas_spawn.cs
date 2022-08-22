using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas_spawn : MonoBehaviour
{
    public GameObject gas;
    public Transform spawnPoint;
    public float timer = 10f;
    public float speed = 2f;
    public bool shooting  =false;
    float aux;
    void Start()
    {
       aux = timer;
    }
    void Update()
    {
        timer = timer - speed * Time.deltaTime;
        if (timer <= 0)
        {
            shooting = true;
            timer = aux;
        }
    }

    void FixedUpdate()
    {
    /*bool shoot = Input.GetButtonDown("Fire1");

    if (shoot) Instantiate(gas, spawnPoint.position, spawnPoint.rotation);*/
    if (shooting) { Instantiate(gas, spawnPoint.position, spawnPoint.rotation);
        shooting = false;
    }

    }
}

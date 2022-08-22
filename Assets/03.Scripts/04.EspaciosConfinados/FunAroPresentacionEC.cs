using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunAroPresentacionEC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject indicador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            indicador.SetActive(true);
        }
    }
}

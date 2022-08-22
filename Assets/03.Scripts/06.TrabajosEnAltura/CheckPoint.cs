using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject caida;
    public CaidaTecho caidaTecho;
    public GameObject checkPoint;
    public LimitesMovimientoTA limite;
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
            caida.SetActive(true);
            caidaTecho.posicionCheckPoint = checkPoint.transform.position;
            limite.posicionCheckPoint = checkPoint.transform.position;
        }
    }

    
}

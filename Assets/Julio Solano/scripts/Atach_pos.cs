using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atach_pos : MonoBehaviour
{
    public GameObject atach;

    /*public float X;
    public float Y;
    public float Z;*/
    public Vector3 posL;
    public Vector3 rotL;
    public Vector3 posR;
    public Vector3 rotR;
    Transform aux;
    void Start()
    {
        aux = atach.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            /*if(other.name=="Right hand")
            {
               /* Vector3 posR = Vector3.zero;
                Transform rot=atach.transform;
                rot.localEulerAngles = Vector3.zero;
                //atach.transform.position = posR;
            }
            else
            {
                atach.transform.position = aux.position;
                atach.transform.eulerAngles = aux.eulerAngles;
            }*/
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ColliderDinamico : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private UnityEvent onTriggerEntered = new UnityEvent();
    [SerializeField] private UnityEvent onTriggerExited = new UnityEvent();
    [SerializeField] private UnityEvent onTriggerStayed = new UnityEvent();
    public bool usarPrimeraVez;
    public bool primeraVez;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (usarPrimeraVez)
        {
            if (!primeraVez)
            {
                if (other.CompareTag(targetTag))
                {
                    primeraVez = true;
                    onTriggerEntered?.Invoke();
                }
            }
        }
        else
        {
            if (other.CompareTag(targetTag))
            {
                onTriggerEntered?.Invoke();
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onTriggerExited?.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onTriggerStayed?.Invoke();
        }
    }
    
}

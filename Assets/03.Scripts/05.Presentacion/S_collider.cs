using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_collider : MonoBehaviour
{
    [SerializeField] private bool ActivarObjeto;
    [SerializeField] private GameObject ObjetoActivar;
    [SerializeField] private bool isUsed = false;
    [SerializeField] private Manage_EPeligrosas controlSounds;

    [Tooltip("colocar en false si usa corrutina para encenderce luego de un tiempo")]
    public bool initOn;
    //public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        controlSounds = GameObject.Find("ControladorLocuciones").GetComponent<Manage_EPeligrosas>();
        StartCoroutine(delayChildObjects(initOn));
        if (ObjetoActivar != null) ObjetoActivar.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FuncionAnillo();
        }
    }
    void FuncionAnillo()
    {
        if (ActivarObjeto == true && ObjetoActivar != null) ObjetoActivar.SetActive(true);
        if(isUsed==false)
        {
            isUsed = true;
            controlSounds.AsignarTarea();
        }
        gameObject.SetActive(false);
    }

    IEnumerator delayChildObjects(bool initOn)
    {
        if (initOn == false)
        {
            GameObject child = GetComponentInChildren<ParticleSystem>().gameObject;
            child.SetActive(false);
            yield return new WaitForSeconds(24);
            child.SetActive(true);
        }
    }
} 

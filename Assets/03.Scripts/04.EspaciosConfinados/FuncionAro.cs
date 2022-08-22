using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionAro : MonoBehaviour
{
    public AsigarObjetos asignarObj;
    public int escena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (escena == 1)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                asignarObj.AsignarTablero();
            }
        }
        if (escena == 2)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                asignarObj.Asignar();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionAroTA : MonoBehaviour
{
    // Start is called before the first frame update
    public bool validar;
    public GameObject muro;
    public Transform[] puertas;
    public float max;
    public Vector3 rotacion;
    public Vector3 rotacion1;
    public ManagerTA manager;
    public int numero;
    public GameObject aro;
    public GameObject checkList;
    public GameObject salida;
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
            if (validar)
            {
                muro.SetActive(false);
                MoverPuertas();
                aro.SetActive(true);
            }
            else
            {
                switch (numero)
                {
                    case 0:
                        manager.CumplirTarea(2);
                        break;
                    case 1: manager.CumplirTarea(0);
                        break;
                    case 2: manager.CumplirTarea(3);
                        break;
                    case 3: manager.CumplirTarea(4);
                        break;
                    case 4:
                        manager.CumplirTarea(8);
                        break;

                    case 5://caso de salida
                        manager.CumplirTarea(10);
                        checkList.SetActive(true);
                        salida.SetActive(true);
                        break;
                }
                gameObject.SetActive(false);
            }
            
        }
        
    }

    public void MoverPuertas()
    {
        StartCoroutine(MovimientoPuertas());
    }

    IEnumerator MovimientoPuertas()
    {
        while (rotacion.y != -max && rotacion1.y != max )
        {
            rotacion.x = puertas[0].localEulerAngles.x;
            rotacion.z = puertas[0].localEulerAngles.z;
            rotacion.y -= 1;
            puertas[0].localEulerAngles = rotacion;
            rotacion1.x = puertas[1].localEulerAngles.x;
            rotacion1.z = puertas[1].localEulerAngles.z;
            rotacion1.y += 1;
            puertas[1].localEulerAngles = rotacion1;

            yield return new WaitForSeconds(0.02f);
        }
        gameObject.SetActive(false);
    }
    
}

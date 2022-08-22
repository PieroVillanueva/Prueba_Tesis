using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_cajon : MonoBehaviour
{
    public bool afuera_cajon;
    public string nombre_indicador;
    public Cajon_ergo ca;
    public int n_item;
    public bool VaDerecha;
    Vector3 pos0;
    Vector3 rot0;
    //public GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        if (VaDerecha == true)
        {
            ca = GameObject.Find("interior_cajonD").GetComponent<Cajon_ergo>();
        }
        else
        {
            ca = GameObject.Find("interior_cajonI").GetComponent<Cajon_ergo>();
        }
        
        pos0 = transform.position;
        rot0 = transform.localEulerAngles;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Detect"))
        {
            if (afuera_cajon == false)
            {
                if (VaDerecha == true && other.name == "interior_cajonD")
                {
                    ca.activar_item(n_item);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    if (VaDerecha == false && other.name == "interior_cajonI")
                    {
                        ca.activar_item(n_item);
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        this.transform.position = pos0;
                        this.transform.localEulerAngles = rot0;
                    }
                }
            }
            else
            {
                if (other.name == nombre_indicador)
                {
                    ca.activar_item(n_item);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}

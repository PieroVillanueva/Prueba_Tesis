using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajon_ergo : MonoBehaviour
{
    public GameObject[] item;
    public bool cajonD;
    public int limite_items;
    public int totalItems;
    // Start is called before the first frame update
    void Start()
    {
        GManagerErgo.ge.E2_total_items += item.Length;
        totalItems= GManagerErgo.ge.E2_total_items;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activar_item(int n_item)
    {
        GManagerErgo.ge.E2_actualTotal++;
        item[n_item].SetActive(true);
        GManagerErgo.ge.Ya_total_Items();
    }
}

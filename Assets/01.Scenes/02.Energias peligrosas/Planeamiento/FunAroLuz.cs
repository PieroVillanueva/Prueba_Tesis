using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunAroLuz : MonoBehaviour
{
    [Tooltip("Manager del nivel")]
    public Lvl_Manager lvl_manager;
    public int tareaACumplir;
    // Start is called before the first frame update
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();// Busca el manager del nivel
       
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lvl_manager.CumplirTarea(tareaACumplir);// cumple la tarea designada
            gameObject.SetActive(false);            //desactiva el aro de luz 
        }
    }
 




}

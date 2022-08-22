using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ColliderTarea : MonoBehaviour
{
    [Tooltip("Manager del nivel")]
    public Lvl_Manager lvl_manager;
    public int tareaACumplir;
    // Start is called before the first frame update
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lvl_manager.CumplirTarea(tareaACumplir);
            gameObject.SetActive(false);
        }
    }
}

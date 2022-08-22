using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunJuegoManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public bool[] equipo;
    public bool todosAgarrados;
    public Lvl_Manager lvl_manager;
    public FunCheckList checkList;
    
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();
        

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void activarEquipo(int pos)// se llama al agarrar un objeto cuando es el momento indicado
    {
        if (!todosAgarrados) {//En caso no se agarren todos los  se activa el bool de la posición enviada y se verifica si se agarraron todos
            equipo[pos] = true;
            for (int i = 0; i < equipo.Length; i++)
            {
                if (!equipo[i])
                {
                    break;
                }
                if (i == equipo.Length - 1)// En caso se agarren todos los objetos se considera como todosagarrados y se cumple la tarea 1
                {
                    todosAgarrados = true;
                    lvl_manager.CumplirTarea(1);
                    
                    Debug.Log("todo revisado");
                }
            }
        }
    }


}

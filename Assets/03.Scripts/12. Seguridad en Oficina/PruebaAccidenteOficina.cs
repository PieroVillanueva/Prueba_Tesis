using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PruebaAccidenteOficina : MonoBehaviour
{
    public PlayerNavMesh playerNavMesh;
    public bool seDetuvo;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("App"))
        {
            DetenerPlayer();
        }
    }
    public void DetenerPlayer()
    {
        //playerNavMesh.DetenerRecorrido();
        seDetuvo = true;
    }

}

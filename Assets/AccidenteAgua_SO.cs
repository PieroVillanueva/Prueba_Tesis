using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidenteAgua_SO : MonoBehaviour
{
    // Start is called before the first frame update
    public Material materialAgua;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Casco"))
        {
            //other.GetComponent<PlayerNavMesh>().AccidenteAgua();
        }
        else if (other.CompareTag("Lapicero"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialAgua;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.SetActive(false);
        }
    }

    public void resetMesh()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    
}

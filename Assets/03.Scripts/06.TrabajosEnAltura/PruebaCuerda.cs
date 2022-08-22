using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaCuerda : MonoBehaviour
{
    public Transform[] posiciones;
    public Vector3[] posicionesCuerda;
    public LineRenderer linea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConectarPuntos();
        linea.SetPositions(posicionesCuerda);
    }

    public void ConectarPuntos()
    {
        //gancho.position = new Vector3(Mathf.Clamp(gancho.position.x, engancheInferior.position.x, engacheSuperior.position.x), gancho.position.y, Mathf.Clamp(gancho.position.z, engancheInferior.position.z, engacheSuperior.position.z));
        for (int i = 0; i < posiciones.Length; i++)
        {           
                posicionesCuerda[i] = posiciones[i].position;            
        }

    }
}

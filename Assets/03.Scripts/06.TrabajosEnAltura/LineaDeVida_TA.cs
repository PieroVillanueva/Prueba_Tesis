using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaDeVida_TA : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform engancheInferior, engacheSuperior, gancho;
    public LineRenderer lineaDeVida;
    public Vector3[] puntos;
    public Vector3 offeset;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConectarPuntos();
        lineaDeVida.SetPositions(puntos);
        
    }

    public void ConectarPuntos()
    {
        //gancho.position = new Vector3(Mathf.Clamp(gancho.position.x, engancheInferior.position.x, engacheSuperior.position.x), gancho.position.y, Mathf.Clamp(gancho.position.z, engancheInferior.position.z, engacheSuperior.position.z));
        puntos[0] = engancheInferior.localPosition;
        puntos[1] = gancho.position + offeset;
        puntos[2] = engacheSuperior.localPosition;
    }
}

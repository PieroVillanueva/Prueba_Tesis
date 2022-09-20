using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPersonajeHabla : MonoBehaviour
{
    public AgentNavMesh agente;
    // Start is called before the first frame update
    void Start()
    {
        agente.UseLipsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

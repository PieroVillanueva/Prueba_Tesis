using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_cumplirTarea : MonoBehaviour
{
    public bool isUsed = false;
    public Manage_EPeligrosas controlSounds;
    private void Start()
    {
        controlSounds = GameObject.Find("ControladorLocuciones").GetComponent<Manage_EPeligrosas>();
    }
    // Update is called once per frame
    public void CompletarTarea()
    {
        if (isUsed == false)
        {
            isUsed = true;
            controlSounds.AsignarTarea();
        }
    }
}

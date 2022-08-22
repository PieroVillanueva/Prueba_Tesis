using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunSwitchPanel : MonoBehaviour
{
    public MeshRenderer mat_Luz;
    public GameObject onOff;
    public bool primeraVez;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void apagarPanel()
    {
        if (!primeraVez)
        {
            primeraVez = true;
            mat_Luz.material.SetFloat("_EMISSION", 0);
            onOff.transform.Rotate(0, 0, 77);
        }
        
    }
}

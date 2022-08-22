using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunCheckList : MonoBehaviour
{
   
    public Toggle[] checks;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarCheck(int indice)
    {
        checks[indice].isOn = true;
    }
    public void desactivarCheck(int indice)
    {
        checks[indice].isOn = false;
    }





}

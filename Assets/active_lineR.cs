using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_lineR : MonoBehaviour
{
    public GameObject line;
       // Start is called before the first frame update
    void Start()
    {
        line.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activar_line(int active)
    {
        bool vale=active==0?false:true;
        line.SetActive(vale);
    }
}

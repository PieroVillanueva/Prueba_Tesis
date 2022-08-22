using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject indi;
    public bool primera;
    public GameObject aro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarObjeto()
    {
        if (!primera)
        {
            primera = true;
            aro.SetActive(true);
        }
    }
    public void desac_indi()
    {
        indi.SetActive(false);
    }
}

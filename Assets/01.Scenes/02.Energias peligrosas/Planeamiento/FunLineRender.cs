using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunLineRender : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public LineRenderer linea;
    // Start is called before the first frame update
    void Start()
    {
        linea.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        linea.SetPosition(0, objeto1.transform.position);
        linea.SetPosition(1, objeto2.transform.position);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionGanchoTecho : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ganchoPosicion;
    public JugadorSeguimiento seguimiento;
    public Vector3 pos, rot;
    void Start()
    {
        pos = ganchoPosicion.localPosition;
        rot = ganchoPosicion.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
       
    }




}

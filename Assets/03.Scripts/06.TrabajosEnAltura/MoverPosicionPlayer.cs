using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPosicionPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seguir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeguimientoPlayer()
    {
        transform.position = new Vector3(seguir.transform.position.x, seguir.transform.position.y, 0);
    }
}

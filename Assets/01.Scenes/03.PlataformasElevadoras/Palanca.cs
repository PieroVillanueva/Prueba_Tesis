using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject piso;
    public bool active;
    public Quaternion rot;

    public int YMax, YMin;
    void Start()
    {
        Invoke("rotationR", 0.5f);
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (transform.rotation.x < -0.40)
        {
             Vector3 ve = new Vector3(piso.gameObject.transform.position.x, piso.gameObject.transform.position.y - 0.5f * Time.deltaTime, piso.gameObject.transform.position.z);
             piso.gameObject.transform.position = ve;
        }
        if (transform.rotation.x > 0.55)
        {
             Vector3 ve = new Vector3(piso.gameObject.transform.position.x, piso.gameObject.transform.position.y + 0.5f * Time.deltaTime, piso.gameObject.transform.position.z);
             piso.gameObject.transform.position = ve;
        }
        piso.transform.position = new Vector3(piso.transform.position.x, Mathf.Clamp(piso.transform.position.y, YMin, YMax), piso.transform.position.z);
    }

    public void prueba(bool bolean)
    {
        active = bolean;
        Debug.Log("a");
        
    }


    
}

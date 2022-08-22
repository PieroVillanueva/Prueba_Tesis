using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_destroy : MonoBehaviour
{
    public float timelife = 100;
    public float speed = 1;
    public GameObject gas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timelife = timelife - speed*Time.deltaTime;
        if (timelife <= 0) { Destroy(this.gas); }
    }
}

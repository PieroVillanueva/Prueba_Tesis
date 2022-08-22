using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas_mov : MonoBehaviour
{
    //public Rigidbody gas;
    public float speed = 10;
    // Start is called before the first frame update
    void Fire()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}

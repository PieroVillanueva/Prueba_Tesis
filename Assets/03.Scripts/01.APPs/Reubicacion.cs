using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reubicacion : MonoBehaviour
{ 
    //public LayerMask piso;
    Vector3 pos0;
    Vector4 rot0;
    bool tp=false;
    float timer;
    float tp_time=0.1f;
    bool no_grab=true;
 

    // Start is called before the first frame update
    void Start()
    {

        pos0 = new Vector3();
        rot0 = new Vector4();
        pos0 = this.transform.position;
        rot0 = this.transform.localEulerAngles;
    }
    private void Update()
    {
        if (tp == false)
        {
            timer += Time.deltaTime;
            if (timer >= tp_time)
            {
                tp = true;
                this.transform.position = pos0;
                this.transform.localEulerAngles = rot0;
                Debug.Log(this.gameObject.name + " teletransportado");
                this.transform.position = pos0;
                this.transform.localEulerAngles = rot0;
                timer = 0.0f;
            }
        }

        if (no_grab == true && this.transform.position != pos0)
        {
            tp = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            no_grab = false;
        }
    }
    /*void OnCollisionStay(Collision coll)
    {
        if (LayerMask.LayerToName(coll.gameObject.layer) == "Ground")
        {

            Debug.Log("piso detectado");
            timer += Time.deltaTime;
            if (timer >= tp_time) {
                this.transform.position = pos0;
                this.transform.localEulerAngles = rot0;
                Debug.Log(this.gameObject.name + " teletransportado");
            }
         
        }
    }*/
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player") { no_grab = true; }
        
        timer = 0.0f;
    }

}

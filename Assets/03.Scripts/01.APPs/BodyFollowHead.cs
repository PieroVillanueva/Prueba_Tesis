using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollowHead : MonoBehaviour
{
    public Vector3 offset;
    public Transform head;
    public bool enganche;
    
    // Update is called once per frame
    void Update()
    {
        
        if (!enganche)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, head.transform.eulerAngles.y, transform.eulerAngles.z);
            transform.position = head.transform.position + offset;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, head.transform.position.y, transform.position.z) + offset;
        }
        
    }

    public void Enganchado(bool gancho)
    {
        enganche = gancho;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByName : MonoBehaviour
{
    public string name_item;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.name == name_item)
        {
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPosByEvent : MonoBehaviour
{
    public Vector3 newPos;
    public Vector3 newRot;
    public bool ya_enpos = false;
    Vector3 pos0;
    Vector3 rot0;
    // Start is called before the first frame update
    void Start()
    {
        pos0 = this.transform.localPosition;
        rot0 = this.transform.localEulerAngles;
    }
    public void solo_nueva_pos()
    {
        if (ya_enpos == false)
        {
            this.gameObject.transform.localPosition = newPos;
            ya_enpos = true;
        }
    }
    public void solo_nueva_rot()
    {
        if (ya_enpos == false)
        {
            this.gameObject.transform.localEulerAngles = newRot;
            ya_enpos = true;
        }
    }
    public void nueva_posrot()
    {
        if (ya_enpos == false)
        {
            this.gameObject.transform.localPosition = newPos;
            this.gameObject.transform.localEulerAngles = newRot;
            ya_enpos = true;
        }
    }
}

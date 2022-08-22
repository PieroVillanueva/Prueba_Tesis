using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuello_anim : MonoBehaviour
{
    public bool en_tarea;
    public bool anim_start;
    Vector3 rot;
    public float rotacion;
    public float speed;
    public Animator op1;
    void Start()
    {
        this.transform.localRotation = Quaternion.Euler(rot);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_start == true && en_tarea == true)
        {
            Debug.Log("empezo anim cuello");
            rotacion += Time.deltaTime * speed;
            this.transform.localRotation = Quaternion.Euler(rot.x - rotacion, rot.y, rot.z);
            if (rotacion >= 45)
            {
                Debug.Log("alto anim cuello");
                //anim_start = false;
                en_tarea = false;
            }
        }
        if (GManagerErgo.ge.e1_cuello_anim == true && anim_start == false)
        {
            op1.SetTrigger("posC");
            anim_start = true;
            //StartCoroutine(a_o());
        }
    }
    IEnumerator a_o()
    {
        yield return new WaitForSeconds(.1f);

        op1.SetTrigger("posC");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dool : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Rigidbody[] rigidbodies;
    public Rigidbody cuerda;

    void Start()
    {
       // rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
       // animator.enabled = false;
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            //if (rigidbody.gameObject.name != "mixamorig7:Spine2")
            //{
                rigidbody.isKinematic = isKinematic;
            //}
        }

        animator.enabled = !enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetEnabled(true);
            StartCoroutine(colgado());
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetEnabled(false);
        }
    }
    IEnumerator colgado()
    {
        yield return new WaitForSeconds(1.00f);
        //cuerda.isKinematic = true;
        
    }
}

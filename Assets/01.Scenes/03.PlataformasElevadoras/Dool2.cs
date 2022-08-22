using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dool2 : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Rigidbody[] rigidbodies;
   
    public GameObject perso;
    void Start()
    {
        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        animator.enabled = !enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            // SetEnabled(true);
            animator.SetTrigger("salto");
            //muerte();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetEnabled(false);
        }
    }
    public void muerte()
    {
        perso.transform.localPosition = new Vector3(perso.transform.localPosition.x - 2.00f, perso.transform.localPosition.y - 0.5f, perso.transform.localPosition.z);
        SetEnabled(true);
    }
}

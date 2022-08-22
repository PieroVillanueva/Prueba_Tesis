using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_ControlEffect : MonoBehaviour
{
    public XRController control;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(vibrar());
    }

    // Update is called once per frame

    public void Vibracion()
    {
        StartCoroutine(vibrar());
    }
    IEnumerator vibrar()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("vibrando");
        control.SendHapticImpulse(0.9f, 1.5f);

    }

    public void VibracionPersonalizada(float fuerza)
    {
        StartCoroutine("vibrarPersonalizado",fuerza);
    }
    IEnumerator vibrarPersonalizado(float fuerza)
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("vibrando");
        control.SendHapticImpulse(fuerza, 1.5f);

    }

}

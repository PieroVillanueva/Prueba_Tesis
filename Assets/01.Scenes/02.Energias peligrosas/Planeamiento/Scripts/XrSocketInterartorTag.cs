using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XrSocketInterartorTag : XRSocketInteractor
{
    public string targetTag;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.CompareTag(targetTag);
    }

    public void EliminarTarget()
    {
        socketActive = false;
    }

    public void ActivarTarget()
    {
        socketActive = true;
    }

    public GameObject RetornarTarget()
    {
        return selectTarget.gameObject;
    }
    
}

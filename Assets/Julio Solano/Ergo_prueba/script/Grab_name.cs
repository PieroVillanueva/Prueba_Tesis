using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grab_name : XRGrabInteractable 
{
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        Debug.Log(interactor.name);
        return base.IsSelectableBy(interactor);
    }

}

    

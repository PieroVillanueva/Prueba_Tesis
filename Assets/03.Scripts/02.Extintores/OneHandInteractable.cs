using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OneHandInteractable : XRGrabInteractable
{
    [Header("Other")]
    public bool useAttachs;
    public Transform[] attachs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isGrabed = selectingInteractor && !interactor.Equals(selectingInteractor) && selectingInteractor.CompareTag("Player");
        if (selectingInteractor != null)
        {
            AttachAsingation(selectingInteractor.name);
        }
        //Debug.Log(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isGrabed;
    }

    public override bool IsHoverableBy(XRBaseInteractor interactor)
    {
        //Debug.Log(interactor);
        if (interactor != null)
        {
            AttachAsingation(interactor.name);
        }
        return base.IsHoverableBy(interactor);
    }

    void AttachAsingation(string name)
    {
        if (useAttachs == true)
        {
            switch (name)
            {
                case "Left hand":
                    attachTransform = attachs[0];
                    break;
                case "Right hand":
                    attachTransform = attachs[1];
                    break;
            }
            return;
        }
        //Debug.Log($"no usa attachs/no reconoce nombre {name}");
    }
}

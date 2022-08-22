using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandsGrabInteractable : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion attachInitialRotation;
    public enum TwoHandRotationType { None,First,Second};
    public TwoHandRotationType twoHandRotationType;
    public bool snapToSecondHand=true;
    private Quaternion initialRotationOffset;
    [Header("Other")]
    public bool useAttachs;
    public Transform[] attachs;
    Vector3 rot0;
    // Start is called before the first frame update
    void Start()
    {
        rot0 = transform.eulerAngles;
        foreach(var item in secondHandGrabPoints)
        {
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor && selectingInteractor)
        {
            if (snapToSecondHand)
                selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
           else
            selectingInteractor.attachTransform.rotation = GetTwoHandRotation()*initialRotationOffset;
        }
        base.ProcessInteractable(updatePhase);
    }
    private Quaternion GetTwoHandRotation()
    {
        Quaternion targetRotation;
        /*if (twoHandRotationType == TwoHandRotationType.None)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }
        else if (twoHandRotationType == TwoHandRotationType.First)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);
        }*/
        targetRotation = Quaternion.identity;
        return targetRotation;
    }
    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Segunda Mano Agarra");
        secondInteractor = interactor;
      // initialRotationOffset = Quaternion.Inverse(GetTwoHandRotation()) * selectingInteractor.attachTransform.rotation;
    }
    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Segunda Mano Suelta");
        secondInteractor = null;
       
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("1era Mano entra");
        base.OnSelectEntered(interactor);
        attachInitialRotation = interactor.attachTransform.localRotation;
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        Debug.Log("1era Mano sale");
        base.OnSelectExited(interactor);
        secondInteractor = null;
        attachInitialRotation = interactor.attachTransform.localRotation;
    }
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isGrabed = selectingInteractor && !interactor.Equals(selectingInteractor);
        //bool isAlreadyGrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        if (selectingInteractor != null)
        {
            AttachAsingation(selectingInteractor.name);
        }
        //Debug.Log(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isGrabed;
        
       // return base.IsSelectableBy(interactor)&&!isAlreadyGrabbed;
    }
    void AttachAsingation(string name)
    {
        if (useAttachs == true)
        {
            switch (name)
            {
                case "Left hand":
                    attachTransform = attachs[0];
                    transform.eulerAngles = rot0+new Vector3(0, 180, 0);
                    break;
                case "Right hand":
                    attachTransform = attachs[1];
                    transform.eulerAngles = rot0;
                    break;
            }
            return;
        }
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
    public void habilitar_move(bool x)
    {
        trackRotation = x;
        trackPosition = x;
    }
}

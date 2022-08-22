using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XrSocketEPPVestuario : XRSocketInteractor
{
    public string targetTag;
    public string tipoMostrable;

    public enum Version { A, B, C };
    public enum ParteCuerpo { Cabeza, Ojos, Oidos, Manos, Respiratoria, Ropa, Pies };
    public Version version;
    public ParteCuerpo parteCuerpo;

    //public FunNivelVestuarioController controladorDeNivel;
    public FunManagerMostrarObjetos managerMostrable;
    public bool colocado;
    public bool HoverMostrado;
    public GameObject eppColocadoFinal;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();
        return base.CanSelect(interactable) && interactable.CompareTag(targetTag) && tipo.parteCuerpo.ToString() == parteCuerpo.ToString();
    }


    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();
        //controladorDeNivel.EppColocado(tipo);
        eppColocadoFinal = interactable.gameObject;
        Debug.Log("Escenario de colocado: " + tipo.parteCuerpo);
        //NUEVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        interactable.gameObject.GetComponent<ObjetoFuncion>().noVolverAsignar = true;

        //FIN NUEVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        if (tipo.parteCuerpo.ToString() == tipoMostrable)
        {
            managerMostrable.MostrarMostrable(tipo);
            colocado = true;
        }

        base.OnSelectEntered(interactable);
    }
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {

        if (interactable != null && interactable.CompareTag(targetTag))
        {
            FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();
            //controladorDeNivel.EPPRetirado(tipo);
            eppColocadoFinal = null;
            //NUEVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            interactable.gameObject.GetComponent<ObjetoFuncion>().noVolverAsignar = false;
            //FIN NUEVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

            if (tipo.parteCuerpo.ToString() == tipoMostrable)
            {
                managerMostrable.OcultarMostrable(tipo);

            }
            colocado = false;
        }

        base.OnSelectExited(interactable);

    }

    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {
        FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();

        if (tipo.parteCuerpo.ToString() == tipoMostrable && !colocado && !HoverMostrado)
        {
            managerMostrable.MostrarMostrable(tipo);
            HoverMostrado = true;
            managerMostrable.CambiarColor(tipo, true);
        }
        base.OnHoverEntered(interactable);
    }

    protected override void OnHoverExited(XRBaseInteractable interactable)
    {

        if (interactable != null)
        {
            FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();

            if (tipo.parteCuerpo.ToString() == tipoMostrable)
            {
                if (!colocado)
                {
                    managerMostrable.OcultarMostrable(tipo);

                }
                HoverMostrado = false;
                managerMostrable.CambiarColor(tipo, false);
            }
        }
        base.OnHoverExited(interactable);
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        if (interactable.CompareTag(targetTag))
        {
            FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();

            if (tipo.parteCuerpo.ToString() == parteCuerpo.ToString())
            {
                return base.CanHover(interactable);
            }
        }
        return false;
    }

}


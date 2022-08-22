using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XRSocketFiltradoParaEPP : XRSocketInteractor
{
    public string targetTag;
    public string tipoMostrable;

    public enum Version { A, B, C };
    public enum ParteCuerpo { Cabeza, Ojos, Oidos, Manos, Respiratoria, Ropa, Pies };
    public Version version;
    public ParteCuerpo parteCuerpo;

    public FunControlador controladorDeNivel;
    public FunManagerMostrarObjetos managerMostrable;
    public bool colocado;
    public bool HoverMostrado;
    

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();
        return base.CanSelect(interactable) && interactable.CompareTag(targetTag) && tipo.parteCuerpo.ToString() == parteCuerpo.ToString();//Verifica si es de la parte de cuerpo correcta sino no la detecta
    }


    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();
        controladorDeNivel.EppColocado(tipo);//Se manda la señal de que se coloco para que se cambie a true si no esta colocado
        Debug.Log("Escenario de colocado: " + tipo.parteCuerpo);

        interactable.gameObject.GetComponent<ObjetoFuncion>().noVolverAsignar = true;//Se desactivae el letrero que aparece encima del objeto


        if (tipo.parteCuerpo.ToString() == tipoMostrable)
        {
            managerMostrable.MostrarMostrable(tipo);// Mostrar objeto colocado y ocultar el mes del acercado
            colocado = true;
        }

        base.OnSelectEntered(interactable);
    }
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {

        if (interactable != null && interactable.CompareTag(targetTag))
        {
            FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();

            interactable.gameObject.GetComponent<ObjetoFuncion>().noVolverAsignar = false; // Se puede mostrar el letrero descriptivo del modelo original
          

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
            managerMostrable.MostrarMostrable(tipo); // Mostrar objeto colocado y ocultar original
            HoverMostrado = true;
            managerMostrable.CambiarColor(tipo, true);//Cambia el color de mostrable al original
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
                    managerMostrable.OcultarMostrable(tipo);// Mostrar el original y ocultar el colocado

                }
                HoverMostrado = false;
                managerMostrable.CambiarColor(tipo, false); //Cambia el color de mostrable al original
            }
        }
        base.OnHoverExited(interactable);
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        if (interactable.CompareTag(targetTag))
        {
            FunTipoEPP tipo = interactable.gameObject.GetComponent<FunTipoEPP>();

            if (tipo.parteCuerpo.ToString() == parteCuerpo.ToString())// Solo puede hacer hover en caso sea de la parte del cuerpo correcta
            {
                return base.CanHover(interactable);
            }
        }
        return false;
    }

}


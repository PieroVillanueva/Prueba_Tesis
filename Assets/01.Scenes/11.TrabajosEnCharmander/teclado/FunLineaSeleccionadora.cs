using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class FunLineaSeleccionadora : MonoBehaviour
{
    public int maxDistance=10;
    public LineRenderer linea;
    public Material blanco;
    public Material celeste;

    public FunReceptorTeclado receptor;

    [Header("Manos")]
    public XRNode manoEscogida;
    public float valorTrigger;
    public bool presionado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {      
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        {
            Debug.Log("Did Hit"+ hit.collider.name);
            linea.SetPosition(0, transform.position);
            linea.SetPosition(1, transform.position+(Vector3.forward * hit.distance));
            linea.material = celeste;
            //=========================================================================

            InputDevice device = InputDevices.GetDeviceAtXRNode(manoEscogida);
            device.TryGetFeatureValue(CommonUsages.trigger, out valorTrigger);

            if (valorTrigger >= 0.6f)
            {
                if (!presionado)
                {
                    Debug.Log("Presionado");
                    receptor.escribirLetra(hit.collider.gameObject.name);
                    presionado = true;
                }
            }
            else
            {
                presionado = false;
            }

        }
        else
        {
            linea.SetPosition(0, transform.position);
            linea.SetPosition(1, transform.position + (Vector3.forward * maxDistance));
            linea.material = blanco;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TraspaletaElectricaRLA : MonoBehaviour
{
    public GameObject placa;
    public GameObject boton;
    public RLA_Manager manager;
    public HingeJoint steeringWheel;
    public float maxTurnAngle = 180;
    public float speedMovimiento = 1f;
    //public HingeJoint speedLever;    
    public float maxSpeedAngle = 35;
    public bool primerGiro, primerMovimiento, activarTareaPrimera;

    public bool primera;
    public float speed;
    public XRRig rig;
    public XRNode inputSource;
    public Vector2 inputAxis;

    public ColocarLLavaCarroRLA llave;
    void Update()
    {
        if (llave.encendido)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        }



    }
    private void FixedUpdate()
    {
        // pass the input to the car!
        if (llave.encendido)
        {
            float h = Mathf.Clamp(steeringWheel.angle / maxTurnAngle, -1, 1);
            //float v = Mathf.Clamp((speedLever.angle / maxSpeedAngle)*Time.deltaTime, -1, 1);
            float v = speed * inputAxis.y * Time.deltaTime;

            //if (Mathf.Abs(v) < 0.1f) v = 0;

            transform.Translate(new Vector3(0, 0, v));
            if (!primerMovimiento)
            {
                primerMovimiento = true;
            }
            transform.Rotate(new Vector3(0, h*speed, 0));
            if (!primerGiro)
            {
                primerGiro = true;
            }

            if (!activarTareaPrimera)
            {
                if (primerMovimiento && primerGiro)
                {
                    manager.CumplirTarea(13);
                    activarTareaPrimera = true;
                }
            }
            
        }


    }

    public void RevisarPlaca()
    {
        manager.CumplirTarea(11);
        boton.SetActive(false);
        placa.SetActive(false);
    }

    public void ActivarPlaca()
    {
        if (!primera)
        {
            StartCoroutine(ActivarBoton());
            primera = true;
        }
        
    }

    IEnumerator ActivarBoton()
    {
        placa.SetActive(true);
        yield return new WaitForSeconds(4f);
        boton.SetActive(true);
    }
}

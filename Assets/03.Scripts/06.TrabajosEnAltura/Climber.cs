using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private Movement movement;
    public bool puedeEscalar;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (climbingHand && puedeEscalar)
        {
            movement.enabled = false;
            Debug.Log("escalada");
            Climb();
        }
        else
        {
            movement.enabled = true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }

    public void Escalar(bool puede)
    {
        puedeEscalar = puede;
    }
}

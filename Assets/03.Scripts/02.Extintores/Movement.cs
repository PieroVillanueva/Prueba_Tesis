using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Movement : MonoBehaviour
{
    public float speed = 1;
    private XRRig rig;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float groundDiv = 1.0f;

    public float additionalHeight = 0.2f;
    public float fallingSpeed;
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController character;

    public MeshRenderer sphereEvents;
    public bool Warning = false;
    public float sinv;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
        StartCoroutine(TransitionLvlOut());
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);    
        
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(Time.deltaTime * speed * direction);

        bool isGrounded = CheckIfGrounded();
        if (isGrounded)        
            fallingSpeed = 0;
        else      
            fallingSpeed += gravity * Time.deltaTime;

        character.Move(fallingSpeed * Time.deltaTime * Vector3.up);
    }

    void CapsuleFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }
    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLenght = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius / groundDiv, Vector3.down, out RaycastHit hitInfo, rayLenght, groundLayer);
        return hasHit;
    }
    public void llamarTransitionIn()
    {
        StartCoroutine(TransitionLvlIn());
    }
    public void llamarTransitionOut()
    {
        StartCoroutine(TransitionLvlOut());
    }

    IEnumerator TransitionLvlIn()
    {
        sphereEvents.gameObject.SetActive(true);
        //in
        Material Materialcolor = sphereEvents.material;
        Materialcolor.color = new Color(0, 0, 0, 0);
        //black
        for (float i = 0; i <= 1; i += 0.2f)
        {            
            Color mat = Materialcolor.color;
            mat.a = i;
            Materialcolor.color = mat;
            yield return new WaitForSeconds(0.1f);
        }
        Materialcolor.color = Color.black;
    }

    IEnumerator TransitionLvlOut()
    {
        sphereEvents.gameObject.SetActive(true);
        Material Materialcolor = sphereEvents.material;
        Materialcolor.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        //out
        for (float i = 1; i >= 0; i -= 0.2f)
        {
            Color mat = Materialcolor.color;
            mat.a = i;
            Materialcolor.color = mat;
            yield return new WaitForSeconds(0.1f);
        }
        Color mf = Materialcolor.color;
        mf.a = 0;
        Materialcolor.color = mf;
        sphereEvents.gameObject.SetActive(false);
    }

    IEnumerator WarningEffect()
    {
        sphereEvents.gameObject.SetActive(true);
        Material materialColor = sphereEvents.material;
        materialColor.color = new Color(1, 0, 0, 0);
        //rojo
        while (Warning == true)
        {
            Color mat = materialColor.color;
            sinv = 0.35f + Mathf.PingPong(Time.time / 2, 0.5f);
            mat.a = sinv;
            materialColor.color = mat;
            yield return new WaitForSeconds(0.02f);
        }
        sphereEvents.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("warning"))
        {
            Warning = true;
            StartCoroutine(WarningEffect());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("warning"))
        {
            Warning = false;
        }
    }

    public void Gravedad(float valor)
    {
        gravity = valor;
        
    }
    public void Velocidad(float velocidad)
    {
        speed = velocidad;
    }

    public float VelocidadCaida()
    {
        return fallingSpeed;
    }

}

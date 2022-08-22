using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Press : MonoBehaviour
{
    //public SkinnedMeshRenderer rend;
    public Control_Plataforma ctrl;
    //public GameObject r_hand;
    //public GameObject l_hand;
    public int nB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onPress(int nboton)
    {
        ctrl.on_press = true;
        ctrl.press(nboton);
    }
    public void OnPressExit(int nboton)
    {
        ctrl.on_press = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "indiceL" || other.name == "indiceD")
        {
            ctrl.on_press = true;
            ctrl.press(nB);
            Debug.Log("boton detecta " + other.name + " entrando");
            /*if (other.name == "Left hand")
            {
                rend = GameObject.Find("hands:Lhand").GetComponent<SkinnedMeshRenderer>();
            }
            else
            {
                if (other.name == "Right hand")
                {
                    rend = GameObject.Find("hands:Rhand").GetComponent<SkinnedMeshRenderer>();
                }
            }
            l_hand.SetActive(true);
            rend.enabled = false;*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "indiceL" || other.name == "indiceD")
        {
            ctrl.on_press = false;
            dejar_Pres();
            Debug.Log("boton detecta " + other.name + " saliendo");
            Debug.Log("boton detecta " + other.name + " entrando");
            /*if (other.name == "Left hand")
            {
                rend = GameObject.Find("hands:Lhand").GetComponent<SkinnedMeshRenderer>();
            }
            else
            {
                if (other.name == "Right hand")
                {
                    rend = GameObject.Find("hands:Rhand").GetComponent<SkinnedMeshRenderer>();
                }
            }
            l_hand.SetActive(false);
            rend.enabled = true;*/
        }
    }
    public void dejar_Pres()
    {
        ctrl.Invoke("No_press", 0);
        Debug.Log("no presiona");
    }
}
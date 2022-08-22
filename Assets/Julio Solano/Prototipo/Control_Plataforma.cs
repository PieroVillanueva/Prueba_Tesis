using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Plataforma : MonoBehaviour
{
    public GameObject p_i;
    public GameObject full;
    public GameObject i_izq;
    public GameObject i_der;
    public Vector3 movex;
    public Vector3 movez;
    public Transform LimitX1;
    public Transform LimitX2;
    public Transform LimitZ1;
    public Transform LimitZ2;
    public bool on_press;
    //public int nBoton;
    public IEnumerator move1;
    public IEnumerator move2;
    public IEnumerator move3;
    public IEnumerator move4;
    public float velocidad;
    bool mano_derecha;

    // Start is called before the first frame update
    void Start()
    {
        //i_izq.SetActive(false);
        //i_der.SetActive(false);
        move1 = plat_move(true, -1);
        move2 = plat_move(true, 1);
        move3 = plat_move(false, -1);
        move4 = plat_move(false, 1);

    }
public void press(int nB)
{
    //on_press = true;
    Debug.Log("presiono " + nB);
    switch (nB)
    {
        case -1:
                if (p_i.transform.localPosition.x >= LimitX1.transform.localPosition.x)
                {
                    StartCoroutine(move1);
                    Debug.Log("Hacia la Izquierda");
                }
                else
                {
                    Debug.Log("Limite1 en x alcanzado");
                    No_press();
                }
                 break;

        case 1: StartCoroutine(move2); Debug.Log("Hacia la Derecha"); break;
            case 2: StartCoroutine(move3); Debug.Log("Hacia adelante"); break;
            case 3: StartCoroutine(move4); Debug.Log("Hacia atras"); break;

        }

}
IEnumerator plat_move(bool en_x, int dir)
{
    /*if (en_x == true)
    {
        p_i.transform.localPosition += movex * dir * velocidad * 0.1f; Debug.Log("enX");
            yield return new WaitForSeconds(.1f);
            if (dir < 0) { StartCoroutine(move1); } else { if(dir>0)StartCoroutine(move2); }
            yield return new WaitForSeconds(.1f);

        }*/
    while (on_press == true)
    {
        if (en_x == true)
            {
                
                p_i.transform.localPosition += movex * dir * velocidad * 0.1f; Debug.Log("enX");
                yield return new WaitForSeconds(0.01f);
                if (dir < 0) { StartCoroutine(move1); } else { if (dir > 0) StartCoroutine(move2); }
                yield return new WaitForSeconds(0.01f);
              
            }
        else
        {
            full.transform.localPosition += movez * dir*velocidad * 0.1f; Debug.Log("enZ"); ;
                yield return new WaitForSeconds(0.01f);
                if (dir < 0) { StartCoroutine(move3); } else { if (dir > 0) StartCoroutine(move4); }
                yield return new WaitForSeconds(0.01f);

            }

        //yield return new WaitForSeconds(1f);
        /*if (on_press == false)
        {
            break;
        }*/
    }
}
public void No_press()
{
    //StopAllCoroutines();
    Debug.Log("deteniendo coroutines");
    StopCoroutine(move1);
    StopCoroutine(move2);
        StopCoroutine(move3);
        StopCoroutine(move4);
        //nB = 0;
    }
    /*private void OnTriggerEnter(Collider other)
    {

        if(other.name == "Left hand") { mano_derecha = true; }
        if (other.name == "Right hand") { mano_derecha = false; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Left hand"|| other.name == "Right hand") { i_der.SetActive(false); i_izq.SetActive(false); }
        
    }
    public void agarre_derecha(bool indice)
    {
        if(indice)
        i_der.SetActive(indice);
        i_izq.SetActive(indice);
    }*/
}
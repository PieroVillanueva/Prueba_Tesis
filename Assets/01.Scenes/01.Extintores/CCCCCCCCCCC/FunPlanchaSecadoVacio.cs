using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPlanchaSecadoVacio : MonoBehaviour
{
    public float alturaMinima;
    public float alturaMaxima;
    public float altura;
    public bool movimiento=true;
    public BoxCollider colision;
    public GameObject aviso;

    // Start is called before the first frame update
    void Start()
    {
        /**/       
        if (movimiento)
        {
            llamarBajar();
            //StartCoroutine(a());
        }
       
    }

    /**/
    IEnumerator a()
    {
        yield return new WaitForSeconds(4f);
        if (movimiento)
        {
            llamarSubir();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        altura = gameObject.transform.localPosition.y;
    }
    
    public void llamarBajar() => StartCoroutine(mover(false));
    public void llamarSubir() => StartCoroutine(mover(true));

    IEnumerator mover(bool arriba)
    {
        colision.enabled = !arriba; //si esta bajando se activará la colision sino no
        aviso.SetActive(!arriba);//si esta bajando se activará la imagen
        float nuevoY = 0;
        while(true)
        {
            yield return new WaitForSeconds(0.01f);
            if (arriba)
            {
                nuevoY = gameObject.transform.localPosition.y + 0.0018f;
            }
            else
            {
                nuevoY = gameObject.transform.localPosition.y - 0.0018f;
            }
            nuevoY = Mathf.Clamp(nuevoY, alturaMinima, alturaMaxima);
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, nuevoY, gameObject.transform.localPosition.z);
            if (nuevoY <= alturaMinima || nuevoY >= alturaMaxima)
            {
                break;
            }
        }
        colision.enabled = false;
        aviso.SetActive(false);
    }
}

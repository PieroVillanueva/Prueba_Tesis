using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunObjetoPosInicial : MonoBehaviour
{
    public bool agarrado;
    public Vector3 posicionInicial;
    public Quaternion rotacionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = gameObject.transform.position;
        rotacionInicial= transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void agarrar()
    {
        agarrado = true;
    }
    public void soltar()
    {
        agarrado = false;
        StartCoroutine(volverAlLugar());
    }
    IEnumerator volverAlLugar()
    {
        for (int i = 0; i <150; i++)
        {
            yield return new WaitForSeconds(0.04f);
            if (agarrado)
            {
                break;
            }
            if (i == 14)
            {
                gameObject.transform.position= posicionInicial;
                gameObject.transform.rotation = rotacionInicial;
            }
        }
        
    }



}

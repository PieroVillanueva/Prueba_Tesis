using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunAnimacionUI : MonoBehaviour
{
    //public Transform posInicial;
    //public Transform posFinal;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    IEnumerator InitPanel()
    {
        this.transform.position= posInicial.position;
        this.transform.rotation = posInicial.rotation;
        this.transform.localScale = new Vector3(1, 0, 1);
        yield return new WaitForSeconds(2);      
        
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale += new Vector3(0,0.01f,0);
        }

        yield return new WaitForSeconds(9);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale -= new Vector3(0, 0.01f, 0);
        }

        this.transform.position = posFinal.position;
        this.transform.rotation = posFinal.rotation;

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale += new Vector3(0, 0.01f, 0);
        }
    }
    */
    IEnumerator InitPanel()
    {       
        this.transform.localScale = new Vector3(1, 0, 1);
        yield return new WaitForSeconds(10);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale += new Vector3(0, 0.10f, 0);
        }

        yield return new WaitForSeconds(5);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale -= new Vector3(0, 0.10f, 0);
        }
    }

    public void llamarSiguientePanel()
    {
        StartCoroutine(SiguientePanel());
    }

    IEnumerator SiguientePanel()
    {
        this.transform.localScale = new Vector3(1, 0, 1);
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale += new Vector3(0, 0.1f, 0);
        }

        yield return new WaitForSeconds(3);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            this.transform.localScale -= new Vector3(0, 0.1f, 0);
        }
    }
}

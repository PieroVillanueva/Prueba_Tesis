using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPuertaLevadiza : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadPuerta=3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void LlamarSubida()
    {
        StartCoroutine(subida());
    }
    public virtual void LlamarBajada()
    {
        StartCoroutine(bajada());
    }

    IEnumerator subida()
    {
        Vector3 posicionFinal = new Vector3(transform.position.x, 4.48f, transform.position.z);

        while (Vector3.Distance(transform.position, posicionFinal) != 0)
        {
            yield return new WaitForSeconds(0.0f);
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, Time.deltaTime * velocidadPuerta);
        }
    }
    IEnumerator bajada()
    {
        Vector3 posicionFinal = new Vector3 (transform.position.x, 1.12f, transform.position.z);

        while (Vector3.Distance(transform.position, posicionFinal)!=0)
        {
            yield return new WaitForSeconds(0.0f);
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, Time.deltaTime * velocidadPuerta);
        }
    }
}

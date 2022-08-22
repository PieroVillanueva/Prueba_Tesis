using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunImagenParpadeante : MonoBehaviour
{
    public Image[] imagenes;
    public bool pararBucle;
    public int numeroPos;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Image item in imagenes)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, 0);
        }
    }
    void Update()
    {
      
    }
    public void llamarSgteImagen(int numeroImagen)
    {
        StartCoroutine(siguienteImagen(numeroImagen));
    }
    public void terminarBucle()
    {
        pararBucle = true;
    }
    IEnumerator siguienteImagen(int numeroImagen)
    {
        pararBucle = true;
        yield return new WaitForSeconds(0.1f);
        pararBucle = false;
        //numeroPos++;
        numeroPos = numeroImagen;
        StartCoroutine(cambiarTransperente());
    }

    IEnumerator cambiarTransperente()
    {
        float value;
        imagenes[numeroPos].color = new Color(imagenes[numeroPos].color.r, imagenes[numeroPos].color.g, imagenes[numeroPos].color.b, 1);
        while (!pararBucle)
        {
            value = 0.5f+ Mathf.PingPong(Time.time*0.4f, 0.5f);
            imagenes[numeroPos].color = new Color(imagenes[numeroPos].color.r, imagenes[numeroPos].color.g, imagenes[numeroPos].color.b, value);
            yield return new WaitForSeconds(0.002f);
        }
        imagenes[numeroPos].color = new Color(imagenes[numeroPos].color.r, imagenes[numeroPos].color.g, imagenes[numeroPos].color.b, 1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarFormulario : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> listaFormularios;
    public int indice = 0;
    public int indice2 = 0;
    public AudioClip sonido;
    public AudioSource audioManager;
    public Material material;
    public Texture[] texture;
    public int escena;

    void Start()
    {
        if (escena == 1)
        {
            material.SetTexture("_MainTex", texture[0]);
        }
        if (escena == 2)
        {
            indice = 5;
            material.SetTexture("_MainTex", texture[5]);
            listaFormularios[3].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lapicero"))
        {
            Avanzar();
            audioManager.PlayOneShot(sonido);
        }
        
    }

    public void Avanzar()
    {
        if (indice < texture.Length)
        {
            if (indice != texture.Length - 1)
            {
                indice++;
                material.SetTexture("_MainTex", texture[indice]);
                if (indice == 2)
                {
                    listaFormularios[0].SetActive(true);
                }
                if (indice == 3)
                {
                    listaFormularios[0].SetActive(false);
                    listaFormularios[1].SetActive(true);
                }
                if (indice == 4)
                {
                    listaFormularios[1].SetActive(false);
                    listaFormularios[2].SetActive(true);
                }
                if (indice == 5)
                {
                    listaFormularios[2].SetActive(false);
                    listaFormularios[3].SetActive(true);
                }
                /*if (indice2 > 0)
                {
                    listaFormularios[indice2 - 1].SetActive(false);
                }
                if (indice == 1)
                {
                    listaFormularios[indice2].SetActive(true);
                    indice2++;
                }
                if (indice >= 3)
                {
                    listaFormularios[indice2].SetActive(true);
                    indice2++;
                }*/
            }

        }
        

    }

    public void Retroceder()
    {
        if (indice > 0)
        {
            
            indice--;
            material.SetTexture("_MainTex", texture[indice]);
            listaFormularios[indice2].SetActive(false);
            if (indice == 4)
            {
                listaFormularios[3].SetActive(false);
                listaFormularios[2].SetActive(true);
            }
            if (indice == 3)
            {
                listaFormularios[2].SetActive(false);
                listaFormularios[1].SetActive(true);
            }
            if (indice == 2)
            {
                listaFormularios[1].SetActive(false);
                listaFormularios[0].SetActive(true);
            }
            if(indice == 1)
            {
                listaFormularios[0].SetActive(false);
            }
 


            /*if (indice2 > 0)
            {
                listaFormularios[indice2 - 1].SetActive(false);
            }
            if (indice == 1)
            {
                listaFormularios[indice2 - 1].SetActive(true);
                indice2--;
            }
            if (indice > 3)
            {
                indice2--;
                listaFormularios[indice2 - 1].SetActive(true);
            }*/

        }
    }
}

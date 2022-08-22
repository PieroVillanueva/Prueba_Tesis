using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GanchoPrueba : MonoBehaviour
{
    // Start is called before the first frame update
    public ManagerTA mta;
    public bool en_techo = false;
    public SeguroArnes seguro;
    public BodyFollowHead body;
    public bool enganchado;
    public bool enUso;
    public bool enPosicion;
    public GameObject padre;
    public GameObject posicion;
    public GameObject hijo;
    public GameObject limite;
    public MeshRenderer fresnel;
    public GameObject accidenteTecho;
    public bool accidente;
    public bool engancheTecho;
    public Transform posicionDeslizador;
    public GameObject deslizador;
    Vector3 pos;
    Vector3 rot;
    public SecuenciaAccidente secuencia;

    void Start()
    {
        pos = deslizador.transform.localPosition;
        rot = deslizador.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)//conectar
    {
        //seguro = padre.GetComponent<SeguroArnes>();
        if (other.CompareTag("Candado"))
        {
            padre = other.gameObject;
            seguro = padre.GetComponent<SeguroArnes>();
            fresnel = padre.GetComponent<MeshRenderer>();
            fresnel.material.SetFloat("_EMISSION", 1);
            if (enganchado||mta.actualTarea>=7)
            {
                posicion = GameObject.Find(padre.name + "/posicion1");
                hijo = GameObject.Find(posicion.name + "/deslizador_vertical");
                if (hijo == null)
                {
                    limite.SetActive(true);
                    seguro.Emparentar();
                    seguro.NoGravedad();
                    seguro.NoSpeed();
                    body.Enganchado(true);
                    accidenteTecho.SetActive(false);
                    enUso = true;
                    secuencia.seguro = seguro;
                    secuencia.enganchado = true;
                    secuencia.defectuoso = seguro.defectuoso;
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Candado"))
        {
            fresnel.material.SetFloat("_EMISSION", 0);
            seguro = null;
            padre = null;
            posicion = null;
        }
        
    }

    public void EnUso()//desconectar
    {
        if (enUso)
        {
            limite.SetActive(false);
            seguro.Desemparentar();
            seguro.Gravedad();
            seguro.Speed();
            body.Enganchado(false);
            enUso = false;//emparentado gancho - mosqueton
            enganchado = false;//si en deslizador con mosqueton
            fresnel.material.SetFloat("_EMISSION", 0);
            secuencia.seguro = null;
            secuencia.enganchado = false;
            if (engancheTecho||en_techo==true)//gancho del techo , en los laterales
            {
                deslizador.transform.position = posicionDeslizador.position;
            }
        }
    }

    public void Enganchado(bool valor1)
    {
        enganchado = valor1;
    }
    public void EncontrarPadre(GameObject obj)
    {
        padre = obj;
    }

    public void Uso(bool valor)
    {
        enUso = valor;
    }
    public void Accidente(bool accident)
    {
        accidente = accident;
    }
    public void repos()
    {
        if (enUso == false)
        {
            deslizador.transform.localPosition = pos;
            deslizador.transform.localEulerAngles = rot;
        }
    }    
}

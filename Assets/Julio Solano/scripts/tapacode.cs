using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapacode : MonoBehaviour
{
    public GameObject tapa1;
    public Vector3 moveTapa;
    public Vector3 pos0;
    public float contador;
    public float velocidad;
    //public float tiempo;
    public float l1, l2;
    bool alto = true;
    //Transform.position pos1;
    // Start is called before the first frame update
    void Start()
    {
       //Vector3 pos0 = new Vector3();
        pos0= tapa1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (G_Manager.gm.go_operario == true)
        {
            this.transform.localRotation = Quaternion.Euler(10, -90, 90);
            Debug.Log("me abro");
        }
        if (alto==false)
        {


            if (this.name == "pasted__door 1" && tapa1.transform.position != pos0)
            {
                G_Manager.gm.tapa_open = true;
            }
            if (this.name == "tapa_ducto" && G_Manager.gm.tapa_open == false)
            {
                contador += Time.deltaTime * velocidad;
                this.transform.localRotation = Quaternion.Euler(-90 + contador, -90 , 90 );
                if (contador >= l1)
                {
                    G_Manager.gm.tapa_open = true;
                    alto = true;
                    
                }


            }


            if (G_Manager.gm.n_etapa == 2)
            {



                if (this.name == "tapa_ducto" && G_Manager.gm.tapa_open == false)
                {
                    contador += Time.deltaTime * velocidad;
                    this.transform.localRotation = Quaternion.Euler(-90 + contador, -90, 90);
                    if (contador >= l2)
                    {
                        G_Manager.gm.tapa_open = true;
                        alto = true;

                    }


                }
            }
        }
    }
    public void estado_tapa()
    {
        alto = false;
        //string tapae;
        //Debug.Log("tapa : " + tapae);
        if (G_Manager.gm.n_etapa == 1)
        {
            if (G_Manager.gm.si_abierto_tapa == false)
            {
                if (this.name == "pasted__door 1") { tapa1.transform.position += moveTapa; }

                //tapae = "semi-abierta";
                G_Manager.gm.si_abierto_tapa = true;

            }
        }else
        {
            l1 = l2;
            if (this.name == "pasted__door 1") { tapa1.transform.position = pos0; }
            //G_Manager.gm.tapa_open = false;
            //tapae = "abierta";
            G_Manager.gm.si_abierto_tapa = true;
        }
        

    }
}

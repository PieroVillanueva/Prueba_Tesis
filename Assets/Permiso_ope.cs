using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permiso_ope : MonoBehaviour
{
    public GameObject aa;
    public GameObject an;
    public MeshRenderer mr;
    public Collider mc;
    public Animator op;
    public Transform[] pos;
    public Vector3 pos0;
    public Vector3 rot0;
    public GameObject text;
    bool activar_coru = false;
    // Start is called before the first frame update
    void Start()
    {
        pos0=op.transform.position;
        rot0 = op.transform.localEulerAngles;
        mr = this.GetComponent<MeshRenderer>();
        mc = this.GetComponent<Collider>();
    }
    public void permiso_activo()
    {
        //text.SetActive(false);
       /* mr.enabled = false;
        mc.enabled = false;*/
        G_Manager.gm.ya_permiso = true;
        G_Manager.gm.go_operario = true;
        G_Manager.gm.cuerda_spawn.SetActive(false);
        if (activar_coru == false) {
            StartCoroutine(a_o());
        }
        
        
        //this.gameObject.SetActive(false);
        
    }
    IEnumerator s_o()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSeconds(0.5f);
        op.SetTrigger("subir_escalera");
        yield return new WaitForSeconds(0.2f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.5f);
        player.StartCoroutine("TransitionLvlOut");
        activar_an();
        op.transform.position = pos0;
        op.transform.localEulerAngles = rot0;
        //this.gameObject.SetActive(false);
    }

    IEnumerator a_o()
    {
        
        activar_coru = true;
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSeconds(0.5f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.5f);
        player.StartCoroutine("TransitionLvlOut");
        verificar_arnes();
        op.transform.position = pos[0].position;
        op.transform.localRotation = pos[0].localRotation;
        yield return new WaitForSeconds(1.5f);
        
        op.SetTrigger("caminata");
        while (Vector3.Distance(op.transform.position, pos[1].position)!=0) //
        {
            op.transform.position = Vector3.MoveTowards(op.transform.position, pos[1].position, Time.deltaTime * 0.9f);
            yield return new WaitForFixedUpdate();
            
            if(Vector3.Distance(op.transform.position, pos[1].position) <= 0.6f)
            {
                if (G_Manager.gm.todo_equip == true)
                {
                    yield return new WaitForSeconds(.05f);
                    op.SetTrigger("colocar_guia");
                    yield return new WaitForSeconds(1.1f);
                    player.StartCoroutine("TransitionLvlIn");
                    break;
                }
                player.StartCoroutine("TransitionLvlIn");
            }
        }
        
        yield return new WaitForSeconds(1.5f);
        op.transform.position = pos[2].position;
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(0.2f);
        
        
        //op.transform.localRotation = pos[2].localRotation;
        if (G_Manager.gm.si_accidente == true)
        {
            op.SetTrigger("caida");
        }
        else { op.SetTrigger("bajar_escalera");
        }
        yield return new WaitForSeconds(0.5f);
        
        player.StartCoroutine("TransitionLvlIn");
        
        yield return new WaitForSeconds(1.5f);
        G_Manager.gm.despues_anim = true;
        player.StartCoroutine("TransitionLvlOut");
        
    }
    void verificar_arnes()
    {
        if (an.activeInHierarchy)
        {
            aa.SetActive(true);
            an.SetActive(false);
        }
    }
    void activar_an() {
        if (aa.activeInHierarchy)
        {
            an.SetActive(true);
            aa.SetActive(false);
        }
    }
}

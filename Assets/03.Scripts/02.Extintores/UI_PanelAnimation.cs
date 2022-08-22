using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PanelAnimation : MonoBehaviour
{
    [SerializeField] Image I_BGPanel;
    [SerializeField] Text T_titulo;
    [SerializeField] GameObject[] Rptas;

    void OnEnable()
    {
        StartCoroutine(AnimationCoroutine());
    }
    // Update is called once per frame
    
    IEnumerator AnimationCoroutine()
    {
        StartCoroutine(DeactiveObjs_Rptas());
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(AnimationOpacity_Image(I_BGPanel));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AnimationOpacity_Text(T_titulo));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AnimationOpacity_Rptas(Rptas));
    }

    IEnumerator AnimationOpacity_Image(Image obj)
    {
        Color a_color = obj.color;        
        for(float i = 0; i <= 1; i += 0.1f)
        {
            a_color.a = i;
            obj.color = a_color;
            yield return new WaitForFixedUpdate();
        }
        a_color.a = 1;
        obj.color = a_color;
    }

    IEnumerator AnimationOpacity_Text(Text obj)
    {
        Color a_color = obj.color;        
        for (float i = 0; i <= 1; i += 0.1f)
        {
            a_color.a = i;
            obj.color = a_color;
            yield return new WaitForFixedUpdate();
        }
        a_color.a = 1;
        obj.color = a_color;
    }

    IEnumerator AnimationOpacity_Rptas(GameObject[] obj)
    {        
        for(int i = 0; i < obj.Length;i++) 
        {
            Image i_bgText = obj[i].transform.Find("Name").GetComponent<Image>();
            StartCoroutine(AnimationOpacity_Image(i_bgText));
            Text t_text = obj[i].transform.Find("Name/Text").GetComponent<Text>();
            StartCoroutine(AnimationOpacity_Text(t_text));
            yield return new WaitForSeconds(0.1f);
            GameObject g_obj = obj[i].transform.Find("SpawnPoint").gameObject;
            obj[i].GetComponent<Collider>().enabled = true;
            g_obj.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator DeactiveObjs_Rptas()
    {
        I_BGPanel.color= new Color(I_BGPanel.color.r, I_BGPanel.color.g, I_BGPanel.color.b, 0);
        T_titulo.color= new Color(T_titulo.color.r, T_titulo.color.g, T_titulo.color.b, 0);
        for (int i = 0; i < Rptas.Length; i++)
        {
            Rptas[i].GetComponent<Collider>().enabled = false;
            GameObject g_obj = Rptas[i].transform.Find("SpawnPoint").gameObject;
            g_obj.SetActive(false);
            Image i_bgText = Rptas[i].transform.Find("Name").GetComponent<Image>();
            i_bgText.color = new Color(i_bgText.color.r, i_bgText.color.g, i_bgText.color.b, 0);
            Text t_text = Rptas[i].transform.Find("Name/Text").GetComponent<Text>();
            t_text.color = new Color(t_text.color.r, t_text.color.g, t_text.color.b, 0);
        }
        yield return null;
    }
}

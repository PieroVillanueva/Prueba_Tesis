using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISelector : MonoBehaviour
{
    [Header("Center Value")]
    public int centerValue;

    [Header("Resources")]
    public Sprite[] Bg_lvl;
    public Sprite[] Ico_lvl;
    public string[] niveles;
    
    [Header("UISlector")]
    public Image Ico_center;
    public Image[] BG_center;
    public Text Text_center;

    [Header("UIControl")]
    public GameObject p_menu;
    public GameObject p_seleccion;

    [Header("Tutorial")]
    public Transform SpawnPos;
    public GameObject extExample;
    
    // Start is called before the first frame update
    void Start()
    {
        ReloadPanel();
        //StartMenuUI(GameManager.instance.isInitilize);
        //GameManager.instance.completeLvl = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LRButton(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LRButton(1);
        }
    }
    void ReloadPanel()
    {
        Text_center.text = niveles[corregirValor(centerValue)];
        Ico_center.sprite = Ico_lvl[corregirValor(centerValue)];
        BG_center[0].sprite = Bg_lvl[corregirValor(centerValue - 1)];
        BG_center[1].sprite = Bg_lvl[corregirValor(centerValue)];
        BG_center[2].sprite = Bg_lvl[corregirValor(centerValue + 1)];
    }

    int corregirValor(int value)
    {
        if (value < 0) value = niveles.Length - 1;
        if (value > niveles.Length - 1) value = 0;
        return value;
    }

    public void IsUsedMenu(bool value)
    {
        //GameManager.instance.isInitilize = value;
    }

    void StartMenuUI(bool value)
    {
        p_menu.SetActive(!value);
        p_seleccion.SetActive(value);
    }

    public void LRButton(int value)
    {
        centerValue = value > 0 ? centerValue + 1 : centerValue - 1;
        if (centerValue < 0) centerValue = niveles.Length - 1;
        if (centerValue > niveles.Length-1) centerValue = 0;
        ReloadPanel();
    }

    public void SpawnExt()
    {
        //GameObject newObj = Instantiate(extExample);
        //newObj.transform.position = SpawnPos.position;
        extExample.SetActive(true);
    }

    public void SelectScene()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        player.StartCoroutine("TransitionLvlIn");
        StartCoroutine(endTransiion());
    }
    IEnumerator endTransiion()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(centerValue + 1, LoadSceneMode.Single);
    }
}

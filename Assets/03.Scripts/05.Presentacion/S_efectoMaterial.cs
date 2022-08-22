using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_efectoMaterial : MonoBehaviour
{
    MeshRenderer mesh;
    public bool OnBall=false;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            LightEffect();
        }
    }
    public void LightEffect()
    {
        OnBall = !OnBall;
        LightBall(OnBall);
    }
    void LightBall(bool On)
    {
        if (On == true)
        {
            mesh.material.EnableKeyword("_EMISSION");
        }
        else
        {
            mesh.material.DisableKeyword("_EMISSION");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_cable : MonoBehaviour
{
    public LineRenderer cable_rend;
    public Transform[] positionNodes;
    // Start is called before the first frame update
    void Start()
    {
        cable_rend.positionCount = positionNodes.Length;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0; i < positionNodes.Length; i++)
        {
            cable_rend.SetPosition(i, positionNodes[i].position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterLine : MonoBehaviour
{
    public LineRenderer line;
    public Transform t1;
    public Transform t2;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, t1.position);
        line.SetPosition(1, t2.position);
        
    }
}

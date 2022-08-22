using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class lineslerp : MonoBehaviour
{
    [SerializeField] private Transform _start, _center, _end;
    [Range(0, 100)]
    [SerializeField] private int _count = 15;

    Vector3[] points;

    public LineRenderer linea;
    /*private void OnDrawGizmos()
    {
        //linea.positionCount = _count +1;
        foreach (var point in EvaluateSlerpPoints(_start.position, _end.position, _center.position, _count))
        {
            Gizmos.DrawSphere(point, 0.05f);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_center.position, 0.05f);
    }*/

    IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center, int count = 10)
    {
        var startRelativeCenter = start - center;
        var endRelativeCenter = end - center;

        var f = 1f / count;

        int v = 0;
        for (var i = 0f; i < 1 + f; i += f)
        {
            //linea.SetPosition(v, Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center);
            yield return Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center;
            //Debug.Log(v);
            //v++;
            //linea.SetPosition(i*10, Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center);
        }
    }
    private void Start()
    {
        linea.positionCount = _count+1;
    }

    private void Update()
    {
        points = EvaluateSlerpPoints(_start.position, _end.position, _center.position, _count).ToArray();
        linea.SetPositions(points);
    }
}
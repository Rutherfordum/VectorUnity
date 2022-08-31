using System;
using UnityEngine;

[ExecuteAlways]
public class BezierFourPoint : MonoBehaviour
{
    public Transform P0 => p0;
    public Transform P1 => p1;
    public Transform P2 => p2;
    public Transform P3 => p3;

    public float T
    {
        get => t;
        set { t = (!(value < 0 || value > 1)) ?
            value : throw new Exception("T cannot be less than zero or greater than one"); }
    }

    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    
    [Range(0,1)]
    [SerializeField] private float t = 0;

    private void Update()
    {
        transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, T);
        transform.rotation = Quaternion.LookRotation(Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, T));
    }

    private void OnDrawGizmos()
    {
        int segmentsNumber = 20;
        Vector3 prevPoint = P0.position;

        for (int i = 0; i < segmentsNumber+1; i++)
        {
            float parameter = (float) i / segmentsNumber;
            Vector3 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, parameter);
            Gizmos.DrawLine(prevPoint,point);
            prevPoint = point;
        }
    }
}

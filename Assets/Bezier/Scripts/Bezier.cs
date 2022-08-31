using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    //P = ((1−t)^3)*P0 + 3*((1−t)^2)*t*P1 +3*(1−t)*(t^2)*P2 + (t^3)*P3
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float OneMinesT = 1f - t;
        return
            Mathf.Pow(OneMinesT, 3) * p0 +
            3 * Mathf.Pow(OneMinesT, 2) * t * p1 +
            3 * OneMinesT * Mathf.Pow(t, 2) * p2 +
            Mathf.Pow(t, 3) * p3;
    }

    // производная от GetPoint, чтобы получить направление на кривой 
    public static Vector3 GetDirection(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float OneMinesT = 1f - t;
        return
            3f * Mathf.Pow(OneMinesT, 2) * (p1 - p0) +
            6f * OneMinesT * t * (p2 - p1) +
            3f * Mathf.Pow(t, 2) * (p3 - p2);

    }
}

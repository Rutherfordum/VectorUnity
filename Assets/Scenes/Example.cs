using UnityEngine;

[ExecuteAlways]
public class Example : MonoBehaviour
{
    public float MoveValue;
    public float Speed;
    public float Radius;


    void Update()
    {
        MoveValue += Time.deltaTime * Speed;
        float x = Mathf.Sin(MoveValue) * Radius;
        float y = Mathf.Cos(MoveValue) * Radius;

        transform.position = new Vector3(x, y, 0);
    }
}

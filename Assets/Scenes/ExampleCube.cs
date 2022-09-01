using UnityEngine;

[ExecuteAlways]
public class ExampleCube : MonoBehaviour, IPooledObject
{
    public float MoveValue;
    public float Speed;
    public float Radius;

    public void OnSpawn()
    {
        Radius += 0.1f;
    }

    void Update()
    {
        MoveValue += Time.deltaTime * Speed;
        float x = Mathf.Sin(MoveValue) * Radius;
        float y = Mathf.Cos(MoveValue) * Radius;

        transform.position = new Vector3(x, y, 0);
    }
}

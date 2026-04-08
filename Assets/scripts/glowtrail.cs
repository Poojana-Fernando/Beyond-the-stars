using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailOnMove : MonoBehaviour
{
    public float minSpeed = 0.05f;

    TrailRenderer tr;
    Vector3 lastPos;

    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        lastPos = transform.position;
    }

    void Update()
    {
        float speed = (transform.position - lastPos).magnitude / Mathf.Max(Time.deltaTime, 0.0001f);
        tr.emitting = speed > minSpeed;
        lastPos = transform.position;
    }
}
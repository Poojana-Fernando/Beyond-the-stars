using UnityEngine;

public class NoisyWiggle2D : MonoBehaviour
{
    [Header("Movement")]
    public float radius = 0.5f;      // how far it can wander
    public float speed = 1.2f;       // how fast it wiggles

    [Header("Rotation (optional)")]
    public bool rotateToDirection = true;
    public float rotLerp = 10f;

    Vector3 startPos;
    float seedX, seedY;
    Vector3 lastPos;

    void Start()
    {
        startPos = transform.position;
        seedX = Random.Range(0f, 1000f);
        seedY = Random.Range(0f, 1000f);
        lastPos = transform.position;
    }

    void Update()
    {
        float t = Time.time * speed;

        float nx = Mathf.PerlinNoise(seedX, t) * 2f - 1f;
        float ny = Mathf.PerlinNoise(seedY, t) * 2f - 1f;

        Vector3 offset = new Vector3(nx, ny, 0f) * radius;
        Vector3 target = startPos + offset;

        transform.position = target;

        if (rotateToDirection)
        {
            Vector3 delta = transform.position - lastPos;
            if (delta.sqrMagnitude > 0.00001f)
            {
                float ang = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.Euler(0, 0, ang);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, rotLerp * Time.deltaTime);
            }
            lastPos = transform.position;
        }
    }
}
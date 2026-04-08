using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class BarrierLine : MonoBehaviour
{
    LineRenderer line;
    EdgeCollider2D edge;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        edge = GetComponent<EdgeCollider2D>();
        UpdateCollider();
    }

    void UpdateCollider()
    {
        Vector3[] positions = new Vector3[line.positionCount];
        line.GetPositions(positions);

        Vector2[] points = new Vector2[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            points[i] = positions[i];
        }

        edge.points = points;
    }
}
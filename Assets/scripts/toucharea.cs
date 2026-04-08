using UnityEngine;
using UnityEngine.EventSystems;

public class InvisibleJoystickArea : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Header("Output")]
    public Vector2 Input; // -1..1

    [Header("Tuning")]
    public float radius = 120f; // pixels (drag distance for full input)

    private Vector2 startPos;
    private bool dragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        startPos = eventData.position;
        Input = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging) return;

        Vector2 delta = eventData.position - startPos;

        // clamp to radius
        Vector2 clamped = Vector2.ClampMagnitude(delta, radius);

        // normalize to -1..1
        Input = clamped / radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        Input = Vector2.zero;
    }

}
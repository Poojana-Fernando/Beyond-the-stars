using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ButterflyRightJoystickMove : MonoBehaviour
{
    public InvisibleJoystickArea rightArea;
    public float speed = 4f;

    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void FixedUpdate()
{
    Vector2 input = rightArea.Input;

    // Move the butterfly
    rb.linearVelocity = input * speed;

    // Flip the butterfly based on horizontal movement
    if (input.x > 0)
        transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
    else if (input.x < 0)
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
}
}
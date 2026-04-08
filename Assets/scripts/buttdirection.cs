using UnityEngine;

public class ButterflyDirection : MonoBehaviour
{
    public InvisibleJoystickArea joystick;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (joystick == null) return;

        float moveX = joystick.Input.x;

        if (Mathf.Abs(moveX) < 0.1f)
            return;

        // Flip based on direction
        if (moveX > 0)
            sr.flipX = false;
        else
            sr.flipX = true;
    }
}
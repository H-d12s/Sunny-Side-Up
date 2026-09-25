using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            horizontal -= 1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            horizontal += 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            vertical -= 1f;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            vertical += 1f;
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}

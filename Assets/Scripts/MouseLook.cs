using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float minPitch = -80f;
    [SerializeField] private float maxPitch = 80f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Vector3 currentEuler = transform.eulerAngles;
        yaw = currentEuler.y;
        pitch = currentEuler.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Mouse mouse = Mouse.current;
        if (mouse == null) return;

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (mouse.leftButton.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            return;
        }

        Vector2 delta = mouse.delta.ReadValue();

        yaw += delta.x * mouseSensitivity * Time.deltaTime;
        pitch -= delta.y * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}

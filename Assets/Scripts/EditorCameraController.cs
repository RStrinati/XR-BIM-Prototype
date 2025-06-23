
using UnityEngine;

/// <summary>
/// Allows movement in the Unity Editor using WASD and mouse look.
/// Attach this to the XR Origin (Mobile AR) object for simulating movement.
/// </summary>
public class EditorCameraController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float lookSpeed = 2.0f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        if (!Application.isEditor) return;

        // Movement
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S
        Vector3 move = transform.right * h + transform.forward * v;
        transform.position += move * moveSpeed * Time.deltaTime;

        // Mouse Look (Right-click to rotate view)
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * lookSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f);

            transform.eulerAngles = new Vector3(0, rotationX, 0);
            Camera.main.transform.localEulerAngles = new Vector3(rotationY, 0, 0);
        }
    }
}

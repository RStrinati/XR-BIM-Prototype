using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Measures tracking drift between the AR camera and a known anchor.
/// Displays a warning GameObject if the distance exceeds the threshold.
/// </summary>
public class DriftMonitor : MonoBehaviour
{
    [Tooltip("ARAnchor defining the reference position.")]
    public ARAnchor anchor;

    [Tooltip("UI GameObject to activate when drift is detected.")]
    public GameObject warningUI;

    [Tooltip("Maximum allowed drift in meters before showing the warning.")]
    public float driftThreshold = 0.1f; // 10 cm

    Camera arCamera;

    void Start()
    {
        // Fallback to the main camera if not explicitly set
        arCamera = Camera.main;
        if (warningUI != null)
        {
            warningUI.SetActive(false);
        }
    }

    void Update()
    {
        if (anchor == null || arCamera == null)
            return;

        float distance = Vector3.Distance(arCamera.transform.position, anchor.transform.position);
        if (warningUI != null)
        {
            warningUI.SetActive(distance > driftThreshold);
        }
    }
}

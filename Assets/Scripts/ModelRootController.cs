using UnityEngine;

public class ModelRootController : MonoBehaviour
{
    [SerializeField]
    private GameObject rootModel;

    /// <summary>
    /// Moves the root model GameObject to the given anchor position while keeping
    /// its current rotation. The model remains correctly aligned with its plan.
    /// </summary>
    /// <param name="anchorPoint">World-space position to place the root model.</param>
    public void MoveModelToAnchor(Vector3 anchorPoint)
    {
        if (rootModel == null)
        {
            Debug.LogWarning("Root model reference not set.");
            return;
        }

        Transform rootTransform = rootModel.transform;
        rootTransform.SetPositionAndRotation(anchorPoint, rootTransform.rotation);
    }
}

using UnityEngine;

public class AutoAddMeshColliders : MonoBehaviour
{
    public GameObject rootModel; // Drag TestProj here in the Inspector

    void Start()
    {
        if (rootModel == null)
        {
            Debug.LogError("Root model not assigned.");
            return;
        }

        int count = 0;

        // Get all MeshRenderers in children
        MeshRenderer[] renderers = rootModel.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mr in renderers)
        {
            GameObject go = mr.gameObject;

            if (go.GetComponent<Collider>() == null)
            {
                MeshCollider mc = go.AddComponent<MeshCollider>();
                mc.convex = false;
                count++;
            }
        }

        Debug.Log($"✅ Added MeshColliders to {count} objects under '{rootModel.name}'");
    }
}

using UnityEngine;

public class ObjectMetadata : MonoBehaviour
{
    public string objectID;
    public string typeName;
    public string fireRating;
    public string issueTag;

    public void ApplyColorBasedOnIssue()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (!renderer) return;

        Color color = Color.gray; // Default for "No Issue"

        switch (issueTag)
        {
            case "Clash":
                color = Color.yellow;
                break;
            case "Misalignment":
                color = Color.red;
                break;
            case "No Issue":
                color = Color.gray;
                break;
        }

        renderer.material.color = color;
    }
}

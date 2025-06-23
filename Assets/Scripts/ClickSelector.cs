using UnityEngine;

public class ClickSelector : MonoBehaviour
{
    public MetadataPanelController ui;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click detected");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                ObjectMetadata meta = hit.collider.GetComponent<ObjectMetadata>();
                if (meta != null)
                {
                    Debug.Log("Metadata found: " + meta.objectID);
                    ui.ShowMetadata(meta);
                }
                else
                {
                    Debug.Log("No metadata on hit object.");
                }
            }
            else
            {
                Debug.Log("Raycast missed");
            }
        }
    }
}

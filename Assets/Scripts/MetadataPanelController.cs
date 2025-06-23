using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MetadataPanelController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject panel;
    public Text idText;
    public Text typeText;
    public Text fireRatingText;
    public TMP_Dropdown issueDropdown;

    private ObjectMetadata currentMetadata;

    void Start()
    {
        panel.SetActive(false);
    }
    
    public void HidePanel()
    {
        panel.SetActive(false);
    }

    public string GetSelectedIssue()
    {
        return issueDropdown.options[issueDropdown.value].text;
    }

    public void ShowMetadata(ObjectMetadata metadata)
    {
        currentMetadata = metadata; // Keep reference
        idText.text = "ID: " + metadata.objectID;
        typeText.text = "Type: " + metadata.typeName;
        fireRatingText.text = "Fire Rating: " + metadata.fireRating;

        // Set dropdown to current value if known
        if (!string.IsNullOrEmpty(metadata.issueTag))
        {
            int index = issueDropdown.options.FindIndex(o => o.text == metadata.issueTag);
            issueDropdown.value = index >= 0 ? index : 0;
        }

        panel.SetActive(true);
    }

    public void SaveTagToMetadata()
    {
        if (currentMetadata == null) return;

        currentMetadata.issueTag = GetSelectedIssue();
        currentMetadata.ApplyColorBasedOnIssue();
    }


}


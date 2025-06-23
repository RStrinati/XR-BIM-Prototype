using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MetadataLoader : MonoBehaviour
{
    [System.Serializable]
    public class Entry
    {
        public string ID;
        public string Type;
        public string FireRating;
    }

    [System.Serializable]
    public class EntryList
    {
        public List<Entry> entries;
    }

    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "metadata.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            EntryList metadata = JsonUtility.FromJson<EntryList>(json);

            foreach (Entry entry in metadata.entries)
            {
                // Look for matching object by name (e.g., Wall_[ID] or Basic Wall [313171])
                foreach (GameObject go in GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
                {
                    if (go.name.Contains(entry.ID))
                    {
                        ObjectMetadata om = go.AddComponent<ObjectMetadata>();
                        om.objectID = entry.ID;
                        om.typeName = entry.Type;
                        om.fireRating = entry.FireRating;

                        Debug.Log($"Bound metadata to {go.name}: {entry.Type}, {entry.FireRating}");
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Metadata file not found: " + path);
        }
    }
}

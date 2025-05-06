using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class ProjectManager : MonoBehaviour
{
    
    public TextMeshProUGUI descriptionText;
    public List<StudentProject> projects;
    

    void Start()
    {
        
        string path = Path.Combine(Application.streamingAssetsPath, "barcode2.json");

        if (File.Exists(path))
        {
            string jsonArray = File.ReadAllText(path).Trim();

            // Ensure proper wrapping
            string wrappedJson = "{ \"projects\": " + jsonArray + " }";

            try
            {
                ProjectWrapper wrapper = JsonUtility.FromJson<ProjectWrapper>(wrappedJson);
                projects = wrapper.projects;
                descriptionText.text = projects[0].description;
                Debug.Log(projects);

                Debug.Log("Loaded " + projects.Count + " projects.");
                Debug.Log("First project title: " + projects[0].project);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to parse JSON: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("JSON file not found at: " + path);
        }
    }
}
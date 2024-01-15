using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class SceneAnalytics : MonoBehaviour
{
    void Start()
    {
        
        string previousSceneName = PlayerPrefs.GetString("PreviousScene", "Unknown");

      
        Analytics.CustomEvent("PreviousScene", new Dictionary<string, object>
        {
          //  { "PreviousScene", previousSceneName },
            { "CurrentScene", SceneManager.GetActiveScene().name }
        });

        
        Debug.Log("Sent PreviousScene analytics event with SceneName: " + previousSceneName + "Now:"+SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class scene_from_input : MonoBehaviour
{
    public InputField inputField;

    public void OpenScene()
    {
        string sceneName = inputField.text;
        SceneManager.LoadScene(sceneName);
    }
}

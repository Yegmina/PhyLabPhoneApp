using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName;

    public void TransitionToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
// просто открытие сцены при нажатии где-то по экрану
public class OpenSceneOnClick : MonoBehaviour
{
    public string sceneName; // Название сцены, которую нужно открыть (настраивается в инспекторе)

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Проверяем, было ли нажатие на экране телефона
			 StartCoroutine(OpenSceneCoroutine());
            OpenScene();
        }
    }

    public void OpenScene()
    {
        // Загружаем указанную сцену
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
	 private System.Collections.IEnumerator OpenSceneCoroutine()
    {
        yield return new WaitForSeconds(0.1f); // Пауза в 0,5 секунды

        // Загружаем указанную сцену
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

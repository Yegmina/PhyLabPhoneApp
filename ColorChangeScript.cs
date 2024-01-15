using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    public float speed = 30f; // швидкість змінення параметра H
    public float currentHue = 0f;
	public float second = 0.4f; //насиченість 
								//де 0 відповідає відсутності насиченості (відтінок відтінюється до відтінку сірого), 
								//а 1 - максимальній насиченості.

    void Update()
    {
        currentHue += speed * Time.deltaTime;

        // з метою запобігання виходу за обмеження [0, 360], використаємо операцію остачі ділення на 360
        currentHue = Mathf.Repeat(currentHue, 360f);

        Color newColor = Color.HSVToRGB(currentHue / 360f, second, 1f);

        
        GetComponent<UnityEngine.UI.Image>().color = newColor;
    }
}

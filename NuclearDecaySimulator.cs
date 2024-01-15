using UnityEngine;
using UnityEngine.UI;

public class NuclearDecaySimulator : MonoBehaviour
{
	public InputField n0InputField;
    public Text n1Text;  // Текстове поле для виводу значення N1
    public Text n2Text;  // Текстове поле для виводу значення N2

    private int n1 = 128;  // початкова кількість монет із гербом вверх
    private int n2 = 0;    // початкова кількість монет із гербом вниз
    public void ReadInputValue()
    {
        if (int.TryParse(n0InputField.text, out n1))
        {
            Debug.Log("Input value: " + n1);
        }
        else
        {
            Debug.LogError("Invalid input value.");
        }
    }
    public void TossCoins()
    {
        int newN1 = 0;
        int newN2 = 0;

        // Підкидуємо монетки для N1 і N2
        for (int i = 0; i < n1; i++)
        {
            if (Random.value < 0.5f)  // З вірогідністю 50% монетка перевертається
                newN2++;
            else
                newN1++;
        }

        // Оновлюємо значення N1 і N2
        n1 = newN1;
        n2 = newN2;

        // Оновлюємо текстові поля
        UpdateTextFields();
    }

    public void RemoveN2Coins()
    {
        n2 = 0;
        UpdateTextFields();
    }

    private void UpdateTextFields()
    {
        n1Text.text = "N1: " + n1.ToString();  // Оновлюємо текстове поле для вивода N1
        n2Text.text = "N2: " + n2.ToString();  // Оновлюємо текстове поле для вивода N2
    }
}

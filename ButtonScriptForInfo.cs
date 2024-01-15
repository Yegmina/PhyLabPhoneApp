using UnityEngine;
using UnityEngine.UI;

public class ButtonScriptForInfo : MonoBehaviour
{
    public Button button;         // Ссылка на кнопку
    public Text buttonText;      // Ссылка на текст кнопки

    private bool firstPress = true;  // Флаг для отслеживания первого нажатия кнопки

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);  // Привязываем метод к событию нажатия кнопки
    }

    private void OnButtonClick()
    {
        if (firstPress)
        {
            buttonText.text = "Знайдіть період обертання та обертову частоту. При натисненні на кнопку для повтору, буде згенерований інший обертовий рух з іншим періодом і обертовою частотою. Зробіть таблицю у зошиті з колонками: \nКількість обертів N; Час руху t;\nПеріод обертання T; Обертова частота n.\nТабличний період обертання та таблична обертова частота. Їх можна отримати після натискання кнопки 'Перевірити розрахунки'. На основі вирахованих і табличних значень можна розрахувати відносну та абсолютну похибки. ";
            firstPress = false;
        }
        else
        {
            buttonText.text = "";
			firstPress = true;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    public InputField inputField;  // Для введення коду
    public Text feedbackText;  // Для виведення зворотного зв'язку

    private string correctCode = "528";  // Правильний код

    // Метод для перевірки коду
    public void CheckCode()
    {
        if (inputField.text == correctCode)
        {
            feedbackText.text = "Код правильний! Двері відкрились.";
            // Тут можна додати код для відкриття дверей
        }
        else
        {
            feedbackText.text = "Неправильний код. Спробуйте ще.";
        }
    }
}

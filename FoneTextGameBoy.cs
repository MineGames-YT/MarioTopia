using UnityEngine;
using TMPro;
using System.Globalization;
using System.Collections;

public class FoneTextGameBoy : MonoBehaviour
{

    public TextMeshProUGUI uiText; // Укажите ваш UI Text здесь
    // public TMP_Text uiText; // Используйте это для TextMeshPro
    public string[] texts; // Массив текстов для отображения
    public float typingSpeed = 0.05f; // Скорость печати
    public float delayBetweenTexts = 2f; // Задержка между текстами

    private void Start()
    {
        StartCoroutine(TypeTexts());
    }

    private IEnumerator TypeTexts()
    {
        while (true) // Бесконечный цикл для повторения текста
        {
            foreach (string text in texts)
            {
                yield return StartCoroutine(TypeText(text));
                yield return new WaitForSeconds(delayBetweenTexts);
            }
        }
    }

    private IEnumerator TypeText(string text)
    {
        uiText.text = ""; // Очищаем текст перед началом печати

        foreach (char letter in text)
        {
            uiText.text += letter; // Добавляем букву к тексту
            yield return new WaitForSeconds(typingSpeed); // Ждем перед добавлением следующей буквы
        }
    }
}

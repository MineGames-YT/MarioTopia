using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSensitivityController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider sensitivitySlider; // Ссылка на ползунок
    private const string SensitivityKey = "MouseSensitivity"; // Ключ для сохранения

    void Start()
    {
        // Загружаем сохраненную чувствительность или устанавливаем по умолчанию
        float savedSensitivity = PlayerPrefs.GetFloat(SensitivityKey, 1f); // 25 - значение по умолчанию
        sensitivitySlider.value = savedSensitivity;
        // Обновляем текст с текущим значением чувствительности
        UpdateSensitivityText(savedSensitivity);
        // Добавляем обработчик события изменения значения ползунка
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    void OnSensitivityChanged(float value)
    {
        // Сохраняем новое значение
        PlayerPrefs.SetFloat(SensitivityKey, value);
        
        // Обновляем текст с текущим значением чувствительности
        UpdateSensitivityText(value);
    }

    void FixedUpdate()
    {
        // Загружаем сохраненную чувствительность или устанавливаем по умолчанию
        float savedSensitivity = PlayerPrefs.GetFloat(SensitivityKey, 1f); // 25 - значение по умолчанию
        sensitivitySlider.value = savedSensitivity;
        // Обновляем текст с текущим значением чувствительности
        UpdateSensitivityText(savedSensitivity);
        // Добавляем обработчик события изменения значения ползунка
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    void UpdateSensitivityText(float sensitivity)
    {
        // Обновляем текстовое поле с текущим значением чувствительности
        if (text != null)
        {
            text.text = " " + sensitivity.ToString("F1"); // Форматируем до одного знака после запятой
        }
    }
}

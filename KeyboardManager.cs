using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public KeyCode StandartKeycode;
    public string playerPrefsName;

    public TextMeshProUGUI currentKeyText; // Перетаскиваем сюда текстовый объект
    public Button rebindButton; // Перетаскиваем сюда кнопку
    public GameObject panelSetRebind;
    public TextMeshProUGUI currentKeyTextInRebind;
    private KeyCode currentKey; // Текущая клавиша
    private bool isRebinding = false; // Флаг для проверки режима переназначения

    private void Start()
    {
        // Загрузка сохраненной клавиши или установка по умолчанию
        currentKey = PlayerPrefs.HasKey(playerPrefsName) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName)) : StandartKeycode;
        UpdateKeyText();

        rebindButton.onClick.AddListener(StartRebinding);
    }

    private void Update()
    {
        if (isRebinding)
        {
            // Проверка нажатия клавиши
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        if (key != KeyCode.Escape) // Если нажата Escape, отменяем
                        {
                            currentKey = key;
                            SaveKey();
                            UpdateKeyText();
                        }
                        UpdateKeyText();
                        isRebinding = false; // Завершаем режим переназначения
                        panelSetRebind.SetActive(false);
                        break;
                    }
                }
            }
        }
    }

    private void StartRebinding()
    {
        isRebinding = true;
        panelSetRebind.SetActive(true);
        currentKeyText.text = " ";
        currentKeyTextInRebind.text = " ";
    }

    private void UpdateKeyText()
    {
        panelSetRebind.SetActive(false);
        currentKeyText.text = currentKey.ToString();
        currentKeyTextInRebind.text = currentKey.ToString();
        currentKey = PlayerPrefs.HasKey(playerPrefsName) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName)) : StandartKeycode;
    }

    private void SaveKey()
    {
        PlayerPrefs.SetString(playerPrefsName, currentKey.ToString());
        PlayerPrefs.Save();
    }
}

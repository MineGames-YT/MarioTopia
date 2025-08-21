using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicSettingsUI : MonoBehaviour
{
    [SerializeField] private Button lowButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button highButton;
    [SerializeField] private Button legendaryButton;
    
    private void Start()
    {
        LoadGraphicsSettings();

        lowButton.onClick.AddListener(() => SetGraphicsQuality(0));
        mediumButton.onClick.AddListener(() => SetGraphicsQuality(1));
        highButton.onClick.AddListener(() => SetGraphicsQuality(2));
        legendaryButton.onClick.AddListener(() => SetGraphicsQuality(3));
        
        // Получаем доступные разрешения
        resolutions = Screen.resolutions;

        // Заполняем Dropdown разрешениями
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.width + " x " + resolution.height);
        }
        resolutionDropdown.AddOptions(options);

        // Устанавливаем начальные значения
        LoadSettings();
    }

    private void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
        PlayerPrefs.Save();
    }

    private void LoadGraphicsSettings()
    {
        int savedQuality = PlayerPrefs.GetInt("GraphicsQuality", 2);
        QualitySettings.SetQualityLevel(savedQuality);
    }
    
    // Ссылки на UI элементы
    public Slider textureQualitySlider;
    public Toggle antiAliasingToggle;
    public Toggle shadowsToggle;
    public Slider shadowQualitySlider;
    public Slider lodSlider;
    public Toggle postProcessingToggle;
    public Slider reflectionQualitySlider;
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    public void LoadSettings()
    {
        // Загружаем настройки из PlayerPrefs (или задаем значения по умолчанию)
        textureQualitySlider.value = PlayerPrefs.GetInt("TextureQuality", 2);
        antiAliasingToggle.isOn = PlayerPrefs.GetInt("AntiAliasing", 0) == 1;
        shadowsToggle.isOn = PlayerPrefs.GetInt("Shadows", 1) == 1;
        shadowQualitySlider.value = PlayerPrefs.GetInt("ShadowQuality", 2);
        lodSlider.value = PlayerPrefs.GetInt("LOD", 2);
        postProcessingToggle.isOn = PlayerPrefs.GetInt("PostProcessing", 1) == 1;
        reflectionQualitySlider.value = PlayerPrefs.GetInt("ReflectionQuality", 2);
        
        // Устанавливаем текущее разрешение
        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = savedResolutionIndex;
    }

    public void SetTextureQuality(float quality)
    {
        QualitySettings.globalTextureMipmapLimit = (int)quality;
        PlayerPrefs.SetInt("TextureQuality", (int)quality);
        PlayerPrefs.Save();
    }

    public void SetAntiAliasing(bool isEnabled)
    {
        QualitySettings.antiAliasing = isEnabled ? 4 : 0; // Пример: 4x AA
        PlayerPrefs.SetInt("AntiAliasing", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetShadows(bool isEnabled)
    {
        QualitySettings.shadows = isEnabled ? ShadowQuality.All : ShadowQuality.Disable;
        PlayerPrefs.SetInt("Shadows", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetShadowQuality(float quality)
    {
        QualitySettings.shadowCascades = (int)quality; // Пример: настройка каскадов теней
        PlayerPrefs.SetInt("ShadowQuality", (int)quality);
        PlayerPrefs.Save();
    }

    public void SetLOD(float lodLevel)
    {
        QualitySettings.lodBias = lodLevel; // Настройка LOD
        PlayerPrefs.SetInt("LOD", (int)lodLevel);
        PlayerPrefs.Save();
    }

    public void SetPostProcessing(bool isEnabled)
    {
        // Включение/выключение постобработки (нужно подключить соответствующий пакет)
        // Например, если вы используете Post Processing Stack v2
        // var postProcessVolume = FindObjectOfType<PostProcessVolume>();
        // postProcessVolume.enabled = isEnabled;

        PlayerPrefs.SetInt("PostProcessing", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetReflectionQuality(float quality)
    {
        QualitySettings.realtimeReflectionProbes = quality > 0; // Пример: настройка отражений
        PlayerPrefs.SetInt("ReflectionQuality", (int)quality);
        PlayerPrefs.Save();
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", index);
        PlayerPrefs.Save();
    }

    public void SaveButtonSettings()
    {
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save(); // Сохраняем настройки при выходе из приложения
    }

}

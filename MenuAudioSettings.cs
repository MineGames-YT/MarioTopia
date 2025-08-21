using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuAudioSettings : MonoBehaviour
{

    private const float DisabledVolume = -80f; // Значение, когда звук отключен
    [SerializeField] private Slider volumeSlider; // Слайдер для регулировки громкости
    [SerializeField] private AudioMixer audioMixer; // Ссылка на AudioMixer
    [SerializeField] private string mixerParameter = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private float minimumVolume = -40f; // Минимальное значение громкости
    public string PlayyerPrefsName;

    private void Start()
    {
        LoadVolumeSettings();
    }

    public void OnVolumeSliderChanged(float volumeValue)
    {
        SetMixerVolume(volumeValue);
        SaveVolumeSettings(volumeValue);
    }

    private void SetMixerVolume(float volumeValue)
    {
        float mixerVolume;
        mixerVolume = Mathf.Lerp(minimumVolume, 0, volumeValue); // Преобразуем значение слайдера в громкость
        if (mixerVolume == -40)
        {
            mixerVolume = -80;
        }

        audioMixer.SetFloat(mixerParameter, mixerVolume);
    }

    private void LoadVolumeSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat(PlayyerPrefsName, 1f); // Загружаем сохраненное значение или устанавливаем по умолчанию
        volumeSlider.SetValueWithoutNotify(savedVolume); // Устанавливаем значение слайдера без уведомления
        SetMixerVolume(savedVolume); // Устанавливаем громкость в AudioMixer
    }

    private void SaveVolumeSettings(float volumeValue)
    {
        PlayerPrefs.SetFloat(PlayyerPrefsName, volumeValue); // Сохраняем текущее значение громкости
        PlayerPrefs.Save(); // Сохраняем изменения
    }
}

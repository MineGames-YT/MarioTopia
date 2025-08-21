using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuAudioSettings : MonoBehaviour
{

    private const float DisabledVolume = -80f; // ��������, ����� ���� ��������
    [SerializeField] private Slider volumeSlider; // ������� ��� ����������� ���������
    [SerializeField] private AudioMixer audioMixer; // ������ �� AudioMixer
    [SerializeField] private string mixerParameter = "MusicInScene"; // �������� � AudioMixer
    [SerializeField] private float minimumVolume = -40f; // ����������� �������� ���������
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
        mixerVolume = Mathf.Lerp(minimumVolume, 0, volumeValue); // ����������� �������� �������� � ���������
        if (mixerVolume == -40)
        {
            mixerVolume = -80;
        }

        audioMixer.SetFloat(mixerParameter, mixerVolume);
    }

    private void LoadVolumeSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat(PlayyerPrefsName, 1f); // ��������� ����������� �������� ��� ������������� �� ���������
        volumeSlider.SetValueWithoutNotify(savedVolume); // ������������� �������� �������� ��� �����������
        SetMixerVolume(savedVolume); // ������������� ��������� � AudioMixer
    }

    private void SaveVolumeSettings(float volumeValue)
    {
        PlayerPrefs.SetFloat(PlayyerPrefsName, volumeValue); // ��������� ������� �������� ���������
        PlayerPrefs.Save(); // ��������� ���������
    }
}

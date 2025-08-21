using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StartSettings : MonoBehaviour
{
    [Space(2)]
    [Header("AudioSettings")]
    [Space(2)]
    public string PlayyerPrefsName1;
    public string PlayyerPrefsName2;
    public string PlayyerPrefsName3;
    public string PlayyerPrefsName4;
    public string PlayyerPrefsName5;
    public string PlayyerPrefsName6;
    public string PlayyerPrefsName7;
    public string PlayyerPrefsName8;
    public string PlayyerPrefsName9;
    public string PlayyerPrefsName10;
    public string PlayyerPrefsName11;
    [SerializeField] private AudioMixer audioMixer; // Ссылка на AudioMixer
    [SerializeField] private string mixerParameter1 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter2 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter3 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter4 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter5 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter6 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter7 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter8 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter9 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter10 = "MusicInScene"; // Параметр в AudioMixer
    [SerializeField] private string mixerParameter11 = "MusicInScene"; // Параметр в AudioMixer

    [Space(2)]
    [Header("KeyCodesSettings")]
    [Space(2)]
    public KeyCode KeyCode1;
    public KeyCode KeyCode2;
    public KeyCode KeyCode3;
    public KeyCode KeyCode4;
    public KeyCode KeyCode5;
    public KeyCode KeyCode6;
    public KeyCode KeyCode7;
    public KeyCode StandartKeycode1;
    public KeyCode StandartKeycode2;
    public KeyCode StandartKeycode3;
    public KeyCode StandartKeycode4;
    public KeyCode StandartKeycode5;
    public KeyCode StandartKeycode6;
    public KeyCode StandartKeycode7;
    public string playerPrefsName1;
    public string playerPrefsName2;
    public string playerPrefsName3;
    public string playerPrefsName4;
    public string playerPrefsName5;
    public string playerPrefsName6;
    public string playerPrefsName7;


    [Space(2)]
    [Header("Volumes")]
    [Space(2)]
    public Volume globalVolume; // Ссылка на ваш Global Volume
    private LiftGammaGain liftGammaGain;
    void Start()
    {
        float savedVolume1 = PlayerPrefs.GetFloat(PlayyerPrefsName1, 1f);
        float savedVolume2 = PlayerPrefs.GetFloat(PlayyerPrefsName2, 1f);
        float savedVolume3 = PlayerPrefs.GetFloat(PlayyerPrefsName3, 1f);
        float savedVolume4 = PlayerPrefs.GetFloat(PlayyerPrefsName4, 1f);
        float savedVolume5 = PlayerPrefs.GetFloat(PlayyerPrefsName5, 1f);
        float savedVolume6 = PlayerPrefs.GetFloat(PlayyerPrefsName6, 1f);
        float savedVolume7 = PlayerPrefs.GetFloat(PlayyerPrefsName7, 1f);
        float savedVolume8 = PlayerPrefs.GetFloat(PlayyerPrefsName8, 1f);
        float savedVolume9 = PlayerPrefs.GetFloat(PlayyerPrefsName9, 1f);
        float savedVolume10 = PlayerPrefs.GetFloat(PlayyerPrefsName10, 1f);
        float savedVolume11 = PlayerPrefs.GetFloat(PlayyerPrefsName11, 1f);
        float mixerVolume1 = Mathf.Lerp(-40, 1, savedVolume1); // Преобразуем значение слайдера в громкость
        float mixerVolume2 = Mathf.Lerp(-40, 1, savedVolume2); // Преобразуем значение слайдера в громкость
        float mixerVolume3 = Mathf.Lerp(-40, 1, savedVolume3); // Преобразуем значение слайдера в громкость
        float mixerVolume4 = Mathf.Lerp(-40, 1, savedVolume4); // Преобразуем значение слайдера в громкость
        float mixerVolume5 = Mathf.Lerp(-40, 1, savedVolume5); // Преобразуем значение слайдера в громкость
        float mixerVolume6 = Mathf.Lerp(-40, 1, savedVolume6); // Преобразуем значение слайдера в громкость
        float mixerVolume7 = Mathf.Lerp(-40, 1, savedVolume7); // Преобразуем значение слайдера в громкость
        float mixerVolume8 = Mathf.Lerp(-40, 1, savedVolume8); // Преобразуем значение слайдера в громкость
        float mixerVolume9 = Mathf.Lerp(-40, 1, savedVolume9); // Преобразуем значение слайдера в громкость
        float mixerVolume10 = Mathf.Lerp(-40, 1, savedVolume10); // Преобразуем значение слайдера в громкость
        float mixerVolume11 = Mathf.Lerp(-40, 1, savedVolume11); // Преобразуем значение слайдера в громкость

        if (mixerVolume1 == -40)
        {
            mixerVolume1 = -80;
        }
        if (mixerVolume2 == -40)
        {
            mixerVolume2 = -80;
        }
        if (mixerVolume3 == -40)
        {
            mixerVolume3 = -80;
        }
        if (mixerVolume4 == -40)
        {
            mixerVolume4 = -80;
        }
        if (mixerVolume5 == -40)
        {
            mixerVolume5 = -80;
        }
        if (mixerVolume6 == -40)
        {
            mixerVolume6 = -80;
        }
        if (mixerVolume7 == -40)
        {
            mixerVolume7 = -80;
        }
        if (mixerVolume8 == -40)
        {
            mixerVolume8 = -80;
        }
        if (mixerVolume9 == -40)
        {
            mixerVolume9 = -80;
        }
        if (mixerVolume10 == -40)
        {
            mixerVolume10 = -80;
        }
        if (mixerVolume11 == -40)
        {
            mixerVolume11 = -80;
        }

        audioMixer.SetFloat(mixerParameter1, mixerVolume1);
        audioMixer.SetFloat(mixerParameter2, mixerVolume2);
        audioMixer.SetFloat(mixerParameter3, mixerVolume3);
        audioMixer.SetFloat(mixerParameter4, mixerVolume4);
        audioMixer.SetFloat(mixerParameter5, mixerVolume5);
        audioMixer.SetFloat(mixerParameter6, mixerVolume6);
        audioMixer.SetFloat(mixerParameter7, mixerVolume7);
        audioMixer.SetFloat(mixerParameter8, mixerVolume8);
        audioMixer.SetFloat(mixerParameter9, mixerVolume9);
        audioMixer.SetFloat(mixerParameter10, mixerVolume10);
        audioMixer.SetFloat(mixerParameter11, mixerVolume11);

        KeyCode1 = PlayerPrefs.HasKey(playerPrefsName1) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName1)) : StandartKeycode1;
        KeyCode2 = PlayerPrefs.HasKey(playerPrefsName2) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName2)) : StandartKeycode2;
        KeyCode3 = PlayerPrefs.HasKey(playerPrefsName3) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName3)) : StandartKeycode3;
        KeyCode4 = PlayerPrefs.HasKey(playerPrefsName4) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName4)) : StandartKeycode4;
        KeyCode5 = PlayerPrefs.HasKey(playerPrefsName5) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName5)) : StandartKeycode5;
        KeyCode6 = PlayerPrefs.HasKey(playerPrefsName6) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName6)) : StandartKeycode6;
        KeyCode7 = PlayerPrefs.HasKey(playerPrefsName7) ? (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(playerPrefsName7)) : StandartKeycode7;

        int savedQuality = PlayerPrefs.GetInt("GraphicsQuality", 2);
        QualitySettings.SetQualityLevel(savedQuality);

        float mixerVolume = PlayerPrefs.GetFloat("BrightSettings", 0);
        globalVolume.profile.TryGet(out liftGammaGain);
        liftGammaGain.gain.value = new Vector4(0, 0, 0, mixerVolume);
    }


}

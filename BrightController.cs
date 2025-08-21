using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BrightController : MonoBehaviour
{
    public Slider brightnessSlider; // Ползунок для регулировки яркости
    public Volume globalVolume; // Ссылка на ваш Global Volume
    private LiftGammaGain liftGammaGain;


    private void Start()
    {
        float mixerVolume = PlayerPrefs.GetFloat("BrightSettings", 0);
        globalVolume.profile.TryGet(out liftGammaGain);
        liftGammaGain.gain.value = new Vector4(0, 0, 0, mixerVolume);
        brightnessSlider.SetValueWithoutNotify(mixerVolume);
    }

    public void OnVolumeSliderChanged(float mixerVolume)
    {
        SetMixerVolume(mixerVolume);
    }

    private void SetMixerVolume(float mixerVolume)
    {
        globalVolume.profile.TryGet(out liftGammaGain);
        liftGammaGain.gain.value = new Vector4(0, 0, 0, mixerVolume);
        PlayerPrefs.SetFloat("BrightSettings", mixerVolume);
    }
}

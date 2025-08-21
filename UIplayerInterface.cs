using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIplayerInterface : MonoBehaviour
{
    //----------------------------------------------------------------------------
    [Space(10)]
    [Header("Jump`s")]
    [Space(2)]
    public GameObject JumpState1;
    public GameObject JumpState2;
    public GameObject JumpState3;
    public TextMeshProUGUI JumpCountText;
    //----------------------------------------------------------------------------
    public PlayerJump JumpPlayerScript;
    public PlayerMovement PlayerScript;
    public PlayerCamera PlayerCameraScript;
    public PlayerHealth PlayerHealthScript;
    public Animator PauseAnim;
    public AudioMixer mixer;
    public AudioSource pausemusic;
    public bool allowPausing;
    private bool isPaused = false;
    private bool isAnimDone;

    private void Start()
    {
        allowPausing = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isPaused && isAnimDone && allowPausing)
        {
            isPaused = false;
            PauseAnim.Play("UnPauseGame");

            float savedVolume1 = PlayerPrefs.GetFloat("AudioSettingsMusicInGame", 1f);
            float savedVolume2 = PlayerPrefs.GetFloat("AudioSettingsInterface", 1f);
            float savedVolume3 = PlayerPrefs.GetFloat("AudioSettingsInvaironmate", 1f);
            float savedVolume4 = PlayerPrefs.GetFloat("AudioSettingsEffects", 1f);
            float savedVolume5 = PlayerPrefs.GetFloat("AudioSettingsDialogs", 1f);
            float savedVolume6 = PlayerPrefs.GetFloat("AudioSettingsEnemy", 1f);
            float savedVolume7 = PlayerPrefs.GetFloat("AudioSettingsCharacter", 1f);
            float savedVolume8 = PlayerPrefs.GetFloat("AudioSettingsInteractions", 1f);
            float savedVolume9 = PlayerPrefs.GetFloat("AudioSettingsFoneMusic", 1f);
            float mixerVolume1 = Mathf.Lerp(-40, 1, savedVolume1); // Преобразуем значение слайдера в громкость
            float mixerVolume2 = Mathf.Lerp(-40, 1, savedVolume2); // Преобразуем значение слайдера в громкость
            float mixerVolume3 = Mathf.Lerp(-40, 1, savedVolume3); // Преобразуем значение слайдера в громкость
            float mixerVolume4 = Mathf.Lerp(-40, 1, savedVolume4); // Преобразуем значение слайдера в громкость
            float mixerVolume5 = Mathf.Lerp(-40, 1, savedVolume5); // Преобразуем значение слайдера в громкость
            float mixerVolume6 = Mathf.Lerp(-40, 1, savedVolume6); // Преобразуем значение слайдера в громкость
            float mixerVolume7 = Mathf.Lerp(-40, 1, savedVolume7); // Преобразуем значение слайдера в громкость
            float mixerVolume8 = Mathf.Lerp(-40, 1, savedVolume8); // Преобразуем значение слайдера в громкость
            float mixerVolume9 = Mathf.Lerp(-40, 1, savedVolume9); // Преобразуем значение слайдера в громкость
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
            mixer.SetFloat("AudioMusicInGame", mixerVolume1);
            mixer.SetFloat("AudioInterface", mixerVolume2);
            mixer.SetFloat("AudioInvaironmate", mixerVolume3);
            mixer.SetFloat("AudioEffects", mixerVolume4);
            mixer.SetFloat("AudioDialogs", mixerVolume5);
            mixer.SetFloat("AudioEnemy", mixerVolume6);
            mixer.SetFloat("AudioCharacter", mixerVolume7);
            mixer.SetFloat("AudioInteractions", mixerVolume8);
            mixer.SetFloat("AudioFoneMusic", mixerVolume9);
            pausemusic.Stop();
        }

        if (Input.GetKey(KeyCode.Escape) && !isPaused && !isAnimDone && allowPausing)
        {
            isPaused = true;
            PauseAnim.Play("PauseAnimIn");

            mixer.SetFloat("AudioMusicInGame", -80f);
            mixer.SetFloat("AudioInterface", -80f);
            mixer.SetFloat("AudioInvaironmate", -80f);
            mixer.SetFloat("AudioEffects", -80f);
            mixer.SetFloat("AudioDialogs", -80f);
            mixer.SetFloat("AudioEnemy", -80f);
            mixer.SetFloat("AudioCharacter", -80f);
            mixer.SetFloat("AudioInteractions", -80f);
            mixer.SetFloat("AudioFoneMusic", -80f);
            pausemusic.PlayDelayed(1);

        }

        if (JumpPlayerScript.currentJumps == 0)
        {
            JumpState1.SetActive(false);
            JumpState2.SetActive(false);
            JumpState3.SetActive(false);
            JumpCountText.text = "0";
        }

        if (JumpPlayerScript.currentJumps == 1)
        {
            JumpState1.SetActive(true);
            JumpState2.SetActive(false);
            JumpState3.SetActive(false);
            JumpCountText.text = "1";
        }

        if (JumpPlayerScript.currentJumps == 2)
        {
            JumpState1.SetActive(true);
            JumpState2.SetActive(true);
            JumpState3.SetActive(false);
            JumpCountText.text = "2";
        }

        if (JumpPlayerScript.currentJumps == 3)
        {
            JumpState1.SetActive(true);
            JumpState2.SetActive(true);
            JumpState3.SetActive(true);
            JumpCountText.text = "3";
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TestScene");
    }
    public void PauseGames()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 0;
        PlayerScript.enabled = false;
        JumpPlayerScript.enabled = false;
        PlayerCameraScript.enabled = false;
        PlayerHealthScript.enabled = false;
    }
    public void AnimDone()
    {
        isAnimDone = true;
    }
    public void AnimDisDone()
    {
        isAnimDone = false;
    }
    public void OpenCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnPuaseGameAnim()
    {
        Time.timeScale = 1;
        PlayerScript.enabled = true;
        JumpPlayerScript.enabled = true;
        PlayerCameraScript.enabled = true;
        PlayerHealthScript.enabled = true;
    }
    public void UnPuaseGameButton()
    {
        isPaused = false;
        PauseAnim.Play("UnPauseGame");
        float savedVolume1 = PlayerPrefs.GetFloat("AudioSettingsMusicInGame", 1f);
        float savedVolume2 = PlayerPrefs.GetFloat("AudioSettingsInterface", 1f);
        float savedVolume3 = PlayerPrefs.GetFloat("AudioSettingsInvaironmate", 1f);
        float savedVolume4 = PlayerPrefs.GetFloat("AudioSettingsEffects", 1f);
        float savedVolume5 = PlayerPrefs.GetFloat("AudioSettingsDialogs", 1f);
        float savedVolume6 = PlayerPrefs.GetFloat("AudioSettingsEnemy", 1f);
        float savedVolume7 = PlayerPrefs.GetFloat("AudioSettingsCharacter", 1f);
        float savedVolume8 = PlayerPrefs.GetFloat("AudioSettingsInteractions", 1f);
        float savedVolume9 = PlayerPrefs.GetFloat("AudioSettingsFoneMusic", 1f);
        float mixerVolume1 = Mathf.Lerp(-40, 1, savedVolume1); // Преобразуем значение слайдера в громкость
        float mixerVolume2 = Mathf.Lerp(-40, 1, savedVolume2); // Преобразуем значение слайдера в громкость
        float mixerVolume3 = Mathf.Lerp(-40, 1, savedVolume3); // Преобразуем значение слайдера в громкость
        float mixerVolume4 = Mathf.Lerp(-40, 1, savedVolume4); // Преобразуем значение слайдера в громкость
        float mixerVolume5 = Mathf.Lerp(-40, 1, savedVolume5); // Преобразуем значение слайдера в громкость
        float mixerVolume6 = Mathf.Lerp(-40, 1, savedVolume6); // Преобразуем значение слайдера в громкость
        float mixerVolume7 = Mathf.Lerp(-40, 1, savedVolume7); // Преобразуем значение слайдера в громкость
        float mixerVolume8 = Mathf.Lerp(-40, 1, savedVolume8); // Преобразуем значение слайдера в громкость
        float mixerVolume9 = Mathf.Lerp(-40, 1, savedVolume9); // Преобразуем значение слайдера в громкость
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
        mixer.SetFloat("AudioMusicInGame", mixerVolume1);
        mixer.SetFloat("AudioInterface", mixerVolume2);
        mixer.SetFloat("AudioInvaironmate", mixerVolume3);
        mixer.SetFloat("AudioEffects", mixerVolume4);
        mixer.SetFloat("AudioDialogs", mixerVolume5);
        mixer.SetFloat("AudioEnemy", mixerVolume6);
        mixer.SetFloat("AudioCharacter", mixerVolume7);
        mixer.SetFloat("AudioInteractions", mixerVolume8);
        mixer.SetFloat("AudioFoneMusic", mixerVolume9);
        pausemusic.Stop();
    }
    public void OpenSettingsMenu()
    {
        PauseAnim.Play("SettingsGameInOpen");
    }
    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuGame");
    }
}

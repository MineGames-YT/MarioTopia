using UnityEngine;

public class MenuScriptButtons : MonoBehaviour
{
    public Animator anim;
    public Animator animCamera;

    public void ResetGame()
    {
        PlayerPrefs.SetInt("WeaponMiniSwordIsCollect", 1);
        PlayerPrefs.SetInt("WeaponWaterIsCollect", 1);
        PlayerPrefs.SetInt("WeaponBowGribIsCollect", 1);
        PlayerPrefs.SetInt("WeaponMolotIsCollect", 1);
        PlayerPrefs.SetInt("WeaponBigSwordIsCollect", 1);
        PlayerPrefs.SetInt("WeaponTrybaIsCollect", 1);
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);
        PlayerPrefs.SetInt("4", 0);
        PlayerPrefs.Save();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void StartSettingsAnim()
    {
        animCamera.SetBool("isOpenSettings", true);
        animCamera.SetBool("isOpenAchivments", false);
        anim.Play("SettingsMenuUI");
    }

    public void CloseSettingsAnim()
    {
        animCamera.SetBool("isOpenSettings", false);
        animCamera.SetBool("isOpenAchivments", false);
        anim.Play("CloseSettongsMenuUI");
    }

    public void OpenPanelGame()
    {
        anim.Play("GamePanelOpen");
    }

    public void OpenPanelGraphic()
    {
        anim.Play("GraphicPanelOpen");
    }

    public void OpenPanelAudio()
    {
        anim.Play("AudioPanelOpen");
    }

    public void OpenPanelControl()
    {
        anim.Play("ControlPanelOpen");
    }

    public void ClosePanelControl()
    {
        anim.Play("ControlPanelClose");
    }

    public void OpenPanelInterface()
    {
        anim.Play("InterfacePanelOpen");
    }

    public void ClosePanelInterface()
    {
        anim.Play("InterfacePanelClose");
    }
}

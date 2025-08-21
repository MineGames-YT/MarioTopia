using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartLevelButton()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void TpToMenu()
    {
        SceneManager.LoadScene("MenuGame");
    }
}

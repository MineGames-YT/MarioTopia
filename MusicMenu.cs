using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMenu : MonoBehaviour
{
    void Awake()
    {
        // Не уничтожаем объект при загрузке новой сцены
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        // Подписываемся на событие загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Отписываемся от события загрузки сцены
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Проверяем, загружается ли сцена с именем "Game"
        if (scene.name == "TestScene")
        {
            // Удаляем объект с тегом "MenuMusic"
            GameObject musicObj = GameObject.FindGameObjectWithTag("MenuMusic");
            if (musicObj != null)
            {
                Destroy(musicObj);
            }
        }
    }
}

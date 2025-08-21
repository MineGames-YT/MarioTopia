using UnityEngine;

public class LuckyBlock : MonoBehaviour
{
    public MeshFilter MeshCurrent; // Меш, который будет отображать состояние блока
    public Mesh MeshNone; // Меш для открытого блока
    public GameObject WhatObject; // Объект, который будет скрыт при открытии
    public Animator anim; // Аниматор для анимации открытия
    public string blockID; // Уникальный идентификатор блока
    public AudioSource audioOpen;
    public AudioSource audioIFopen;

    private void Start()
    {
        // Загрузка состояния блока при старте
        LoadState();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что блок еще не открыт и игрок вошел в триггер
        if (!IsOpen && other.CompareTag("Player"))
        {
            OpenBlock();
            audioIFopen.Play();
        }
        if (IsOpen && other.CompareTag("Player"))
        {
            audioIFopen.Play();
            anim.Play("LuckyBlockAnim");
        }
    }

    public bool IsOpen { get; private set; } = false;

    private void OpenBlock()
    {
        audioOpen.Play();
        WhatObject.SetActive(false);
        anim.Play("LuckyBlockAnim");
        MeshCurrent.mesh = MeshNone;
        IsOpen = true; // Устанавливаем состояние блока как открытое
        SaveState(); // Сохраняем состояние блока
    }

    private void SaveState()
    {
        PlayerPrefs.SetInt(blockID, IsOpen ? 1 : 0); // Сохраняем состояние (1 - открыт, 0 - закрыт)
        PlayerPrefs.Save(); // Необходимо для сохранения изменений
    }

    private void LoadState()
    {
        // Загружаем состояние блока из PlayerPrefs
        if (PlayerPrefs.HasKey(blockID))
        {
            IsOpen = PlayerPrefs.GetInt(blockID) == 1;
            if (IsOpen)
            {
                WhatObject.SetActive(false);
                MeshCurrent.mesh = MeshNone;
            }
        }
    }
}

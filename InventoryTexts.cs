using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class InventoryTexts : MonoBehaviour
{
    public float interactionDistance = 3f;
    public Camera playerCamera;
    public Animator anim;
    private Coroutine typingCoroutine;
    public GameObject TextInfo;
    
    private Coroutine typingCoroutineObject;
    public GameObject TextInfoObject;

    public bool isActiveLookingToGameBoy;
    public bool isActiveLookingToSaveStar;

    private void Start()
    {
        TextInfoObject.SetActive(false); // �������� �����, ���� ��� �� ����� �� � ���� ������
        if (typingCoroutineObject != null)
        {
            StopCoroutine(typingCoroutineObject); // ������������� �������� ��� �������
            TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
        }
    }

    private void Update()
    {
        Texte();
        
        if (isActiveLookingToGameBoy)
        {
            TexteObjectGameBoy();
        }

        if (!isActiveLookingToSaveStar && !isActiveLookingToGameBoy)
        {
            TextWeaponsPickUps();
        }

        if (isActiveLookingToSaveStar)
        {
            TexteObjectGameBoy();
        }
    }

    private Dictionary<string, ObjectInfo> objectsInfos = new Dictionary<string, ObjectInfo>
    {
        { "GameBoyMachine", new ObjectInfo("Нажми F чтобы Открыть", Color.yellow) },
        { "SavingStarObject", new ObjectInfo("Нажми F чтобы Сохраниться", Color.green) }
    };

    private Dictionary<string, ObjectInfoWeap> objectsInfosWeapons = new Dictionary<string, ObjectInfoWeap>
    {
        { "WeaponTryba", new ObjectInfoWeap("Нажми F чтобы Подобрать", Color.yellow) },
        { "WeaponBigSword", new ObjectInfoWeap("Нажми F чтобы Подобрать", Color.yellow) },
        { "WeaponMolot", new ObjectInfoWeap("Нажми F чтобы Подобрать", Color.yellow) },
        { "WeaponBowGrib", new ObjectInfoWeap("Нажми F чтобы Подобрать", Color.yellow) },
        { "WeaponWater", new ObjectInfoWeap("Нажми F чтобы Подобрать", Color.yellow) },
        { "WeaponMiniSword", new ObjectInfoWeap("Нажми F чтобы Подобрать", Color.yellow) },
        
        { "EatChocolate", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatPizza", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatBurger", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatPasha", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatEnergetic", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatApple", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatCocaCola", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatCoffe", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "EatTea", new ObjectInfoWeap("Нажми F чтобы Использовать", Color.yellow) },
        { "ButtonTV", new ObjectInfoWeap("Нажми F чтобы Открыть меню телевизора", Color.yellow) },
        { "ButtonStartLesson", new ObjectInfoWeap("Нажми F чтобы Начать обучение", Color.yellow) },
    };

    private Dictionary<string, WeaponInfo> weaponInfos = new Dictionary<string, WeaponInfo>
    {
        { "WeaponTryba", new WeaponInfo("Труба Судьбы", Color.green) },
        { "WeaponBigSword", new WeaponInfo("Сабля Героя", Color.blue) },
        { "WeaponMolot", new WeaponInfo("Молот Пиньята", Color.magenta) },
        { "WeaponBowGrib", new WeaponInfo("Грибной Лук", Color.gray) },
        { "WeaponWater", new WeaponInfo("Водный Пистолет", Color.cyan) },
        { "WeaponMiniSword", new WeaponInfo("Мини Кинжал", Color.red) },
        
        { "EatChocolate", new WeaponInfo("Шоколадка", new Color(0.35f, 0.12f, 0f)) },
        { "EatPizza", new WeaponInfo("Пицца", new Color(1f, 0.8f, 0f)) },
        { "EatBurger", new WeaponInfo("Бургер", new Color(1f, 0.55f, 0f)) },
        { "EatPasha", new WeaponInfo("Паска", new Color(1f, 0.5f, 0.3f)) },
        { "EatEnergetic", new WeaponInfo("Энергетик", new Color(0f, 0.7f, 0.45f)) },
        { "EatApple", new WeaponInfo("Яблоко", new Color(0.8f, 0.7f, 0f)) },
        { "EatCocaCola", new WeaponInfo("КокаКола", new Color(1f, 0.2f, 0f)) },
        { "EatCoffe", new WeaponInfo("Кофе", new Color(0.5f, 0f, 0.05f)) },
        { "EatTea", new WeaponInfo("Чай",  new Color(0f, 0.6f, 0.25f)) },
    };

    [System.Serializable]
    public class WeaponInfo
    {
        public string name;
        public Color color;

        public WeaponInfo(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }
    }

    [System.Serializable]
    public class ObjectInfo
    {
        public string name;
        public Color color;

        public ObjectInfo(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }
    }
    
    [System.Serializable]
    public class ObjectInfoWeap
    {
        public string name;
        public Color color;

        public ObjectInfoWeap(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }
    }

    void Texte()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            string tag = hit.collider.tag; // �������� ��� �������

            if (weaponInfos.ContainsKey(tag)) // ���������, ���� �� ��� � ����� �������
            {
                if (!TextInfo.activeSelf)
                {
                    TextInfo.SetActive(true); // ���������� �����, ���� ������� �� ������
                    if (typingCoroutine != null)
                    {
                        StopCoroutine(typingCoroutine); // ������������� ���������� ��������, ���� ��� ����
                    }

                    // �������� ���������� � ������
                    WeaponInfo weaponInfo = weaponInfos[tag];
                    anim.SetBool("NameWeaponBool", true);
                    // ������������� ���� ������
                    TextMeshProUGUI textComponent = TextInfo.GetComponentInChildren<TextMeshProUGUI>();
                    textComponent.color = weaponInfo.color; // ������������� ���� ������

                    typingCoroutine = StartCoroutine(TypeText(weaponInfo.name)); // ��������� �������� ��� ����������� ������
                }
            }
            else if (TextInfo.activeSelf)
            {
                anim.SetBool("NameWeaponBool", false);
                TextInfo.SetActive(false); // �������� �����, ���� �� ������� �� ������
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine); // ������������� �������� ��� �������
                    TextInfo.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
                }
            }
        }
        else if (TextInfo.activeSelf)
        {
            anim.SetBool("NameWeaponBool", false);
            TextInfo.SetActive(false); // �������� �����, ���� ��� �� ����� �� � ���� ������
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine); // ������������� �������� ��� �������
                TextInfo.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
            }
        }
    }

    void TextWeaponsPickUps()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            string tag = hit.collider.tag; // �������� ��� �������

            if (objectsInfosWeapons.ContainsKey(tag)) // ���������, ���� �� ��� � ����� �������
            {
                if (!TextInfoObject.activeSelf)
                {
                    TextInfoObject.SetActive(true); // ���������� �����, ���� ������� �� ������
                    if (typingCoroutineObject != null)
                    {
                        StopCoroutine(typingCoroutineObject); // ������������� ���������� ��������, ���� ��� ����
                    }

                    // �������� ���������� � ������
                    ObjectInfoWeap weaponInfo = objectsInfosWeapons[tag];
                    // ������������� ���� ������
                    TextMeshProUGUI textComponent = TextInfoObject.GetComponentInChildren<TextMeshProUGUI>();
                    textComponent.color = weaponInfo.color; // ������������� ���� ������

                    typingCoroutineObject = StartCoroutine(TypeTextObject(weaponInfo.name)); // ��������� �������� ��� ����������� ������
                }
            }
            else if (TextInfoObject.activeSelf)
            {
                TextInfoObject.SetActive(false); // �������� �����, ���� �� ������� �� ������
                if (typingCoroutineObject != null)
                {
                    StopCoroutine(typingCoroutineObject); // ������������� �������� ��� �������
                    TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
                }
            }
        }
        else if (TextInfoObject.activeSelf)
        {
            TextInfoObject.SetActive(false); // �������� �����, ���� ��� �� ����� �� � ���� ������
            if (typingCoroutineObject != null)
            {
                StopCoroutine(typingCoroutineObject); // ������������� �������� ��� �������
                TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
            }
        }
    }
    

    void TexteObjectGameBoy()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            string tag = hit.collider.tag; // �������� ��� �������

            if (objectsInfos.ContainsKey(tag)) // ���������, ���� �� ��� � ����� �������
            {
                if (!TextInfoObject.activeSelf)
                {
                    TextInfoObject.SetActive(true); // ���������� �����, ���� ������� �� ������
                    if (typingCoroutineObject != null)
                    {
                        StopCoroutine(typingCoroutineObject); // ������������� ���������� ��������, ���� ��� ����
                    }

                    // �������� ���������� � ������
                    ObjectInfo weaponInfo = objectsInfos[tag];
                    // ������������� ���� ������
                    TextMeshProUGUI textComponent = TextInfoObject.GetComponentInChildren<TextMeshProUGUI>();
                    textComponent.color = weaponInfo.color; // ������������� ���� ������

                    typingCoroutineObject = StartCoroutine(TypeTextObject(weaponInfo.name)); // ��������� �������� ��� ����������� ������
                }
            }
            else if (TextInfoObject.activeSelf)
            {
                TextInfoObject.SetActive(false); // �������� �����, ���� �� ������� �� ������
                if (typingCoroutineObject != null)
                {
                    StopCoroutine(typingCoroutineObject); // ������������� �������� ��� �������
                    TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
                }
            }
        }
        else if (TextInfoObject.activeSelf)
        {
            TextInfoObject.SetActive(false); // �������� �����, ���� ��� �� ����� �� � ���� ������
            if (typingCoroutineObject != null)
            {
                StopCoroutine(typingCoroutineObject); // ������������� �������� ��� �������
                TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
            }
        }
    }

    private IEnumerator TypeText(string text)
    {
        TextInfo.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� ����� ����� �������
        foreach (char letter in text.ToCharArray())
        {
            TextInfo.GetComponentInChildren<TextMeshProUGUI>().text += letter; // ��������� �� ����� �����
            yield return new WaitForSeconds(0.03f); // �������� � 0.1 �������
        }
    }
    private IEnumerator TypeTextObject(string text)
    {
        TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� ����� ����� �������
        foreach (char letter in text.ToCharArray())
        {
            TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text += letter; // ��������� �� ����� �����
            yield return new WaitForSeconds(0.03f); // �������� � 0.1 �������
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GameBoyMachineTrigger"))
        {
            TexteObjectGameBoy();
            isActiveLookingToGameBoy = true;
        }
        if (other.CompareTag("SavingStarObjectTrigger"))
        {
            TexteObjectGameBoy();
            isActiveLookingToSaveStar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActiveLookingToGameBoy = false;
        isActiveLookingToSaveStar = false;
        TextInfoObject.SetActive(false); // �������� �����, ���� ��� �� ����� �� � ���� ������
        if (typingCoroutineObject != null)
        {
            StopCoroutine(typingCoroutineObject); // ������������� �������� ��� �������
            TextInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = ""; // ������� �����
        }
    }
}

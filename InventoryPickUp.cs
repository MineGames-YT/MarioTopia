using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPickUp : MonoBehaviour
{
    public Animator EatAnimator;
    public Image EatPanel1;
    public Image EatPanel2;
    public PlayerEat playerEat;
    
    
    public Camera playerCamera;
    public float interactionDistance = 3f;
    public InventoryBigUI Inventory;
    public bool isLookingToMachine;
    public bool isLookingToSavingStar;

    public bool isCollectWeaponMiniSword;
    public bool isCollectWeaponWater;
    public bool isCollectWeaponBowGrib;
    public bool isCollectWeaponMolot;
    public bool isCollectWeaponBigSword;
    public bool isCollectWeaponTryba;

    public bool IsPressButtonLesson;
    public bool IsPressButtonTV;
    
    private void Update()
    {
        if (Inventory.isTakeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TryPickupItem();
            }
        }
        if (isCollectWeaponMolot)
        {
            GameObject Molot = GameObject.FindGameObjectWithTag("WeaponMolot");
            Destroy(Molot);
        }
        if (isCollectWeaponBowGrib)
        {
            GameObject BowGrib = GameObject.FindGameObjectWithTag("WeaponBowGrib");
            Destroy(BowGrib);
        }
        if (isCollectWeaponWater)
        {
            GameObject WaterGun = GameObject.FindGameObjectWithTag("WeaponWater");
            Destroy(WaterGun);
        }
        if (isCollectWeaponMiniSword)
        {
            GameObject MiniSword = GameObject.FindGameObjectWithTag("WeaponMiniSword");
            Destroy(MiniSword);
        }
        if (isCollectWeaponBigSword)
        {
            GameObject BigSword = GameObject.FindGameObjectWithTag("WeaponBigSword");
            Destroy(BigSword);
        }
        if (isCollectWeaponTryba)
        {
            GameObject Tryba = GameObject.FindGameObjectWithTag("WeaponTryba");
            Destroy(Tryba);
        }
    }

    public void CreateGrass()
    {
        Instantiate(Prefab, tranformspawn);
    }

    private void Start()
    {
        isCollectWeaponMolot = PlayerPrefs.GetInt("WeaponMolotIsCollect") == 1;
        isCollectWeaponBowGrib = PlayerPrefs.GetInt("WeaponBowGribIsCollect") == 1;
        isCollectWeaponWater = PlayerPrefs.GetInt("WeaponWaterIsCollect") == 1;
        isCollectWeaponMiniSword = PlayerPrefs.GetInt("WeaponMiniSwordIsCollect") == 1;
        isCollectWeaponBigSword = PlayerPrefs.GetInt("WeaponBigSwordIsCollect") == 1;
        isCollectWeaponTryba = PlayerPrefs.GetInt("WeaponTrybaIsCollect") == 1;
        
        if (isCollectWeaponMolot)
        {
            GameObject Molot = GameObject.FindGameObjectWithTag("WeaponMolot");
            Destroy(Molot);
            Inventory.slots[1].isLocked = true;
            Inventory.slots[1].text_none.SetActive(false);
        }
        if (isCollectWeaponBowGrib)
        {
            GameObject BowGrib = GameObject.FindGameObjectWithTag("WeaponBowGrib");
            Destroy(BowGrib);
            Inventory.slots[2].isLocked = true;
            Inventory.slots[2].text_none.SetActive(false);
        }
        if (isCollectWeaponWater)
        {
            GameObject WaterGun = GameObject.FindGameObjectWithTag("WeaponWater");
            Destroy(WaterGun);
            Inventory.slots[3].isLocked = true;
            Inventory.slots[3].text_none.SetActive(false);
        }
        if (isCollectWeaponMiniSword)
        {
            GameObject MiniSword = GameObject.FindGameObjectWithTag("WeaponMiniSword");
            Destroy(MiniSword);
            Inventory.slots[4].isLocked = true;
            Inventory.slots[4].text_none.SetActive(false);
        }
        if (isCollectWeaponBigSword)
        {
            GameObject BigSword = GameObject.FindGameObjectWithTag("WeaponBigSword");
            Destroy(BigSword);
            Inventory.slots[5].isLocked = true;
            Inventory.slots[5].text_none.SetActive(false);
        }
        if (isCollectWeaponTryba)
        {
            GameObject Tryba = GameObject.FindGameObjectWithTag("WeaponTryba");
            Destroy(Tryba);
            Inventory.slots[6].isLocked = true;
            Inventory.slots[6].text_none.SetActive(false);
        }
    }

    public GameObject Prefab;
    public Transform tranformspawn;
    public DisableUIlesson UIlesson;

    void TryPickupItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("ButtonTV") && !IsPressButtonTV)
            {
                IsPressButtonTV = true;
            }
            if (hit.collider.CompareTag("ButtonStartLesson") && !IsPressButtonLesson)
            {
                IsPressButtonLesson = true;
            }
            if (hit.collider.CompareTag("EatChocolate"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(0.35f, 0.12f, 0f);
                EatPanel2.color = new Color(0.35f, 0.12f, 0f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(2);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatPizza"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(1f, 0.8f, 0f);
                EatPanel2.color = new Color(1f, 0.8f, 0f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(12);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatBurger"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(1f, 0.55f, 0f);
                EatPanel2.color = new Color(1f, 0.55f, 0f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(20);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatPasha"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(1f, 0.5f, 0.3f);
                EatPanel2.color = new Color(1f, 0.5f, 0.3f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(30);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatEnergetic"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(0f, 0.7f, 0.45f);
                EatPanel2.color = new Color(0f, 0.7f, 0.45f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(6);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatApple"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(0.8f, 0.7f, 0f);
                EatPanel2.color = new Color(0.8f, 0.7f, 0f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(8);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatCocaCola"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(1f, 0.2f, 0f);
                EatPanel2.color = new Color(1f, 0.2f, 0f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(5);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatCoffe"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(0.5f, 0f, 0.05f);
                EatPanel2.color = new Color(0.5f, 0f, 0.05f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(10);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("EatTea"))
            {
                UIlesson.isEatChocolate = true;
                EatPanel1.color = new Color(0f, 0.6f, 0.25f);
                EatPanel2.color = new Color(0f, 0.6f, 0.25f);
                EatAnimator.Play("EatAndPoisonEffectCollect");
                playerEat.PlusEat(11);
                Destroy(hit.collider.gameObject);
            }
            
            
            if (hit.collider.CompareTag("WeaponMiniSword"))
            {
                PlayerPrefs.SetInt("WeaponMiniSwordIsCollect", 1);
                PlayerPrefs.Save();
                Inventory.slots[1].isLocked = true;
                Inventory.slots[1].text_none.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("WeaponWater"))
            {
                PlayerPrefs.SetInt("WeaponWaterIsCollect", 1);
                PlayerPrefs.Save();
                Inventory.slots[2].isLocked = true;
                Inventory.slots[2].text_none.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("WeaponBowGrib"))
            {
                PlayerPrefs.SetInt("WeaponBowGribIsCollect", 1);
                PlayerPrefs.Save();
                Inventory.slots[3].isLocked = true;
                Inventory.slots[3].text_none.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("WeaponMolot"))
            {
                PlayerPrefs.SetInt("WeaponMolotIsCollect", 1);
                PlayerPrefs.Save();
                Inventory.slots[4].isLocked = true;
                Inventory.slots[4].text_none.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("WeaponBigSword"))
            {
                PlayerPrefs.SetInt("WeaponBigSwordIsCollect", 1);
                PlayerPrefs.Save();
                Inventory.slots[5].isLocked = true;
                Inventory.slots[5].text_none.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("WeaponTryba"))
            {
                PlayerPrefs.SetInt("WeaponTrybaIsCollect", 1);
                PlayerPrefs.Save();
                Inventory.slots[6].isLocked = true;
                Inventory.slots[6].text_none.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("GameBoyMachine") && isLookingToMachine)
            {
                GameBoyMachine gameboyScript = hit.collider.GetComponent<GameBoyMachine>();
                gameboyScript.PressFdone = true;
                isLookingToMachine = false;
            }
            if (hit.collider.CompareTag("SavingStarObject") && isLookingToSavingStar)
            {
                SaveGameStarManager SavingStar = hit.collider.GetComponent<SaveGameStarManager>();
                SavingStar.PressFdone = true;
                isLookingToSavingStar = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GameBoyMachineTrigger"))
        {
            isLookingToMachine = true;
        }
        if (other.CompareTag("SavingStarObjectTrigger"))
        {
            isLookingToSavingStar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameBoyMachineTrigger"))
        {
            isLookingToMachine = false;
        }
        if (other.CompareTag("SavingStarObjectTrigger"))
        {
            isLookingToSavingStar = false;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class InventoryBigUI : MonoBehaviour
{

    [System.Serializable]
    public class Slot
    {
        public bool isLocked;
        public GameObject slotObject;
        public GameObject text_none;
    }
    public Slot[] slots; // Массив слотов
    [Space(2)]
    [Header("Settings")]
    [Space(2)]
    public bool isTakeWeapon = true;
    public int currentSlot;
    public float TimerExitMax;
    public float TimerExitCurrent;
    public Animator anim;
    public Animator animPlayer;
    public PlayerCamera cameraScript;
    private void Update()
    {  
        if (isTakeWeapon)
        {
            ResetAllAnimations();
            SlotsAnimOn();
            Inventory();
            if (currentSlot > 0)
            {
                TimerExitCurrent -= Time.deltaTime;
                if (TimerExitCurrent <= 0)
                {
                    TimerExitCurrent = 0;
                    SlotsAnimOff();
                }
            }
        }
        
    }
    private void ResetAllAnimations()
    {
        foreach (var slot in slots)
        {
            if (!slots[currentSlot].isLocked)
            {
                animPlayer.SetBool("isTakeTryba", false);
                animPlayer.SetBool("isTakeBigSword", false);
                animPlayer.SetBool("isTakeWeapon", false);
                animPlayer.SetBool("isTakeBow", false);
                animPlayer.SetBool("Charge", false);
                animPlayer.SetBool("MiniWeapon1", false);
                animPlayer.SetBool("MiniWeapon2", false);
                animPlayer.SetBool("MiniWeapon3", false);
                animPlayer.SetBool("Molot1Bool", false);
                animPlayer.SetBool("Molot2Bool", false);
                animPlayer.SetBool("MolotAttack", false);

                cameraScript.isRotateRyks = false;
                cameraScript.isRotateAllRyks = false;
            }
        }
    }
    void SlotsAnimOff()
    {
        TimerExitCurrent -= Time.deltaTime;
        if (TimerExitCurrent <= 0)
        {
            TimerExitCurrent = 0;
            anim.SetBool("DownSlotBool", false);
            anim.SetBool("Slot1Bool", false);
            anim.SetBool("Slot2Bool", false);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", false);
            anim.SetBool("Slot5Bool", false);
            anim.SetBool("Slot6Bool", false);
        }
    }
    void SlotsAnimOn()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentSlot += 1;
            if (currentSlot >= 6)
            {
                currentSlot = 6;
            }

            if (currentSlot == 1)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", true);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 2)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", true);
                anim.SetBool("Slot2Bool", true);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 3)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", true);
                anim.SetBool("Slot2Bool", true);
                anim.SetBool("Slot3Bool", true);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 4)
            {
                currentSlot = 4;
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", true);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 5)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", true);
                anim.SetBool("Slot5Bool", true);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 6)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", true);
                anim.SetBool("Slot5Bool", true);
                anim.SetBool("Slot6Bool", true);
                TimerExitCurrent = TimerExitMax;
            }
            else
            {
                animPlayer.SetBool("isTakeTryba", false);
                animPlayer.SetBool("isTakeBigSword", false);
                anim.SetBool("DownSlotBool", false);
                animPlayer.SetBool("isTakeWeapon", false);
                animPlayer.SetBool("isTakeBow", false);
                cameraScript.isRotateRyks = false;
                cameraScript.isRotateAllRyks = false;
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = 0;
                currentSlot = 0;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentSlot -= 1;
            if (currentSlot <= 0)
            {
                currentSlot = 0;
            }
            
            if (currentSlot == 1)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", true);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 2)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", true);
                anim.SetBool("Slot2Bool", true);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 3)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", true);
                anim.SetBool("Slot2Bool", true);
                anim.SetBool("Slot3Bool", true);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 4)
            {
                currentSlot = 4;
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", true);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 5)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", true);
                anim.SetBool("Slot5Bool", true);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = TimerExitMax;
            }
            else if (currentSlot == 6)
            {
                if (!anim.GetBool("DownSlotBool"))
                {
                    anim.SetBool("DownSlotBool", true);
                }
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", true);
                anim.SetBool("Slot5Bool", true);
                anim.SetBool("Slot6Bool", true);
                TimerExitCurrent = TimerExitMax;
            }
            else
            {
                animPlayer.SetBool("isTakeTryba", false);
                animPlayer.SetBool("isTakeBigSword", false);
                anim.SetBool("DownSlotBool", false);
                animPlayer.SetBool("isTakeWeapon", false);
                animPlayer.SetBool("isTakeBow", false);
                cameraScript.isRotateRyks = false;
                cameraScript.isRotateAllRyks = false;
                anim.SetBool("Slot1Bool", false);
                anim.SetBool("Slot2Bool", false);
                anim.SetBool("Slot3Bool", false);
                anim.SetBool("Slot4Bool", false);
                anim.SetBool("Slot5Bool", false);
                anim.SetBool("Slot6Bool", false);
                TimerExitCurrent = 0;
                currentSlot = 0;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSlot = 1;
            if (!anim.GetBool("DownSlotBool"))
            {
                anim.SetBool("DownSlotBool", true);
            }
            anim.SetBool("Slot1Bool", true);
            anim.SetBool("Slot2Bool", false);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", false);
            anim.SetBool("Slot5Bool", false);
            anim.SetBool("Slot6Bool", false);
            TimerExitCurrent = TimerExitMax;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSlot = 2;
            if (!anim.GetBool("DownSlotBool"))
            {
                anim.SetBool("DownSlotBool", true);
            }
            anim.SetBool("Slot1Bool", true);
            anim.SetBool("Slot2Bool", true);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", false);
            anim.SetBool("Slot5Bool", false);
            anim.SetBool("Slot6Bool", false);
            TimerExitCurrent = TimerExitMax;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSlot = 3;
            if (!anim.GetBool("DownSlotBool"))
            {
                anim.SetBool("DownSlotBool", true);
            }
            anim.SetBool("Slot1Bool", true);
            anim.SetBool("Slot2Bool", true);
            anim.SetBool("Slot3Bool", true);
            anim.SetBool("Slot4Bool", false);
            anim.SetBool("Slot5Bool", false);
            anim.SetBool("Slot6Bool", false);
            TimerExitCurrent = TimerExitMax;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSlot = 4;
            if (!anim.GetBool("DownSlotBool"))
            {
                anim.SetBool("DownSlotBool", true);
            }
            anim.SetBool("Slot1Bool", false);
            anim.SetBool("Slot2Bool", false);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", true);
            anim.SetBool("Slot5Bool", false);
            anim.SetBool("Slot6Bool", false);
            TimerExitCurrent = TimerExitMax;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentSlot = 5;
            
            if (!anim.GetBool("DownSlotBool"))
            {
                anim.SetBool("DownSlotBool", true);
            }
            anim.SetBool("Slot1Bool", false);
            anim.SetBool("Slot2Bool", false);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", true);
            anim.SetBool("Slot5Bool", true);
            anim.SetBool("Slot6Bool", false);
            TimerExitCurrent = TimerExitMax;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentSlot = 6;
            if (!anim.GetBool("DownSlotBool"))
            {
                anim.SetBool("DownSlotBool", true);
            }
            anim.SetBool("Slot1Bool", false);
            anim.SetBool("Slot2Bool", false);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", true);
            anim.SetBool("Slot5Bool", true);
            anim.SetBool("Slot6Bool", true);
            TimerExitCurrent = TimerExitMax;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            animPlayer.SetBool("isTakeBigSword", false);
            anim.SetBool("DownSlotBool", false);
            animPlayer.SetBool("isTakeWeapon", false);
            animPlayer.SetBool("isTakeBow", false);
            animPlayer.SetBool("isTakeTryba", false);
            cameraScript.isRotateRyks = false;
            cameraScript.isRotateAllRyks = false;
            anim.SetBool("Slot1Bool", false);
            anim.SetBool("Slot2Bool", false);
            anim.SetBool("Slot3Bool", false);
            anim.SetBool("Slot4Bool", false);
            anim.SetBool("Slot5Bool", false);
            anim.SetBool("Slot6Bool", false);
            TimerExitCurrent = 0;
            currentSlot = 0;
        }
    }
    void Inventory()
    {
        if (currentSlot == 1 && slots[1].isLocked)
        {
            
            animPlayer.SetBool("Molot1Bool", false);
            animPlayer.SetBool("Molot2Bool", false);
            animPlayer.SetBool("MolotAttack", false);
            animPlayer.SetBool("isTakeBigSword", false);
            animPlayer.SetBool("isTakeTryba", false);
            animPlayer.SetBool("isTakeWeapon", true);
            animPlayer.SetBool("isTakeBow", false);
            animPlayer.SetBool("Charge", false);
            cameraScript.isRotateRyks = true;
            cameraScript.isRotateAllRyks = false;
            slots[1].slotObject.SetActive(true);
        }
        else
        {
            slots[1].slotObject.SetActive(false);
        }
        if (currentSlot == 2 && slots[2].isLocked)
        {
            animPlayer.SetBool("isTakeBigSword", false);
            animPlayer.SetBool("isTakeWeapon", true);
            animPlayer.SetBool("isTakeBow", false);
            animPlayer.SetBool("Charge", false);
            animPlayer.SetBool("isTakeTryba", false);
            cameraScript.isRotateRyks = true;
            cameraScript.isRotateAllRyks = false;
            slots[2].slotObject.SetActive(true);
        }
        else
        {
            slots[2].slotObject.SetActive(false);
        }
        if (currentSlot == 3 && slots[3].isLocked)
        {
            animPlayer.SetBool("isTakeBigSword", false);
            animPlayer.SetBool("isTakeBow", true);
            animPlayer.SetBool("isTakeWeapon", false);
            animPlayer.SetBool("isTakeTryba", false);
            animPlayer.SetBool("MiniWeapon1", false);
            animPlayer.SetBool("MiniWeapon2", false);
            animPlayer.SetBool("MiniWeapon3", false);
            animPlayer.SetBool("Molot1Bool", false);
            animPlayer.SetBool("Molot2Bool", false);
            animPlayer.SetBool("MolotAttack", false);

            cameraScript.isRotateRyks = false;
            cameraScript.isRotateAllRyks = true;
            slots[3].slotObject.SetActive(true);
        }
        else
        {
            slots[3].slotObject.SetActive(false);
        }
        if (currentSlot == 4 && slots[4].isLocked)
        {
            animPlayer.SetBool("isTakeBigSword", false);
            animPlayer.SetBool("isTakeWeapon", true);
            animPlayer.SetBool("isTakeBow", false);
            animPlayer.SetBool("Charge", false);
            animPlayer.SetBool("isTakeTryba", false);
            animPlayer.SetBool("MiniWeapon1", false);
            animPlayer.SetBool("MiniWeapon2", false);
            animPlayer.SetBool("MiniWeapon3", false);

            cameraScript.isRotateRyks = true;
            cameraScript.isRotateAllRyks = false;
            slots[4].slotObject.SetActive(true);
        }
        else
        {
            slots[4].slotObject.SetActive(false);
        }
        if (currentSlot == 5 && slots[5].isLocked)
        {
            animPlayer.SetBool("isTakeWeapon", false);
            animPlayer.SetBool("isTakeBow", false);
            animPlayer.SetBool("isTakeBigSword", true);
            animPlayer.SetBool("Charge", false);
            animPlayer.SetBool("isTakeTryba", false);
            animPlayer.SetBool("MiniWeapon1", false);
            animPlayer.SetBool("MiniWeapon2", false);
            animPlayer.SetBool("MiniWeapon3", false);
            animPlayer.SetBool("Molot1Bool", false);
            animPlayer.SetBool("Molot2Bool", false);
            animPlayer.SetBool("MolotAttack", false);

            cameraScript.isRotateRyks = false;
            cameraScript.isRotateAllRyks = true;
            slots[5].slotObject.SetActive(true);
        }
        else
        {
            slots[5].slotObject.SetActive(false);
        }
        if (currentSlot == 6 && slots[6].isLocked)
        {
            animPlayer.SetBool("isTakeBigSword", false);
            animPlayer.SetBool("isTakeWeapon", false);
            animPlayer.SetBool("isTakeBow", false);
            animPlayer.SetBool("Charge", false);
            animPlayer.SetBool("isTakeTryba", true);
            animPlayer.SetBool("MiniWeapon1", false);
            animPlayer.SetBool("MiniWeapon2", false);
            animPlayer.SetBool("MiniWeapon3", false);
            animPlayer.SetBool("Molot1Bool", false);
            animPlayer.SetBool("Molot2Bool", false);
            animPlayer.SetBool("MolotAttack", false);

            cameraScript.isRotateRyks = false;
            cameraScript.isRotateAllRyks = true;
            slots[6].slotObject.SetActive(true);
        }
        else
        {
            slots[6].slotObject.SetActive(false);
        }
    }
}

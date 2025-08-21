using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMiniUI : MonoBehaviour
{
    public int CurrentSlot;
    public int MaxSlots;
    public int MinSlots;
    public Image Center;
    public GameObject CenterImage;
    public TextMeshProUGUI TextCountItem;
    public Animator anim;
    public PlayerMovement PlayerMovementScript;
    public PlayerHealth PlayerHealthScript;
    public PlayerJump PlayerJumpScript;
    public Sprite[] ItemsPoisons;

    public int Poison_HealthCurrent;
    public int Poison_EnergyCurrent;
    public int Poison_JumpCurrent;
    public int Poison_SpeedCurrent;
    public int Poison_RegenCurrent;
    public int Poison_EnergyRegenCurrent;
    public int countHPPlusPoison;

    private void Start()
    {
        Poison_HealthCurrent = PlayerPrefs.GetInt("Poison_Health", 0);
        Poison_EnergyCurrent = PlayerPrefs.GetInt("Poison_Energy", 0);
        Poison_JumpCurrent = PlayerPrefs.GetInt("Poison_Jump", 0);
        Poison_SpeedCurrent = PlayerPrefs.GetInt("Poison_Speed", 0);
        Poison_RegenCurrent = PlayerPrefs.GetInt("Poison_Regen", 0);
        Poison_EnergyRegenCurrent = PlayerPrefs.GetInt("Poison_EnergyRegen", 0);
    }

    private void LateUpdate()
    {
        if (CurrentSlot == 0)//poison_health
        {
            TextCountItem.text = Poison_HealthCurrent.ToString();
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Poison_HealthCurrent > 0)
                {
                    PlayerPrefs.SetInt("Poison_Health", Poison_HealthCurrent);
                    PlayerPrefs.Save();
                    anim.Play("CenterMiniInv");
                    Poison_HealthCurrent -= 1;
                    PlayerHealthScript.Heal(countHPPlusPoison);//////DONE
                }
            }
            Center.sprite = ItemsPoisons[0];
        }
        else if (CurrentSlot == 1)//poison_energy
        {
            TextCountItem.text = Poison_EnergyCurrent.ToString();
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Poison_EnergyCurrent > 0)
                {
                    PlayerPrefs.SetInt("Poison_Energy", Poison_EnergyCurrent);
                    PlayerPrefs.Save();
                    anim.Play("CenterMiniInv");
                    Poison_EnergyCurrent -= 1;
                }
            }
            Center.sprite = ItemsPoisons[1];
        }
        else if (CurrentSlot == 2)//poison_jump
        {
            TextCountItem.text = Poison_JumpCurrent.ToString();
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Poison_JumpCurrent > 0)
                {
                    PlayerPrefs.SetInt("Poison_Jump", Poison_JumpCurrent);
                    PlayerPrefs.Save();
                    anim.Play("CenterMiniInv");
                    Poison_JumpCurrent -= 1;
                    PlayerJumpScript.isJumpingPoison = true;//////DONE
                }
            }
            Center.sprite = ItemsPoisons[2];
        }
        else if(CurrentSlot == 3)//poison_speed
        {
            TextCountItem.text = Poison_SpeedCurrent.ToString();
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Poison_SpeedCurrent > 0)
                {
                    PlayerPrefs.SetInt("Poison_Speed", Poison_SpeedCurrent);
                    PlayerPrefs.Save();
                    anim.Play("CenterMiniInv");
                    Poison_SpeedCurrent -= 1;
                    PlayerMovementScript.isSpeedPoison = true;//////DONE
                }
            }
            Center.sprite = ItemsPoisons[3];
        }
        else if(CurrentSlot == 4)//puison_regen
        {
            TextCountItem.text = Poison_RegenCurrent.ToString();
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Poison_RegenCurrent > 0)
                {
                    PlayerPrefs.SetInt("Poison_Regen", Poison_RegenCurrent);
                    PlayerPrefs.Save();
                    anim.Play("CenterMiniInv");
                    Poison_RegenCurrent -= 1;
                    PlayerHealthScript.RegSec = PlayerHealthScript.MaxRegSec;
                    PlayerHealthScript.isRegen = true;//////DONE
                }
            }
            Center.sprite = ItemsPoisons[4];
        }
        else if(CurrentSlot == 5)//poison_energyregen
        {
            TextCountItem.text = Poison_EnergyRegenCurrent.ToString();
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Poison_EnergyRegenCurrent > 0)
                {
                    PlayerPrefs.SetInt("Poison_EnergyRegen", Poison_EnergyRegenCurrent);
                    PlayerPrefs.Save();
                    anim.Play("CenterMiniInv");
                    Poison_EnergyRegenCurrent -= 1;
                }
            }
            Center.sprite = ItemsPoisons[5];
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CurrentSlot -= 1;
            anim.Play("LeftArrowInv");
            if (CurrentSlot <= MinSlots)
            {
                CurrentSlot = MinSlots;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CurrentSlot += 1;
            anim.Play("RightArrowInv");
            if (CurrentSlot >= MaxSlots)
            {
                CurrentSlot = MaxSlots;
            }
        }
        
        PlayerPrefs.SetInt("Poison_Energy", Poison_EnergyCurrent);
        PlayerPrefs.SetInt("Poison_Jump", Poison_JumpCurrent);
        PlayerPrefs.SetInt("Poison_Speed", Poison_SpeedCurrent);
        PlayerPrefs.SetInt("Poison_Regen", Poison_RegenCurrent);
        PlayerPrefs.SetInt("Poison_Health", Poison_HealthCurrent);
        PlayerPrefs.SetInt("Poison_EnergyRegen", Poison_EnergyRegenCurrent);
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerEat : MonoBehaviour
{
    public float maxEat = 60f;
    public float currentEat = 60f;
    
    public bool isReloadEnergy = true;
    public bool isReloadHealth = true;
    public bool isReloadBubbles = true;

    public float countSecEatToMinusHealth;
    public float countSecSpeed;
    public PlayerMovement player;
    public PlayerHealth playerHealth;
    
    public Image EatBar;
    
    void Update()
    {
        EatBar.fillAmount = currentEat / maxEat;
        
        if (player.isRunning && player.currentRunTime > 0)
        {
            countSecSpeed += Time.deltaTime;
            if (countSecSpeed >= 30)
            {
                currentEat -= 5;
                countSecSpeed = 0;
            }
        }
        
        if (currentEat <= 0)
        {
            countSecEatToMinusHealth += Time.deltaTime;
            if (countSecEatToMinusHealth >= 30)
            {
                playerHealth.currentHealth -= 8;
                countSecEatToMinusHealth = 0;
            }
                
        }

        if (currentEat < 1)
        {
            isReloadBubbles = false;
        }
        else
        {
            countSecEatToMinusHealth = 0;
            isReloadBubbles = true;
        }

        if (currentEat < 10)
        {
            isReloadEnergy = false;
        }
        else
        {
            isReloadEnergy = true;
        }
        
        if (currentEat < 15)
        {
            isReloadHealth = false;
        }
        else
        {
            isReloadHealth = true;
        }
    }

    public void PlusEat(float countEatPlus)
    {
        currentEat += countEatPlus;
        if (currentEat >= maxEat)
        {
            currentEat = maxEat;
        }
    }
}

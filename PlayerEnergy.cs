using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public Image BarEnergy;//
    public Animator AnimEnergy;//
    public float EnergyMinus;
    public float maxEnergyTime = 5f;
    public float currentEnergyTime;
    public float recoveryTimer;
    public bool isAttacking = true;
    public PlayerEat playerEat;
    void Update()
    {
        if (recoveryTimer > 0)
        {
            AnimEnergy.SetBool("EnergyRecover", true);
        }
        else
        {
            AnimEnergy.SetBool("EnergyRecover", false);
        }
        BarEnergy.fillAmount = currentEnergyTime / maxEnergyTime;

        if (recoveryTimer <= 1f && playerEat.isReloadEnergy)
        {
            recoveryTimer -= Time.deltaTime;
            if (recoveryTimer <= 0)
            {
                recoveryTimer = 0;
            }
        }

        if (currentEnergyTime >= EnergyMinus)
        {
            isAttacking = true;
        }
        if (currentEnergyTime < EnergyMinus)
        {
            isAttacking = false;
        }

        if (recoveryTimer <= 0f && playerEat.isReloadEnergy)
        {
            currentEnergyTime += Time.deltaTime;
            if (currentEnergyTime >= maxEnergyTime)
            {
                currentEnergyTime = maxEnergyTime;
            }
        }
    }

    public void SpendEnergy()
    {
        if (currentEnergyTime >= EnergyMinus)
        {
            currentEnergyTime -= EnergyMinus;
        }
    }
}

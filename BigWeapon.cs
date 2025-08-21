using UnityEngine;

public class BigWeapon : MonoBehaviour
{
    public Animator anim;
    public Animator animCanvas;
    public float reloadTimer = 3f;
    public float CurrentReloadTimer;
    public bool isAttack;

    public InventoryBigUI interfacePlayer;
    public PlayerEnergy playerEnergy;
    public float EnergySpendAttack;
    private void Start()
    {
        CurrentReloadTimer = 0;
        isAttack = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAttack && playerEnergy.isAttacking)
        {
            playerEnergy.recoveryTimer = 1;
            playerEnergy.EnergyMinus = EnergySpendAttack;
            playerEnergy.SpendEnergy();
            Attack();
        }

        if (!isAttack)
        {
            CurrentReloadTimer -= Time.deltaTime;
            if (CurrentReloadTimer <= 0)
            {
                interfacePlayer.enabled = true;
                CurrentReloadTimer = 0;
                isAttack = true;
                anim.SetBool("BigWeaponAttackBool", false);
            }
        }
    }

    void Attack()
    {
        animCanvas.SetBool("DownSlotBool", false);
        animCanvas.SetBool("Slot1Bool", false);
        animCanvas.SetBool("Slot2Bool", false);
        animCanvas.SetBool("Slot3Bool", false);
        animCanvas.SetBool("Slot4Bool", false);
        animCanvas.SetBool("Slot5Bool", false);
        animCanvas.SetBool("Slot6Bool", false);
        interfacePlayer.enabled = false;
        anim.SetBool("BigWeaponAttackBool", true);
        isAttack = false;
        CurrentReloadTimer = reloadTimer;
    }
}

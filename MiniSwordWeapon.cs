using UnityEngine;

public class MiniSwordWeapon : MonoBehaviour
{
    public Animator anim;
    public Animator animCanvas;
    public float reloadTimer = 3f;
    public float CurrentReloadTimer;
    public float currentRandomAnim;
    public bool isAttack;

    public InventoryBigUI interfacePlayer;
    public PlayerEnergy playerEnergy;
    public float EnergySpendAttack1;
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
            playerEnergy.EnergyMinus = EnergySpendAttack1;
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
                anim.SetBool("MiniWeapon1", false);
                anim.SetBool("MiniWeapon2", false);
                anim.SetBool("MiniWeapon3", false);
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
        currentRandomAnim = Random.Range(0, 3);
        if (currentRandomAnim == 0)
        {
            anim.SetBool("MiniWeapon1", true);
        }
        if (currentRandomAnim == 1)
        {
            anim.SetBool("MiniWeapon2", true);
        }
        if (currentRandomAnim == 2)
        {
            anim.SetBool("MiniWeapon3", true);
        }
        isAttack = false;
        CurrentReloadTimer = reloadTimer;
    }
}
